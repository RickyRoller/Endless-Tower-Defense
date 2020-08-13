using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RainFireStats", menuName = "ProjectObjects/RainFire/RainFireStats")]
public class RainFireStats : ScriptableObject
{
    public float radius = 10.0f;
    public float castSpeed = 1f;
    public float startY = 20f;
}
