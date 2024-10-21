using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlStarFill : MonoBehaviour
{
    public GameObject[] StarFill;
    public int currentStarFill = 0;
    public int star = 0;
    public bool StartFill=false;
    public AudioManager SFX;

    private void Awake()
    {
        SFX = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (StartFill)
        {
            StartFill = false;
            if (currentStarFill > StarFill.Length)
            {
                currentStarFill = StarFill.Length;
            }
            if (currentStarFill <= StarFill.Length)
            {
                StartCoroutine(FILL());
            }
            
        }
    }

    IEnumerator FILL()
    {
        for (int i = star; i < currentStarFill; i++)
        {
            SFX.PlayerSFX(SFX.Star);
            yield return new WaitForSeconds(0.5f);
            StarFill[i].gameObject.SetActive(true);
        }
        star = currentStarFill;
    }
}
