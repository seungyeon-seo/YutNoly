using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moveyut2 : MonoBehaviour
{
    public GameObject yut2;
    float rotSpeed = 20.0f;
    bool isButton = false;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        yut2 = gameObject;
    }

    public void OnButtonClick()
    {
        Debug.Log("Button Click2");
        isButton = true;
    }

    private void FixedUpdate()
    {
        RotateYut();
    }

    void RotateYut()
    {
        if (!isButton)
            return;

        transform.Rotate(Vector3.up * rotSpeed);
        t += Time.deltaTime;

        if (t >= Time.deltaTime * 50)
        {
            // init variables
            isButton = false;
            t = 0;

            // show yuts
            changeImage();
        }
    }

    void changeImage()
    {
        transform.localEulerAngles = new Vector3(-18, 7, 167);

        // calc result
        System.Random r = new System.Random();
        int res = r.Next(1, 17);
        if ((res>=5 && res<=10) || (res>=11 && res<=14) || res == 15) // 개 걸 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut2");
        else // 도 도' 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
    }

}
