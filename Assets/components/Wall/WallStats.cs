using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WallStats", menuName = "ProjectObjects/Wall/Wall Stats")]
public class WallStats : ScriptableObject
{
    public float maxHealth;
    public float health;
}
