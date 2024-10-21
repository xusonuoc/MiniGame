using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Transform TranformPosition;
    public float Speed = 1000f;
    private void Start()
    {
        Speed = 1000f;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TranformPosition.position, Time.deltaTime*Speed);
        if (transform.position == TranformPosition.position)
        {
            transform.position = new Vector2(0,0);
            gameObject.SetActive(false);
        }
    }
}
