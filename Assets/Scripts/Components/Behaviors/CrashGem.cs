using UnityEngine;

public class CrashGem : MonoBehaviour, IGemBehavior
{
    public void GemBehavior(Gem gem, GemColorType colorType)
    {
        gem.gemColor = colorType;
    }

    public void GemVisitor()
    {
        
    }
}
