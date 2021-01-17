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
    List<GameObject> Kans;
    int UpdatePos = -1;

    // Start is called before the first frame update
    void Start()
    {   
        // init flags
        isReady = false;
        isClick = false;
        PlayerPos = 0;
        resYut = new List<(int, GameObject)>();
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
            unableKans();
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
                Debug.Log("update: " + PlayerPos);
                updateResult();
                haveToUpdate = false;
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

            // init flags
            isClick = false;
            moveToKan.SetActive(false);
            deleteKan(moveToKan);
        }
        else
            Debug.LogError("hit.collider is null");
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
                    //resYut.Add((1, null));
                    resYut.Add((1, Kans[calcNextPos(1)]));
                    break;
                case 4:
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
                if (res > 1)
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
        obj2.transform.position = startobj.transform.position;
    }
}
