using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moveyut4 : MonoBehaviour
{
    public GameObject yut4;
    float rotSpeed = 20.0f;
    bool isButton = false;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        yut4 = gameObject;
    }

    public void OnButtonClick()
    {
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
        }
    }

    public void setResult(int res)
    {
        transform.localEulerAngles = new Vector3(-18, 7, 167);

        if (res == 15 || res == 4) // 도' 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut3");
        else // 도 개 걸 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
    }
}
