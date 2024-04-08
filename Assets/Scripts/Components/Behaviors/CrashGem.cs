using UnityEngine;

public class CrashGem : MonoBehaviour, IGemBehavior
{
    private RayDetection _rayDetection;
    private Vector2[] directions = { Vector2.down, Vector2.up, Vector2.right, Vector2.left };
    private Gem _gem;
    private GameObject _gameObject;
    private bool _isDestroy = false;

    private void Start()
    {
        _rayDetection = GetComponent<RayDetection>();
    }

    private void Update()
    {
        
    }

    public void GemBehavior(Gem gem)
    {
        _gem = gem;
    }

    public void GemVisitor()
    {
        
    }
}
