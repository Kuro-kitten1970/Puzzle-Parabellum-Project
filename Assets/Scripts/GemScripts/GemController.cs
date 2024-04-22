using UnityEngine;

public class GemController : MonoBehaviour
{
    [Header("Key Input Properties")]
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _rotateRight = KeyCode.E;
    [SerializeField] private KeyCode _rotateLeft = KeyCode.Q;

    private Vector3 _moveRightPos = new Vector2(0.5f, 0);
    private Vector3 _moveLeftPos = new Vector2(-0.5f, 0);

    private Gem _gem;
    private GameBoard _board;

    private void OnEnable()
    {
        _gem = GetComponent<Gem>();
        _board = BoardManager.GetBoard(_gem.boardID);
    }

    private void Update()
    {
        if (_board.CurrentGem_1 == null || _board.CurrentGem_2 == null) return;

        if (Input.GetKeyDown(_moveRight))
            MoveRightLeftHandle(_moveRightPos);

        if (Input.GetKeyDown(_moveLeft))
            MoveRightLeftHandle(_moveLeftPos);

        if (Input.GetKeyDown(_rotateRight))
        {
            _board.CurrentGem_2.transform.RotateAround(_board.CurrentGem_1.transform.position, -_board.CurrentGem_1.transform.forward, 90);

            if (!_board.IsValidPosition(_board.CurrentGem_2.transform.position))
            {
                RotateGemHandler();

                if (_board.IsValidPosition(_board.CurrentGem_2.transform.position)) return;
                _board.CurrentGem_2.transform.RotateAround(_board.CurrentGem_1.transform.position, -_board.CurrentGem_1.transform.forward, -90);
            }

            _board.CurrentGem_2.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(_rotateLeft))
        {
            _board.CurrentGem_2.transform.RotateAround(_board.CurrentGem_1.transform.position, _board.CurrentGem_1.transform.forward, 90);

            if (!_board.IsValidPosition(_board.CurrentGem_2.transform.position))
            {
                RotateGemHandler();
                _board.CurrentGem_2.transform.RotateAround(_board.CurrentGem_1.transform.position, _board.CurrentGem_1.transform.forward, -90);
            }

            _board.CurrentGem_2.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void RotateGemHandler()
    {
        Vector3 objPos = BoardManager.GetBoard(_gem.boardID).CurrentGem_2.transform.position;

        if (BoardManager.GetBoard(_gem.boardID).GetWidthOfGrid(objPos) >= BoardManager.GetBoard(_gem.boardID).Width)
        {
            transform.position -= new Vector3(0.5f, 0);
        }
        else if (BoardManager.GetBoard(_gem.boardID).GetWidthOfGrid(objPos) < BoardManager.GetBoard(_gem.boardID).Width)
        {
            transform.position += new Vector3(0.5f, 0);
        }
    }

    private void MoveRightLeftHandle(Vector3 tranformPos)
    {
        transform.position += tranformPos;

            if (!_board.IsValidPosition(transform.position))
                transform.position -= tranformPos;

            if (!_board.IsValidPosition(_board.CurrentGem_2.transform.position))
                transform.position -= tranformPos;
    }
}
