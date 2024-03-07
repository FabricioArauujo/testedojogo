using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SlotTag { None, Proteinas, Lipidios, acidosLaticos }


public class InventorySlot : MonoBehaviour, IPointerClickHandler
{

    public InventoryItem myItem { get; set; }

    public SlotTag myTag;

    public void OnPointerClick(PointerEventData eventData)
    {

    }
  
    public void SetItem(InventoryItem item)
    {

    }
}
