using UnityEngine;

public class GemStateContext : MonoBehaviour
{
    public IGemState CurrentGemState{ get; set; }

    private readonly Gem _gem;

    public GemStateContext(Gem gem) => _gem = gem;

    public void Transition() => CurrentGemState.Handle(_gem);

    public void Transition(IGemState state)
    {
        CurrentGemState = state;
        CurrentGemState.Handle(_gem);
    }
}
