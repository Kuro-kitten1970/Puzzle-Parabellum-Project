using System;
using Unity.VisualScripting;
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

    public GameObject GemChecker(Vector2 direction)
    {
        RaycastHit2D gemChecker = Physics2D.Raycast(transform.position, direction, _rayDistance, _gemLayer);

        if (!gemChecker.IsUnityNull())
            return gemChecker.collider.gameObject;
        else
            return null;
    }
}
