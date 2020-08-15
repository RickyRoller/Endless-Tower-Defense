using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainArrows : MonoBehaviour
{
    public float damage = 20f;
    public float damageInterval = 0.25f;
    public float radius = 3f;
    public float arrowSpeed = 2500;
    public float duration = 4f;
    public float burstDuration = 1f;
    public float arrowSpawnSpeed = 0.2f;
    public AnimationCurve weightedRadiusCurve;

    public GameObject projectile;

    private float timeRemaining;
    private float burstTimeRemaining;
    private float damagePerBurst;

    void Start()
    {
        timeRemaining = duration;
        burstTimeRemaining = burstDuration;
        damagePerBurst = (duration / damageInterval) / damage;
        StartCoroutine(DamageCheck());
        StartCoroutine(CastArrows());
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        burstTimeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator CastArrows()
    {
        while(timeRemaining > 0)
        {
            SpawnArrow();
            var spawnSpeed = arrowSpawnSpeed;
            if (burstTimeRemaining > 0) spawnSpeed *= 0.3f;
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    IEnumerator DamageCheck()
    {
        while(gameObject.activeSelf)
        {
            AbilityUtilities.DamageInArea(transform.position, radius, damagePerBurst);
            yield return new WaitForSeconds(damageInterval);
        }
    }

    private void SpawnArrow()
    {
        Vector3 spawnPosition = AbilityUtilities.RandomPointInCircle(transform.position, radius, weightedRadiusCurve);
        Vector3 targetPosition = AbilityUtilities.RandomPointInCircle(transform.position, radius, weightedRadiusCurve);

        var script = projectile.GetComponent<RainArrowsArrow>();
        script.target = targetPosition;
        script.speed = arrowSpeed;
        Instantiate(projectile, new Vector3(spawnPosition.x, 18f, spawnPosition.z), Quaternion.identity, transform);
    }
}
