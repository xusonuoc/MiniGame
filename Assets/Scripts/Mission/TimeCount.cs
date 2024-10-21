using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    private RectTransform image;
    public float timeRemaining;
    public float MaxTime = 5f;

    private float timeCounter = 0f;
    public float timeToReduceMaxTime = 5f;

    private float Width;

    public GameObject[] EndGame;

    private void Start()
    {
        timeRemaining = MaxTime;
        image = GetComponent<RectTransform>();

       
        Width = image.sizeDelta.x;
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            if (timeRemaining > MaxTime)
            {
                timeRemaining = MaxTime;
            }


            if (timeCounter >= timeToReduceMaxTime)
            {
                MaxTime -= 1; // Giảm MaxTime đi 5 đơn vị
                timeCounter = 0; // Đặt lại bộ đếm thời gian
            }
         

            // Giảm thời gian còn lại
            timeRemaining -= Time.deltaTime;
            timeCounter += Time.deltaTime;


            // Tính toán chiều rộng dựa trên tỷ lệ thời gian còn lại
            float newWidth = Width * timeRemaining / MaxTime;

            // Cập nhật kích thước của hình ảnh
            image.sizeDelta = new Vector2(newWidth, image.sizeDelta.y);
        }else
        {
            EndGame[0].SetActive(true);
            EndGame[1].SetActive(true);
        }    

       
    }
}


