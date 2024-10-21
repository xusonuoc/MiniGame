using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class MangerStar : MonoBehaviour
{
    public GameObject[] Stars;

    public bool Star = false;   
    private void Update()
    {
        if (Star)
        {
            StartCoroutine(ActiveStar(Stars.Length));
            Star = false;
        }
    }

    IEnumerator ActiveStar(int length)
    {
        print("run");
        for (int i = 0; i < length; i++)
        {
            Stars[i].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            
        }
    }
}
