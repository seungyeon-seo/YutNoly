using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BombYut1 : MonoBehaviour
{
    public GameObject yut1;
    GameObject yutResultObj;
    public List<int> resultYut;
    int res = -1;
    float rotSpeed = 20.0f;
    public bool isClicked = false;
    bool isRotate = false;
    bool doneTurn = false;
    float t = 0;
    int turn = 1;
    private bool isSet;

    // Start is called before the first frame update
    void Start()
    {
        yutResultObj = GameObject.Find("yutResult");
        yut1 = gameObject;
        resultYut = new List<int>();
        GameObject.Find("WinView").GetComponent<SpriteRenderer>().sprite = null;
        GameObject.Find("turn2").GetComponent<SpriteRenderer>().sprite = null;
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
            case 1:
                Debug.Log("boy's turn");
                GameObject.Find("player1").GetComponent<MovePlayer>().getResult(resultYut);
                turn = 2;
                break;
            case 2:
                Debug.Log("girl's turn");
                GameObject.Find("player2").GetComponent<MovePlayer>().getResult(resultYut);
                turn = 1;
                break;
        }
        resultYut.Clear();
    }
    void RotateYut()
    {
        isRotate = true;
        GameObject.Find("infoText").GetComponent<InfoText>().resetImage();
        GameObject.Find("yut2").GetComponent<Bombyut2>().RotateYut();
        GameObject.Find("yut3").GetComponent<Bombyut3>().RotateYut();
        GameObject.Find("yut4").GetComponent<Bombyut4>().RotateYut();
        GameObject.Find("yut5").GetComponent<Bombyut5>().RotateYut();
        yutResultObj.GetComponent<showResult>().setEmpty();
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
        yutResultObj.GetComponent<showResult>().setImage(res);
        if (res != 16 && res != 4) //도 개 걸 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut2");
        else // 도' 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
        if (res == 15 || res == 16)
            GameObject.Find("infoText").GetComponent<InfoText>().setImage(1);
    }
    public void callDoOneTurn(int t, List<int> res)
    {
        resultYut = res;
        turn = t;
    }

    public void setTurnImage()
    {
        GameObject.Find("turn" + turn).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("highlight");
        if (turn == 1)
            GameObject.Find("turn2").GetComponent<SpriteRenderer>().sprite = null;
        else
            GameObject.Find("turn1").GetComponent<SpriteRenderer>().sprite = null;
    }

    public void setTurnImage2()
    {
        if (turn == 1)
            turn = 2;
        else
            turn = 1;
        setTurnImage();
    }
}