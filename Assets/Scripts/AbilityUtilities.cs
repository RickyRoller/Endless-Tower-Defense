using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public static class AbilityUtilities
{
    public static Vector3 RandomPointInCircle(Vector3 origin, float radius)
    {
        float randomRadius = UnityEngine.Random.Range(0f, radius);
        return _RandomPointInCircle(origin, randomRadius);
    }
    public static Vector3 RandomPointInCircle(Vector3 origin, float radius, AnimationCurve weightingCurve)
    {
        float randomRadius = WeightedCurveValue(weightingCurve, radius);
        return _RandomPointInCircle(origin, randomRadius);
    }

    public static Vector3 _RandomPointInCircle(Vector3 origin, float radius)
    {
        float randomAngle = UnityEngine.Random.Range(0f, 360f);
        Vector3 randomRotationVector = Quaternion.AngleAxis(randomAngle, Vector3.up) * Vector3.right;
        return randomRotationVector * radius + origin;
    }
    public static float WeightedCurveValue(AnimationCurve curve, float value)
    {
        return curve.Evaluate(UnityEngine.Random.value) * value;
    }

    public static void DamageInArea(Vector3 origin, float radius, float damage)
    {
        Collider[] enemies = Physics.OverlapSphere(origin, radius, LayerMask.GetMask("Enemies"));
        if (enemies.Length > 0)
        {
            foreach (var collider in enemies)
            {
                collider.gameObject.SendMessage("ApplyDamage", damage);
            }
        }
    }

    public static GameObject GetClosestObject(Vector3 origin, GameObject[] objects)
    {
        float distance = 0f;
        GameObject closest = null;
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject gameObject = objects[i];
            float dist = Vector3.Distance(origin, gameObject.transform.position);

            if (i == 0 || dist < distance)
            {
                distance = dist;
                closest = gameObject;
            }
        }

        return closest;
    }
}
