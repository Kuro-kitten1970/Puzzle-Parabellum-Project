using UnityEngine;

public class GemController : MonoBehaviour
{
    [Header("Key Player1 Input Properties")]
    [SerializeField] private KeyCode p1_moveRight = KeyCode.D;
    [SerializeField] private KeyCode p1_moveLeft = KeyCode.A;
    [SerializeField] private KeyCode p1_rotateRight = KeyCode.E;
    [SerializeField] private KeyCode p1_rotateLeft = KeyCode.Q;

    [Header("Key Player2 Input Properties")]
    [SerializeField] private KeyCode p2_moveRight = KeyCode.L;
    [SerializeField] private KeyCode p2_moveLeft = KeyCode.J;
    [SerializeField] private KeyCode p2_rotateRight = KeyCode.O;
    [SerializeField] private KeyCode p2_rotateLeft = KeyCode.U;

    public enum PlayerInput
    {
        MoveRight, MoveLeft, RotateRight, RotateLeft
    }

    private Vector3 _moveRightPos = new Vector2(0.5f, 0);
    private Vector3 _moveLeftPos = new Vector2(-0.5f, 0);

    private Gem _gem;
    public GameBoard Board;

    private void OnEnable()
    {
        _gem = GetComponent<Gem>();
    }

    private void Update()
    {
        if (GameManager.IsGameEnd) return;
        
        if (Input.GetKeyDown(GetPlayerInput(PlayerInput.MoveRight)))
            MoveRightLeftHandle(_moveRightPos);

        if (Input.GetKeyDown(GetPlayerInput(PlayerInput.MoveLeft)))
            MoveRightLeftHandle(_moveLeftPos);

        if (Input.GetKeyDown(GetPlayerInput(PlayerInput.RotateRight)))
        {
            Board.CurrentGem_2.transform.RotateAround(Board.CurrentGem_1.transform.position, -Board.CurrentGem_1.transform.forward, 90);

            if (!Board.IsValidPosition(Board.CurrentGem_2.transform.position))
            {
                RotateGemHandler();

                if (Board.IsValidPosition(Board.CurrentGem_2.transform.position)) return;
                Board.CurrentGem_2.transform.RotateAround(Board.CurrentGem_1.transform.position, -Board.CurrentGem_1.transform.forward, -90);
            }

            Board.CurrentGem_2.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(GetPlayerInput(PlayerInput.RotateLeft)))
        {
            Board.CurrentGem_2.transform.RotateAround(Board.CurrentGem_1.transform.position, Board.CurrentGem_1.transform.forward, 90);

            if (!Board.IsValidPosition(Board.CurrentGem_2.transform.position))
            {
                RotateGemHandler();
                Board.CurrentGem_2.transform.RotateAround(Board.CurrentGem_1.transform.position, Board.CurrentGem_1.transform.forward, -90);
            }

            Board.CurrentGem_2.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void RotateGemHandler()
    {
        Vector3 objPos = Board.CurrentGem_2.transform.position;

        if (Board.GetWidthOfGrid(objPos) >= Board.Width)
        {
            transform.position -= new Vector3(0.5f, 0);
        }
        else if (Board.GetWidthOfGrid(objPos) < Board.Width)
        {
            transform.position += new Vector3(0.5f, 0);
        }
    }

    private void MoveRightLeftHandle(Vector3 tranformPos)
    {
        transform.position += tranformPos;

        if (!Board.IsValidPosition(transform.position))
            transform.position -= tranformPos;

        if (!Board.IsValidPosition(Board.CurrentGem_2.transform.position))
            transform.position -= tranformPos;
    }

    private KeyCode GetPlayerInput(PlayerInput input)
    {
        if (_gem.boardID == BoardID.BoardPlayer1)
        {
            return input switch
            {
                PlayerInput.MoveRight => p1_moveRight,
                PlayerInput.MoveLeft => p1_moveLeft,
                PlayerInput.RotateRight => p1_rotateRight,
                PlayerInput.RotateLeft => p1_rotateLeft,
                _ => KeyCode.B
            };
        }

        return input switch
        {
            PlayerInput.MoveRight => p2_moveRight,
            PlayerInput.MoveLeft => p2_moveLeft,
            PlayerInput.RotateRight => p2_rotateRight,
            PlayerInput.RotateLeft => p2_rotateLeft,
            _ => KeyCode.B
        };
    }
}
