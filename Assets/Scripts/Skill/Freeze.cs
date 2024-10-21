using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public GameObject Parent;
    Item item;

    private void Awake()
    {   
        item = Parent.GetComponent<Item>();
    }

    private void Start()
    {
        item.Speed /= 2;
    }
}
