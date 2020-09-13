using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallController : MonoBehaviour
{
    public WallStats wallStats;
    public Image wallHeathBar;
    // Start is called before the first frame update
    void Start()
    {
        wallStats.health = wallStats.maxHealth;
        wallHeathBar = GameObject.Find("WallHealthBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        if (wallStats.health - damage <= 0)
        {
            wallStats.health = 0;
            Debug.Log("Game Over. Prestiege Time!");
        } else
        {
            wallStats.health -= damage;
        }
        wallHeathBar.fillAmount = wallStats.health / wallStats.maxHealth;
    }
}
