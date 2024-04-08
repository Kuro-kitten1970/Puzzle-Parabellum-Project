using UnityEngine;

public class ObjectMovements : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.01f;
    [SerializeField] private float _moveTime = 0.1f;
    [SerializeField] private float _hardFallingSpeed = 0.1f;

    private RayDetection _detection;
    private float _currentTime = 0;

    private void Awake()
    {
        _detection = GetComponent<RayDetection>();
    }

    private void Update()
    {
        if (_detection.IsGrounded) return;

        _currentTime += Time.deltaTime;
        if (_currentTime > _moveTime)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - _moveSpeed);
            _currentTime = 0;
        }
    }
}
