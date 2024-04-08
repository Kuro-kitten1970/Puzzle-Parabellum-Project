using UnityEngine;

public class NormalGem : MonoBehaviour, IGemBehavior
{
    public void GemBehavior(Gem gem, GemColorType colorType)
    {
        gem.gemColor = colorType;
    }

    public void GemVisitor()
    {
        
    }
}
