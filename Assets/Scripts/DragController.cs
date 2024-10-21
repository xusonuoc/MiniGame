using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private Transform ItemDrag;

    [SerializeField]
    private GameObject movingItem;
    private void Update()
    {
        if (movingItem == null)
            return;
        Vector2 mousePos = Input.mousePosition;
        movingItem.transform.position = mousePos;   
    }

    public void setMovingItem(GameObject Item)
    {
        Debug.Log("Đang nhặt");
        movingItem = Item;
        movingItem.transform.SetParent(gameObject.transform);
    }

    public void removeMovingItem()
    {
        movingItem = null;
    }
}
