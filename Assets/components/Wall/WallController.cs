using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public WallStats wallStats;
    // Start is called before the first frame update
    void Start()
    {
        wallStats.health = wallStats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        if (wallStats.health - damage <= 0)
        {
            Debug.Log("Game Over. Prestiege Time!");
        } else
        {
            wallStats.health -= damage;
        }
    }
}
