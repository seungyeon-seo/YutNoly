using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moveyut3 : MonoBehaviour
{
    public GameObject yut3;
    float rotSpeed = 20.0f;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        yut3 = gameObject;
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

        if ((res >= 11 && res <= 14) || res == 15) // 걸 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut2");
        else // 도 도' 개 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
    }

}
