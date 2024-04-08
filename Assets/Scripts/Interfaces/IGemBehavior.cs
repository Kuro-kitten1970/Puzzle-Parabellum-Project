using UnityEngine;

public interface IGemBehavior
{
    public void GemBehavior(Gem gem, GemColorType colorType);
    public void GemVisitor();
}
