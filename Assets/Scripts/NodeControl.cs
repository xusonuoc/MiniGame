using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public GameObject[] Node;
    public GameObject Mission;
    private Mission mission;

    public GameObject[] EffectDoneMission;
    private MangerStar[] mangerStar;
    public int LastItemMission ;

    public GameObject ControlStar;
    public ControlStarFill controlStarFill;

    private void Start()
    {
        mission = Mission.GetComponent<Mission>();
        controlStarFill = ControlStar.GetComponent<ControlStarFill>();
        mangerStar = new MangerStar[EffectDoneMission.Length];
        for (int i = 0; i < EffectDoneMission.Length; i++)
        {
            if (EffectDoneMission[i] != null)
            {
                mangerStar[i] = EffectDoneMission[i].GetComponent<MangerStar>();
            }
        }
        LastItemMission = 1;
    }

    public void CheckMission()
    {
        int check = mission.CheckMission.Count;
        int index = 0;

    

        Debug.Log("CHECK THE MISSION");
       

        for (int i = 0; i < check; i++)
        {
            if (Node[i].transform.childCount > 1)
            {
                Transform child = Node[i].transform.GetChild(1);

                if (child.tag == mission.CheckMission[index].tag)
                {
                    index++;
                    print("đúng" + i);
                }
                else
                {
                    print("Sai vị trí thứ " + i);
                    return;
                }
            }
            else
            {
                print("Không có item");
                return;
            }

          
        }

     
        if (index == check)
        {
            LastItemMission = index;
            for (int i = 0; i < LastItemMission; i++)
            {
                mangerStar[i].Star = true;
                controlStarFill.currentStarFill++;
            }
            controlStarFill.StartFill = true;
            mission.DoneMission = true;

        }
        else
        {
            print("Chua xong");
        }
    }

}
