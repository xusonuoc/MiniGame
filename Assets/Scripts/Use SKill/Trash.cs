using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler
{
    public GameObject TimeLine;
    private TimeCount time;
    public AudioManager SFX;

    private void Awake()
    {
        SFX = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        time =TimeLine.GetComponent<TimeCount>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped != null)
        {
            switch (dropped.tag)
            {
                case "Destroy":
                    SpecialSkill.Instance.CanDestroy = true;
                    SFX.PlayerSFX(SFX.Destroyed);
                    break;
                case "Freeze":
                    SpecialSkill.Instance.CanFreeze = true;
                    SFX.PlayerSFX(SFX.Freeze);
                    break;
                case "Party":
                    SpecialSkill.Instance.CanParty = true;
                    SFX.PlayerSFX(SFX.Party);
                    break;
            }

            time.timeRemaining+=2;
            Destroy(dropped);
        }
    }


}
