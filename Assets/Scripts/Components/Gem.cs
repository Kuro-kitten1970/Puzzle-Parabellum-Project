using System;
using UnityEngine;

public enum GemColorType
{
    None, Red, Blue, Yellow
}

public class Gem : MonoBehaviour
{
    public GemColorType gemColor;

    public void ApplyBehavior(IGemBehavior gem, GemColorType colorType)
    {
        gem.GemBehavior(this, colorType);
    }
}
