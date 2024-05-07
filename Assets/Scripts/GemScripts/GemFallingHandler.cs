using UnityEngine;

public class GemFallingHandler : MonoBehaviour
{
    [Header("Movement Properties")]
    [SerializeField] private float _fallingSpeed = 0.5f;
    [SerializeField] private float _fallTime = 1f;
    [SerializeField] private KeyCode p1_moveDown = KeyCode.S;
    [SerializeField] private KeyCode p2_moveDown = KeyCode.K;

    private float _currentTime = 0f;

    public bool _isControllable = true;
    public bool _isChildren = false;

    public GemSpawner Spawner;

    private GameBoard _board;
    private GemController _gemController;
    private GemFallingHandler _gemFalling;
    private Gem _gem;

    private void Start()
    {
        _gem = GetComponent<Gem>();
        _board = BoardManager.GetBoard(_gem.boardID);

        _gemController = _board.CurrentGem_1.GetComponent<GemController>();
    }

    private void Update()
    {
        if (Time.time - _currentTime > (Input.GetKey(GetPlayerInput(_gem.boardID)) ? _fallTime / 10 : _fallTime) && _isControllable)
        {
            transform.position += new Vector3(0, -_fallingSpeed);

            if (!_board.IsValidPosition(transform.position) || !_board.IsValidPosition(_board.CurrentGem_2.transform.position))
            {
                _isControllable = false;

                transform.position -= new Vector3(0, -_fallingSpeed);

                _board.AddToGrid(_board.CurrentGem_1, _board.CurrentGem_1.transform.position);
                _board.AddToGrid(_board.CurrentGem_2, _board.CurrentGem_2.transform.position);

                gameObject.transform.DetachChildren();

                _gemController.enabled = false;
                _gemFalling = _board.CurrentGem_2.GetComponent<GemFallingHandler>();
                _gemFalling._isControllable = false;
                _gemFalling.enabled = true;

                if (_gem.isDiamondGem)
                    _board.DestroyAllGem(gameObject);

                if (_gem.isCrashGem)
                    _board.DestroyConnectedGem(gameObject);

                if (!_board.CurrentGem_1.GetComponent<Gem>().isAlreadyPlaced && !_board.CurrentGem_2.GetComponent<Gem>().isAlreadyPlaced)
                    Spawner.SpawnGem(_board);
            }

            _currentTime = Time.time;
        }
        else if (Time.time - _currentTime > (transform.parent == null ? _fallTime / 10 : _fallTime) && !_isControllable)
        {
            _board.RemoveFromGrid(gameObject, transform.position);
            transform.position += new Vector3(0, -_fallingSpeed);

            if (!_board.IsValidPosition(transform.position))
            {
                transform.position -= new Vector3(0, -_fallingSpeed);
                _board.AddToGrid(gameObject, transform.position);
            }

            if (_gem.isCrashGem)
                _board.DestroyConnectedGem(gameObject);
        }
    }

    private KeyCode GetPlayerInput(BoardID id)
    {
        return id switch
        {
            BoardID.BoardPlayer1 => p1_moveDown,
            BoardID.BoardPlayer2 => p2_moveDown,
            _ => KeyCode.B
        };
    }
}
