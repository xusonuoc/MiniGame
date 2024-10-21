using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject[] Star;
    private ControlStarFill controlStarFill;
    public GameObject ControlStar;

    private AudioManager SFX;

    private void Awake()
    {
        SFX = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        controlStarFill = ControlStar.GetComponent<ControlStarFill>();
    }

    private void Start()
    {
        StartCoroutine(FILL());
    }
    IEnumerator FILL()
    {
        for (int i = 0; i < controlStarFill.currentStarFill; i++)
        {
 
            yield return new WaitForSeconds(0.8f);
            Star[i].gameObject.SetActive(true);
        }

        SFX.PlayerSFX(SFX.Final);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

}
