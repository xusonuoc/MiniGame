using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    public Image[] ImageList;
    public GameObject[] ImageShow;
    public bool DoneMission;

    public List<Image> CheckMission;



    private void Start()
    {
        CheckMission = new List<Image>();
        DoneMission = true;
        
    }

    private void Update()
    {
        if (DoneMission)
        {
            CheckMission.Clear();
            ResetImage();
            int Amount = RandomAmount();
            for (int i = 0; i < Amount; i++)
            {
                int RandomItem = Random.Range(0, 3);
                Instantiate(ImageList[RandomItem], ImageShow[i].transform);
                CheckMission.Add(ImageList[RandomItem]);
            }
           
            DoneMission = false;
            Debug.Log("Đã Xong");
        }
    }

    private int RandomAmount()
    {
        return Random.Range(1, 4);
    }

    public void ResetImage()
    {
        for (int i = 0;i < ImageShow.Length; i++)
        {
            if (ImageShow[i].transform.childCount > 0)
            {
                Transform Image = ImageShow[i].transform.GetChild(0);
                Destroy(Image.gameObject); //fix lỗi hủy game object chứ không phải transform
            }
        }
    }
}
