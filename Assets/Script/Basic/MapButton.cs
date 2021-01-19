using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    GameObject obj2 = null;
    bool isReady;
    bool isClick;
    bool haveToUpdate;
    List<(int, GameObject)> resYut;
    int PlayerPos;
    Vector2 mousePos2D;
    Vector2 initPos;
    List<GameObject> Kans;
    int UpdatePos = 0;
    int owner;
    List<GameObject> attachedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        // set type
        string[] separatingStrings = { "player", "_" };
        string[] str = gameObject.name.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
        owner = Int32.Parse(str[0]);

        // init flags
        isReady = false;
        isClick = false;
        PlayerPos = 0;
        resYut = new List<(int, GameObject)>();
        initPos = gameObject.transform.position;
        attachedPlayer = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: button's on click 이용해야함
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos2D = new Vector2(mousePos.x, mousePos.y);
            if (isReady)
                isClick = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isReady)
            return;

        else if (isReady && isClick)
        {
            moveTo();
            PlayerPos = UpdatePos;
            Debug.Log(gameObject.name + "'s position: " + PlayerPos);
            unableKans();
            checkPos();
            if (resYut.Count == 0)
            {
                isReady = false;
                return;
            }
            haveToUpdate = true;
        }

        else // isReady만 true
        {
            if (haveToUpdate)
            {
                // updateResult();
                callGetMal();
                haveToUpdate = false;
                isReady = false;
            }
            showButtons();
        } 
    }

    void moveTo()
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            // move to clicked kan
            Debug.Log(hit.collider.gameObject.name);
            GameObject moveToKan = hit.collider.gameObject;
            Vector2 clickedKan = moveToKan.transform.position;
            Vector2 myPos = gameObject.transform.position;
            obj2.transform.position = Vector2.Lerp(myPos, clickedKan, 10);

            // set UpdatePos
            string[] separatingStrings = { "Kan_" };
            string[] names = moveToKan.name.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            UpdatePos = Int32.Parse(names[0]);
            checkAttach(UpdatePos);

            //7 init flags
            if (UpdatePos == 30)
            {
                GameObject.Find("player" + owner + "_1").GetComponent<ManagePlayer>().AddWinner(gameObject);
            }
            isClick = false;
            moveToKan.SetActive(false);
            deleteKan(moveToKan);
        }
    }

    private void checkPos()
    {
        if (owner == 1)
        {
            GameObject.Find("player1_1").GetComponent<ManagePlayer>().checkPos(gameObject, 1);
        }
        else
        {
            GameObject.Find("player2_1").GetComponent<ManagePlayer>().checkPos(gameObject, 2);
        }
    }

    void checkAttach(int pos)
    {
        Debug.Log("update attachplayer's position " + attachedPlayer.Count);
        foreach (GameObject obj in attachedPlayer)
        {
            obj.GetComponent<MapButton>().setPosition(pos);
        }
    }

    public void catchOther(int turn)
    {
        List<int> res = new List<int>();
        int count = resYut.Count;
        for (int i = 0; i < count; i++)
        {
            res.Add(resYut[i].Item1);
        }
        haveToUpdate = false;

        GameObject.Find("yut").GetComponent<Moveyut1>().callDoOneTurn(turn, res);
    }

    public void attach(GameObject obj2)
    {
        attachedPlayer.Add(obj2);
        /*int count = attachedPlayer.Count + 1;
        string name = null;
        switch (owner)
        {
            case 1:
                name = "boy";
                break;
            case 2:
                name = "girl";
                break;
        }

        string[] separatingStrings = { "player1_", "player2_" };
        string[] str = gameObject.name.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
        Debug.Log(name + count + " image change");
        *//*
        foreach (GameObject player in attachedPlayer)
        {
            Debug.Log("in foreach about " + player.name);
            string[] obj_num = player.name.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            GameObject.Find(name + "charac" + obj_num[0]).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(name + count.ToString());
            Debug.Log("obj_num[0]: " + obj_num[0]);
        }*//*
        GameObject.Find(name + "charac" + str[0]).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(name + count.ToString());*/
    }

    public int getPosition()
    {
        return PlayerPos;
    }

    public void setPosition(int pos)
    {
        PlayerPos = pos;
        Vector2 from = gameObject.transform.position;
        Vector2 to;
        if (pos == 0)
            to = initPos;
        else
            to = Kans[pos].transform.position;
        gameObject.transform.position = Vector2.Lerp(from, to, 10);
    }

    public void getResult(List<int> res)
    {
        int count = res.Count;
        for (int i = 0; i < count; i++)
        {
            switch (res[i])
            {
                case 1:
                case 2:
                case 3:
                    resYut.Add((1, Kans[calcNextPos(1)]));
                    break;
                case 4:
                    if (PlayerPos != 0 || resYut.Count != 0)
                        resYut.Add((-1, Kans[calcNextPos(-1)]));
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    resYut.Add((2, Kans[calcNextPos(2)]));
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                    resYut.Add((3, Kans[calcNextPos(3)]));
                    break;
                case 15:
                    resYut.Add((4, Kans[calcNextPos(4)]));
                    break;
                case 16:
                    resYut.Add((5, Kans[calcNextPos(5)]));
                    break;
                default:
                    Debug.LogError("Get Wrong result from moveYut1");
                    break;
            }
            Debug.Log("get result from move yut1: " + res + " " + resYut);
        }
        if (resYut.Count != 0 || resYut.Count != 0)
            isReady = true;
    }

    void updateResult()
    {
        List<(int, GameObject)> update = new List<(int, GameObject)>();
        int count = resYut.Count;
        for (int i = 0; i <count; i++)
        {
            update.Add((resYut[i].Item1, Kans[calcNextPos(resYut[i].Item1)]));
        }
        resYut = update;
    }

    public int calcNextPos(int res)
    {
        int CurPos = PlayerPos;
        int NextPos = 0;
        switch (CurPos)
        {
            case 0:
                if (res == -1)
                    NextPos = CurPos;
                else
                    NextPos = CurPos + res;
                break;
            case 1:
                if (res == -1)
                    NextPos = 20;
                else
                    NextPos = CurPos + res;
                break;
            case 5: //첫번째 꼭짓점
                if (res == -1)
                    NextPos = CurPos + res;
                else
                    NextPos = CurPos * 4 + res;
                break;
            case 10: // 두번째 꼭짓점
                if (res != 3 && res <= 5 && res >0)
                    NextPos = 25 + res;
                else if (res == 3)
                    NextPos = 23;
                else
                    NextPos = CurPos + res;
                break;
            case 16:
                if (res >= 5)
                    NextPos = 30;
                else
                    NextPos = CurPos + res;
                break;
            case 17:
                if (res >= 4)
                    NextPos = 30;
                else
                    NextPos = CurPos + res;
                break;
            case 18:
                if (res >= 3)
                    NextPos = 30;
                else
                    NextPos = CurPos + res;
                break;
            case 19:
                if (res >= 2)
                    NextPos = 30;
                else
                    NextPos = CurPos + res;
                break;
            case 20: // 종점
                if (res >= 1)
                    NextPos = 30;
                else
                    NextPos = CurPos + res;
                break;
            case 21: // 제1대각선 1번째 위치
                if (res == 5)
                    NextPos = 15;

                else if (res == -1)
                    NextPos = 5;
                else
                    NextPos = CurPos + res;
                break;
            case 22: // 제1대각선 2번재 위치
                if (res >= 4)
                    NextPos = 11 + res;
                else
                    NextPos = CurPos + res;
                break;

            case 23: // 가운데
                if (res >= 4)
                    NextPos = 30;
                else if (res == -1)
                    NextPos = 27;
                else if (res < 3)
                    NextPos = 27 + res;
                else if (res == 3)
                    NextPos = 20;
                else
                    NextPos = CurPos + res;
                break;
            case 24: // 제1대각선 4번째 위치
                if (res >= 2)
                    NextPos = 13 + res;
                else
                    NextPos = CurPos + res;
                break;
            case 25: // 제1대각선 5번째 위치
                if (res >= 1)
                    NextPos = 14 + res;
                else
                    NextPos = CurPos + res;
                break;
            case 26: // 제 2대각선 1번째 위치
                if (res == 2)
                    NextPos = 23;
                else if (res == 5)
                    NextPos = 20;
                else if (res == -1)
                    NextPos = 10;
                else
                    NextPos = CurPos + res;
                break;
            case 27: // 제2대각선 2번째 위치
                if (res == 1)
                    NextPos = 23;
                else if (res <= 3 && res > 1)
                    NextPos = 26 + res;
                else if (res == 4)
                    NextPos = 20;
                else if (res == 5)
                    NextPos = 30;
                else
                    NextPos = CurPos + res;
                break;
            case 28: // 제2대각선 4번째위치
                if (res == -1)
                    NextPos = 23;
                else if (res == 2)
                    NextPos = 20;
                else if (res > 2)
                    NextPos = 30;
                else
                    NextPos = CurPos + res;
                break;
            case 29: // 제2대각선 5번째 위치
                if (res >= 2)
                    NextPos = 30;
                else if (res == 1)
                    NextPos = 20;
                else
                    NextPos = CurPos + res;
                break;

            default:
                NextPos = CurPos + res;
                break;

        }
        return NextPos;
    }

    void unableKans()
    {
        int count = resYut.Count;
        for (int i = 0; i < count; i++)
            resYut[i].Item2.SetActive(false);
    }

    void deleteKan(GameObject toDelete)
    {
        int count = resYut.Count;
        for (int i = 0; i < count; i++)
        {
            if (resYut[i].Item2.Equals(toDelete))
            {
                resYut.RemoveAt(i);
                return;
            }
        }
        Debug.LogError("Try to delete wrong Kan");
    }

    public void showButtons()
    {
        // Debug.Log("show Buttons in MapButton");
        int count = resYut.Count;
        for (int i = 0; i < count; i++)
        {
            resYut[i].Item2.SetActive(true);
        }
    }

    public void initKans(List<GameObject> kans)
    {
        Kans = kans;
        obj2 = gameObject;
        GameObject startobj = Kans[0];
       
        // obj2.transform.position = startobj.transform.position;
    }

    void callGetMal()
    {
        List<int> res = new List<int>();
        int count = resYut.Count;
        for (int i = 0; i<count; i++)
        {
            switch (resYut[i].Item1)
            {
                case -1:
                    res.Add(4);
                    break;
                case 1:
                    res.Add(1);
                    break;
                case 2:
                    res.Add(5);
                    break;
                case 3:
                    res.Add(14);
                    break;
                case 4:
                    res.Add(15);
                    break;
                case 5:
                    res.Add(16);
                    break;
                case 0:
                    Debug.LogError("resYut error in callGetMal");
                    break;
            }
        }
        resYut.Clear();
        GameObject.Find("player" + owner + "_1").GetComponent<ManagePlayer>().getMal(res);
    }

    public void clearAttach()
    {
        attachedPlayer.Clear();
        string[] separatingStrings = { "player1_", "player2_" };
        string[] str = gameObject.name.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
        switch (owner)
        {
            case 1:
                GameObject.Find("boycharac"+str[0]).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("new_boy_character");
                break;
            case 2:
                GameObject.Find("girlcharac" + str[0]).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("new_girl_character");
                break;
        }
    }

    public List<GameObject> getAttach()
    {
        return attachedPlayer;
    }
}
