using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseTracker : MonoBehaviour
{
    public GameObject spellMarker;
    private GameObject spell;
    private GameObject _instantiatedPrefab;
    private bool isTracking = false;
    private bool shouldCastSpell = false;
    private Vector3 trackedLocation;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
        if (isTracking)
        {
            TrackMouse();
        }
    }

    void TrackMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("PlayableArea")))
        {
            if (!_instantiatedPrefab.activeSelf)
            {
                _instantiatedPrefab.SetActive(true);
            }
            trackedLocation = new Vector3(hit.point.x, 0, hit.point.z);
            _instantiatedPrefab.transform.position = trackedLocation;

            shouldCastSpell = true;
        }
        else
        {
            _instantiatedPrefab.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (spellMarker != null)
        {
            isTracking = true;
            _instantiatedPrefab = Instantiate(spellMarker, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void OnMouseUp()
    {
        if (isTracking)
        {
            if (spell != null && shouldCastSpell)
            {
                Instantiate(spell, trackedLocation, Quaternion.identity);
            }

            isTracking = false;
            Destroy(_instantiatedPrefab);
            _instantiatedPrefab = null;
            spell = null;
            spellMarker = null;
            shouldCastSpell = false;
        }
    }

    public void AssignSpell(SpellInstanceData spellData)
    {
        Debug.Log(spellData);
        spell = spellData.spell;
        spellMarker = spellData.spellMarker;
    }
}
