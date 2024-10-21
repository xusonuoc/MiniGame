using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IventorySlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 1)
        {
            GameObject dropped = eventData.pointerDrag;
            ItemDragged draggableItem = dropped.GetComponent<ItemDragged>();
            draggableItem.transformParentCurrent = transform;
        }

    }
}
