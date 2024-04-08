using UnityEngine;

public class NormalGem : MonoBehaviour, IGemBehavior
{
    RayDetection rayDetection;

    private void Awake()
    {
        rayDetection = GetComponent<RayDetection>();
    }

    public void GemBehavior(Gem gem)
    {
        
    }

    public void GemVisitor()
    {
        
    }
}
