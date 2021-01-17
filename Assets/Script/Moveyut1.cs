using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moveyut1 : MonoBehaviour
{
    public GameObject yut1;
    public List<int> resultYut;
    float rotSpeed = 20.0f;
    public bool isButton = false;
    bool isRotate = false;
    float t = 0;
    int turn = 0;
    int res;

    // Start is called before the first frame update
    void Start()
    {
        yut1 = gameObject;
        resultYut = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {
        isButton = true;
    }

    private void FixedUpdate()
    {
        if (!isRotate)
        {
            isRotate = true;
            do {
                RotateYut();
            } while (res == 15 || res == 16);
            isRotate = false;

            if (isButton)
            {
                switch (turn)
                {
                    case 0:
                        GameObject.Find("player1").GetComponent<MapButton>().getResult(resultYut);
                        turn = 1;
                        break;
                    case 1:
                        GameObject.Find("player2").GetComponent<MapButton>().getResult(resultYut);
                        turn = 0;
                        break;
                    default:
                        Debug.LogError("Wrong Turn");
                        break;
                }
                resultYut.Clear();
                isButton = false;

                Debug.Log("after clear - count: " + resultYut.Count);
            }
        }
    }

    void RotateYut()
    {
        if (!isButton)
            return;

        GameObject.Find("yut2").GetComponent<Moveyut2>().RotateYut();
        GameObject.Find("yut3").GetComponent<Moveyut3>().RotateYut();
        GameObject.Find("yut4").GetComponent<Moveyut4>().RotateYut();
        for (int i = 0; i < 500000; i++)
            transform.Rotate(Vector3.up * rotSpeed);

        // show yuts
        changeImage();
    }
    

    void changeImage()
    {
        transform.localEulerAngles = new Vector3(-18, 7, 167);

        // calc result
        System.Random r = new System.Random();
        res = r.Next(1, 17);
        Debug.Log("play yut: " + res);
        resultYut.Add(res);
        if (res != 16 && res != 4) //도 개 걸 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut2");
        else // 도' 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
        GameObject.Find("yut2").GetComponent<Moveyut2>().setResult(res);
        GameObject.Find("yut3").GetComponent<Moveyut3>().setResult(res);
        GameObject.Find("yut4").GetComponent<Moveyut4>().setResult(res);
    }
}
