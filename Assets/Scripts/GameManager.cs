using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] endPoints;
    public GameObject enemy;
    public Units units;
    public WallController wallController;

    private void Awake()
    {
        units.ClearList();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
