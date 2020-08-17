using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public Units units;
    public Transform castPoint;
    public GameObject fireball;
    public float castSpeed;

    private Vector3 point;
    void Start()
    {
        StartCoroutine(Cast());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("PlayableArea")))
            {
                SpawnFireball(hit.point);
            }
        }
    }

    IEnumerator Cast()
    {
        while (true)
        {
            yield return new WaitForSeconds(castSpeed);
            if (units.Value.Count > 0)
            {
                GameObject unit = units.Value[0];
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
