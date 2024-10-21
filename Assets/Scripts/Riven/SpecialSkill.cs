using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialSkill : MonoBehaviour
{
    public GameObject TimeLine;
    private TimeCount time;
    public RawImage rawImage;
    public GameObject[] objectToSpawn;




    private static SpecialSkill instance;

    public static SpecialSkill Instance 
    {
        get => instance;
    }

    private void Awake()
    {
        SpecialSkill.instance = this;
    }

    private void Start()
    {
        time = TimeLine.GetComponent<TimeCount>();
    }

    #region FreezeSKill
    public bool CanFreeze;

    private void SpeedDown()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform Freeze = gameObject.transform.GetChild(i);
            Freeze.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
    }
    #endregion

    #region PartyFood
    public bool CanParty;
    private bool Spawn = false;
    


    public void SpawnObject(int randomItem)
    {
        RectTransform rawImageRect = rawImage.GetComponent<RectTransform>();

        // Lấy tọa độ và kích thước của RawImage
        Vector2 rawImageSize = rawImageRect.sizeDelta;
        Vector3 rawImagePos = rawImageRect.position;

        // Tính toán giới hạn vị trí để đối tượng không spawn ra ngoài RawImage
        //float minX = rawImagePos.x - rawImageSize.x / 2;
        //float maxX = rawImagePos.x + rawImageSize.x / 2;
        float minY = rawImagePos.y - rawImageSize.y / 2;
        float maxY = rawImagePos.y + rawImageSize.y / 2;

        float X = rawImageSize.x;
        // Tạo vị trí spawn ngẫu nhiên trong giới hạn của RawImage

        float randomY = Random.Range(minY, maxY);

        // Tạo đối tượng tại vị trí được tính toán
        Vector3 spawnPosition = new Vector3(X, randomY, 0);

        // Spawn đối tượng
        Instantiate(objectToSpawn[randomItem], spawnPosition, Quaternion.identity, rawImage.transform);
    }

    IEnumerator Party(float cnt)
    {
        for (int i = 0; i < cnt; i++)
        {
            Spawn = true;
            yield return new WaitForSeconds(2.5f);
            Spawn = false;
        }

        Spawn = false;
    }
    #endregion

    #region DestroyEveryThing
    public bool CanDestroy;
    
    public void DestroyAllItem()
    {
        int cnt = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform DestroyGameObject = gameObject.transform.GetChild(i);
            Destroy(DestroyGameObject.gameObject);
            cnt++;
        }
        time.timeRemaining += cnt;
    }

    #endregion

    private void Update()
    {
        if (CanFreeze)
        {
            SpeedDown();
            CanFreeze = false;
        }

        if (CanParty) 
        {
            StartCoroutine(Party(5));
            CanParty = false;
        }

        if (Spawn)
        {
            for (int i = 0; i <5; i++)
            {
                int index = Random.Range(0, objectToSpawn.Length);
                SpawnObject(index);
            }
            Spawn = false;
        }

        if (CanDestroy)
        {
            DestroyAllItem();
            CanDestroy = false;
        }
    }



}
