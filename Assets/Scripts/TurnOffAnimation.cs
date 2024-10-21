using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAnimation : MonoBehaviour
{
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
