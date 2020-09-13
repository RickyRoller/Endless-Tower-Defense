using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpellButton : MonoBehaviour, IPointerDownHandler
{
    public SpellInstanceData spellData;
    GameManager GM;
    void Start()
    {
        GM = FindObjectOfType<GameManager>();

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        GM.SendMessage("AssignSpell", spellData);
    }
}
