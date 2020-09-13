using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellInstanceData", menuName = "ProjectObjects/Spell/Spell Instance Data")]
public class SpellInstanceData : ScriptableObject
{
    public GameObject spell;
    public GameObject spellMarker;
}
