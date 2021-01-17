using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moveyut4 : MonoBehaviour
{
    public GameObject yut4;
    float rotSpeed = 20.0f;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        yut4 = gameObject;
    }

    public void OnButtonClick()
    {
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

        if (res == 15 || res == 4) // 도' 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut3");
        else // 도 개 걸 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
    }
}
