using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ProjectObjects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    public enum TYPE { NORMAL, MAGIC, RARE, ELITE, BOSS };
    public float health;
    public string enemyName;
    public float speed;
}
