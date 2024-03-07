using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Singleton;
    public static InventoryItem carriedItem;

    [SerializeField] InventorySlot[] inventorySlots;
    [SerializeField] InventorySlot[] EquipComponente;

    [SerializeField] Transform draggablesTransform;

    [SerializeField] InventoryItem itemPrefab;

    [SerializeField] item[] items;

    [SerializeField] Button giveItemBtn;

    private void Awake()
    {
        Singleton = this;
        giveItemBtn.onClick.AddListener(delegate { SpawnInventoryItem(); });
    }

    private void  Update()
    {
        if (carriedItem == null)
        {
            return;
        }
        carriedItem.transform.position = Input.mousePosition;
    }

    public void SetCarriedItem(InventoryItem item)
    {
        if (carriedItem != null)
        {
            if (item.activeSlot.myTag != SlotTag.None && item.activeSlot.myTag != carriedItem.myItem.itemTag)
            {
                return;
            }

            item.activeSlot.SetItem(carriedItem);
        }

        if(item.activeSlot.myTag != SlotTag.None)
        {
            EquipEquipment(item.activeSlot.myTag, null);
        }

        carriedItem = item;
        carriedItem.canvasGroup.blocksRaycasts = false;
        item.transform.SetParent(draggablesTransform);
    }

    public void SpawnInventoryItem(item item =null)
    {
        item _item = item;
        if (_item == null)
        {
            _item = PickRandomItem();
        }

        for(int i =0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].myItem == null)
            {
                Instantiate(itemPrefab, inventorySlots[i].transform).Initialize(_item, inventorySlots[i]);
                break;
            }
        }
    }

    public void EquipEquipment(SlotTag tag, InventoryItem item = null)
    {
        switch (tag) {
            case SlotTag.Proteinas:
                if (item == null)
                {
                    Debug.Log("Removeu um item da tag Proteinas");

                }
                else
                {
                    Debug.Log("Adiquiriu uma Proteina");
                }
                break;
            case SlotTag.Lipidios:
                break;
            case SlotTag.acidosLaticos:
                break;
        }

    }
    item PickRandomItem()
    {
        int random = Random.Range(0, items.Length);
        return items[random];
    }
}
