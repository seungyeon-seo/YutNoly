using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    GameObject obj1 = null;
    GameObject obj2 = null;
    bool isReady;
    bool isClick;
    int resYut = 0;
    int PlayerPos;
    Vector2 mousePos2D;
    List<GameObject> Kans;
    int NextPos = -1;

    // Start is called before the first frame update
    void Start()
    {   

        // init flags
        isReady = false;
        isClick = false;

        // move to start kan
        
        /*        for (int i = 0; i < 4; i++)
                {
                    PlayerPos.Add(0);
                }*/

        // set current pos of player
        PlayerPos = 0;

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
            if (NextPos == -1)
                Debug.LogError("move to - calc pos");
            PlayerPos = NextPos;
            NextPos = -1;
        }

        else // isReady만 true
        {
            Debug.Log("is ready is true (yut is played)");
            NextPos = calcNextPos(PlayerPos, resYut);
            showButton(NextPos);
        } 
    }

    void moveTo()
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            Vector2 a = hit.collider.gameObject.transform.position;
            Debug.Log("button pos: " + a.ToString());
            Vector2 b = obj2.transform.position;
            Debug.Log("player1 pos: " + b.ToString());
            obj2.transform.position = Vector2.Lerp(b, a, 10);
            hit.collider.gameObject.SetActive(false);
            isReady = false;
            isClick = false;
        }
        else
            Debug.LogError("hit.collider is null");
    }

    public void getResult(int res)
    {
        isReady = true;
        switch (res)
        {
            case 1:
            case 2:
            case 3:
                resYut = 1;
                break;
            case 4:
                resYut = -1;
                break;
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                resYut = 2;
                break;
            case 11:
            case 12:
            case 13:
            case 14:
                resYut = 3;
                break;
            case 15:
                resYut = 4;
                break;
            case 16:
                resYut = 5;
                break;
            default:
                resYut = 0;
                Debug.LogError("Get Wrong result from moveYut1");
                break;
        }
        Debug.Log("get result from move yut1: " + res + " " + resYut);
    }

    public int calcNextPos(int PlayerPos, int res)
    {
        int CurPos = PlayerPos;
        int NextPos = 0;
        switch (CurPos)
        {
            case 5: //첫번째 꼭짓점
                NextPos = CurPos * 4 + res;
                break;
            case 10: // 두번째 꼭짓점
                if (res != 3 && res <= 5)
                    NextPos = 24 + res;
                else if (res == 3)
                    NextPos = 23;
                else
                    NextPos = CurPos + res;
                break;

            case 20: // 종점
                if (res > 1)
                    NextPos = 100;
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
                    NextPos = 100;
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
                    NextPos = 100;
                else
                    NextPos = CurPos + res;
                break;
            case 28: // 제2대각선 4번째위치
                if (res == -1)
                    NextPos = 23;
                else if (res == 2)
                    NextPos = 20;
                else if (res > 2)
                    NextPos = 100;
                else
                    NextPos = CurPos + res;
                break;
            case 29: // 제2대각선 5번째 위치
                if (res >= 2)
                    NextPos = 100;
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

    public void showButton(int nextPos)
    {
        string NextPosName = "Kan_" + nextPos.ToString();
        Kans[nextPos].SetActive(true);
    }

    public void initKans(List<GameObject> kans)
    {
        Kans = kans;
        obj2 = gameObject;
        GameObject startobj = Kans[0];
        Debug.Log("StartPos: " + startobj.transform.position.ToString());
        obj2.transform.position = startobj.transform.position;
    }
}
