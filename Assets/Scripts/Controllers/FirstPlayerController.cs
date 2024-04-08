using UnityEngine;

public class FirstPlayerController : MonoBehaviour
{
    [SerializeField] private float _moveHorizontalDistance = 0.5f;
    private RayDetection gemDetection;

    public bool CanControl
    {
        get => !gemDetection.IsGrounded;
    }

    private void Awake()
    {
        gemDetection = GetComponent<RayDetection>();
    }

    private void Update()
    {
        if (!CanControl) Destroy(GetComponent<FirstPlayerController>());

        if (Input.GetKeyUp(KeyCode.D))
            MoveHandle(_moveHorizontalDistance, 0);
        if (Input.GetKeyUp(KeyCode.A))
            MoveHandle(-_moveHorizontalDistance, 0);
    }

    private void MoveHandle(float x, float y)
    {
        transform.position = new Vector2(transform.position.x + x, transform.position.y);
    }
}
