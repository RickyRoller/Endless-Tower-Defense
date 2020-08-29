using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public Units units;
    public Transform castPoint;
    public GameObject fireball;
    public float castSpeed;
    void Start()
    {
        StartCoroutine(Cast());
    }

    IEnumerator Cast()
    {
        while (true)
        {
            yield return new WaitForSeconds(castSpeed);
            if (units.Value.Count > 0)
            {
                GameObject unit = AbilityUtilities.GetClosestObject(transform.position, units.Value.ToArray());
                Vector3 position = unit.transform.position;
                position.y -= 0.2f;
                SpawnFireball(position);
            }
        }
    }

    private void SpawnFireball(Vector3 point)
    {
        GameObject fireballInstance = Instantiate(fireball, castPoint.position, gameObject.transform.rotation);
        Fireball fbMain = fireballInstance.GetComponent<Fireball>();
        fbMain.destination = point;
    }
}
