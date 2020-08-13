using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Units", menuName = "ProjectObjects/UnitsList")]
public class Units : ScriptableObject
{
    public List<GameObject> Value = new List<GameObject>();

    public List<GameObject> Add(GameObject unit)
    {
        this.Value.Add(unit);
        return this.Value;
    }

    public List<GameObject> Remove(GameObject unit)
    {
        int index = this.Value.FindIndex((GameObject u) => unit.GetInstanceID() == u.GetInstanceID());
        this.Value.RemoveAt(index);
        return this.Value;
    }

    public void ClearList()
    {
        this.Value.RemoveAll((GameObject u) => true);
    }
}
