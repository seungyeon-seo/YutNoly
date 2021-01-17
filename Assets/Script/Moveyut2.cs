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
        isButton = true;
    }

    private void FixedUpdate()
    {
    }

    public void RotateYut()
    {
        for (int i = 0; i < 500; i++)
            transform.Rotate(Vector3.up * rotSpeed);
    }

    public void setResult(int res)
    {
        transform.localEulerAngles = new Vector3(-18, 7, 167);

        if ((res >= 5 && res <= 10) || (res >= 11 && res <= 14) || res == 15) // 개 걸 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut2");
        else // 도 도' 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
    }

}
