using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moveyut4 : MonoBehaviour
{
    float rotSpeed = 20.0f;
    bool isButton = false;
    float t = 0;
    Sprite yutObject;
    Sprite yut2Image;

    // Start is called before the first frame update
    void Start()
    {
        yutObject = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isButton = true;
        }
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
        if (res == 15 || res == 4) // 도' 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut3");
        else // 도 개 걸 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
    }

}
