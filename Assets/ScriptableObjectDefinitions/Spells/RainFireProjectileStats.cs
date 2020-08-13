using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RainFireProjectileStats", menuName = "ProjectObjects/RainFire/RainFireProjectileStats")]
public class RainFireProjectileStats : ScriptableObject
{
    public float speed = 1f;
    public float explosionRadius = 2.5f;
    public float damage = 4f;
}
