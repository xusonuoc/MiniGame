using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Vector2 EndPoint;
    public string Tag = "Riven";
    public float Speed;
    public GameObject AnimationInWater;
    public GameObject Freezed;

    private void Start()
    {
        Speed = Random.Range(7, 15) * 10;
    }
    private void Update()
    {
        if (IsParentTag(Tag))
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(EndPoint.x, transform.position.y), Speed * Time.deltaTime);
            AnimationInWater.SetActive(true);
        }
        if (transform.position.x == EndPoint.x)
        {
            Destroy(gameObject);
        }
    }

    private bool IsParentTag(string tagToCheck)
    {

        Transform parentTransform = transform.parent;

        if (parentTransform != null)
        {
            
            GameObject parentObject = parentTransform.gameObject;

       
            return parentObject.CompareTag(tagToCheck);
        }

        
        return false;
    }
}
