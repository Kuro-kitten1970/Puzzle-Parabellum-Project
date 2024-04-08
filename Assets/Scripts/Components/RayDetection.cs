using UnityEngine;

public class RayDetection : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 0.01f;
    [SerializeField] private ContactFilter2D _castFilter;
    [SerializeField] private LayerMask _gemLayer;

    private BoxCollider2D _boxCollider;
    private RaycastHit2D[] _objHits = new RaycastHit2D[3];
    private bool _isGrounded;
    public bool IsGrounded
    {
        get => _isGrounded;
        private set => _isGrounded = value;
    }

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        _isGrounded = _boxCollider.Cast(Vector2.down, _castFilter, _objHits, _rayDistance) > 0;
    }

    public void GemChecker(Vector2 direction)
    {
        
    }
}
