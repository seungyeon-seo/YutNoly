using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BombYut1 : MonoBehaviour
{
    public GameObject yut1;
    public List<int> resultYut;
    int res = -1;
    float rotSpeed = 20.0f;
    public bool isClicked = false;
    bool isRotate = false;
    bool doneTurn = false;
    float t = 0;
    int turn = 0;

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
        // isClicked = true;
        doOneTurn();
    }
    private void FixedUpdate()
    {
        if (isRotate)
        {
            transform.Rotate(Vector3.up * rotSpeed);
            t += Time.deltaTime;
            if (t >= Time.deltaTime * 50)
            {
                isRotate = false;
                t = 0;
                changeImage();
                resultYut.Add(res);
                if (res != 15 && res != 16)
                    doneTurn = true;
            }
        }
        if (doneTurn)
        {
            doneTurn = false;
            setResult();
        }
    }
    void doOneTurn()
    {
        RotateYut();
        // changeImage();
    }
    void setResult()
    {
        switch (turn)
        {
            case 0:
                Debug.Log("boy's turn");
                GameObject.Find("player1").GetComponent<MovePlayer>().getResult(resultYut);
                turn = 1;
                break;
            case 1:
                Debug.Log("girl's turn");
                GameObject.Find("player2").GetComponent<MovePlayer>().getResult(resultYut);
                turn = 0;
                break;
            default:
                Debug.LogError("Wrong Turn");
                break;
        }
        resultYut.Clear();
    }
    void RotateYut()
    {
        isRotate = true;
        GameObject.Find("yut2").GetComponent<Bombyut2>().RotateYut();
        GameObject.Find("yut3").GetComponent<Bombyut3>().RotateYut();
        GameObject.Find("yut4").GetComponent<Bombyut4>().RotateYut();
        GameObject.Find("yut5").GetComponent<Bombyut5>().RotateYut();
    }
    void changeImage()
    {
        transform.localEulerAngles = new Vector3(-18, 7, 167);
        // calc result
        System.Random r = new System.Random();
        res = r.Next(1, 17);
        GameObject.Find("yut2").GetComponent<Bombyut2>().changeImage(res);
        GameObject.Find("yut3").GetComponent<Bombyut3>().changeImage(res);
        GameObject.Find("yut4").GetComponent<Bombyut4>().changeImage(res);
        GameObject.Find("yut5").GetComponent<Bombyut5>().changeImage();
        if (res != 16 && res != 4) //도 개 걸 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut2");
        else // 도' 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");

    }
    public void callDoOneTurn(int t, List<int> res)
    {
        resultYut = res;
        turn = t;
    }
}