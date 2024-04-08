using UnityEngine;

public class Gem : MonoBehaviour
{
    public void ApplyBehavior(IGemBehavior gem)
    {
        gem.GemBehavior(this);
    }
}
