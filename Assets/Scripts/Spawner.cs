using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Boolean SpawnWaves = true;
    private GameManager GM;
    public GameParameters gameParameters;
    // Start is called before the first frame update
    void Start()
    {
        GM = GetComponent<GameManager>();
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while(SpawnWaves)
        {
            GameObject enemy = GM.enemy;
            int index = UnityEngine.Random.Range(0, GM.spawnPoints.Length);
            Transform spawnPoint = GM.spawnPoints[index];

            SpawnEnemy(enemy, spawnPoint);
            yield return new WaitForSeconds(gameParameters.spawnRate);
        }
    }

    void SpawnEnemy(GameObject enemy, Transform spawnPoint)
    {
        Transform wallStart = GM.endPoints[0];
        Transform wallEnd = GM.endPoints[GM.endPoints.Length - 1];
        Vector3 destination = new Vector3(wallStart.position.x, enemy.transform.position.y, UnityEngine.Random.Range(wallEnd.position.z, wallStart.position.z));

        EnemyController enemyCon = enemy.GetComponent<EnemyController>();
        enemyCon.destination = destination;

        enemyCon.stats = ScriptableObject.CreateInstance<EnemyStats>();
        enemyCon.stats.enemyName = "Basic ass grunt";
        enemyCon.stats.health = 10f;
        enemyCon.stats.speed = 10f;

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
