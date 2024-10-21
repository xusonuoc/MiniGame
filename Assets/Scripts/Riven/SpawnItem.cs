using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectToSpawn; // Prefab của đối tượng cần spawn
    public RawImage rawImage; // RawImage mà bạn muốn spawn các đối tượng bên trong
    private bool canSpawn;

    public GameObject[] Skills;

    void Start()
    {
        canSpawn = true;
        StartCoroutine(SpawnTime());
        StartCoroutine(SpawnSkill());
    }

    private void Update()
    {
        while (canSpawn)
        {
            int objectSpawn = Random.Range(0, objectToSpawn.Length);
            SpawnObjectInRawImage(objectSpawn);
            canSpawn = false;
        }
    }

    private IEnumerator SpawnTime()
    {
        while (true)
        {
            int time = Random.Range(1, 4);
            yield return new WaitForSeconds(time);
            canSpawn = true;
        }
    }
    
    private IEnumerator SpawnSkill()
    {
        while (true)
        {
            int time = Random.Range(5, 10);
            yield return new WaitForSeconds(time);
            int index = Random.Range(0, Skills.Length);
            SpawnSkill(index);
        }
    }

    public void SpawnObjectInRawImage(int randomItem)
    {
        RectTransform rawImageRect = rawImage.GetComponent<RectTransform>();

        // Lấy tọa độ và kích thước của RawImage
        Vector2 rawImageSize = rawImageRect.sizeDelta;
        Vector3 rawImagePos = rawImageRect.position;

        // Tính toán giới hạn vị trí để đối tượng không spawn ra ngoài RawImage
        float minX = rawImagePos.x - rawImageSize.x / 2;
        float maxX = rawImagePos.x + rawImageSize.x / 2;
        float minY = rawImagePos.y - rawImageSize.y / 2;
        float maxY = rawImagePos.y + rawImageSize.y / 2;

        // Tạo vị trí spawn ngẫu nhiên trong giới hạn của RawImage
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Tạo đối tượng tại vị trí được tính toán
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        // Spawn đối tượng
        Instantiate(objectToSpawn[randomItem], spawnPosition, Quaternion.identity, rawImage.transform);
    }

    public void SpawnSkill(int randomItem)
    {
        RectTransform rawImageRect = rawImage.GetComponent<RectTransform>();

        // Lấy tọa độ và kích thước của RawImage
        Vector2 rawImageSize = rawImageRect.sizeDelta;
        Vector3 rawImagePos = rawImageRect.position;

        // Tính toán giới hạn vị trí để đối tượng không spawn ra ngoài RawImage
        float minX = rawImagePos.x - rawImageSize.x / 2;
        float maxX = rawImagePos.x + rawImageSize.x / 2;
        float minY = rawImagePos.y - rawImageSize.y / 2;
        float maxY = rawImagePos.y + rawImageSize.y / 2;

        // Tạo vị trí spawn ngẫu nhiên trong giới hạn của RawImage
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Tạo đối tượng tại vị trí được tính toán
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        // Spawn đối tượng
        Instantiate(Skills[randomItem], spawnPosition, Quaternion.identity, rawImage.transform);
    }
}
