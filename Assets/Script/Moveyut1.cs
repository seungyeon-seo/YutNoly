using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moveyut1 : MonoBehaviour
{
    public GameObject yut1;
    public int resultYut = -1;
    float rotSpeed = 20.0f;
    public bool isButton = false;
    float t = 0;
    int turn = 0;

    // Start is called before the first frame update
    void Start()
    {
        yut1 = gameObject;
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
            switch (turn)
            {
                case 0:
                    GameObject.Find("player1").GetComponent<MoveToward>().getResult(resultYut);
                    turn = 1;
                    break;
                case 1:
                    GameObject.Find("player2").GetComponent<MoveToward>().getResult(resultYut);
                    turn = 0;
                    break;
                default:
                    Debug.LogError("Wrong Turn");
                    break;
            }
            
            resultYut = 0;
        }
    }

    void changeImage()
    {
        transform.localEulerAngles = new Vector3(-18, 7, 167);

        // calc result
        System.Random r = new System.Random();
        resultYut = r.Next(1, 17);
        if (resultYut != 16 && resultYut != 4) //도 개 걸 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut2");
        else // 도' 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
    }
}
