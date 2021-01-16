using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    GameObject obj2 = null;
    bool isReady;
    bool isClick;
    List<(int, GameObject)> resYut;
    List<GameObject> activeKans;
    int PlayerPos;
    Vector2 mousePos2D;
    List<GameObject> Kans;
    int NextPos = -1;

    // Start is called before the first frame update
    void Start()
    {   
        isReady = false;
        isClick = false;
        activeKans = new List<GameObject>();
        resYut = new List<(int, GameObject)>();
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
            PlayerPos = NextPos;
            Debug.Log("after moving: " + PlayerPos);
        }

        else // isReady만 true
        {
            showButton();
        }
    }

    void moveTo()
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            Vector2 a = hit.collider.gameObject.transform.position;
            Vector2 b = obj2.transform.position;
            obj2.transform.position = Vector2.Lerp(b, a, 10);
            //hit.collider.gameObject.SetActive(false);
            unableKans();
            deleteKan(hit.collider.gameObject);
            if (resYut.Count == 0)
                isReady = false;
            isClick = false;
        }
        else
            Debug.LogError("hit.collider is null");
    }

    public void getResult(List<int> res)
    {
        isReady = true;
        Debug.Log("res count: " + res.Count.ToString());
        for (int i = 0; i < res.Count; i++)
        {
            switch (res[i])
            {
                case 1:
                case 2:
                case 3:
                    NextPos = calcNextPos(PlayerPos, 1);
                    resYut.Add((1, Kans[NextPos]));
                    break;
                case 4:
                    NextPos = calcNextPos(PlayerPos, -1);
                    resYut.Add((-1, Kans[NextPos])); break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    NextPos = calcNextPos(PlayerPos, 2);
                    resYut.Add((2, Kans[NextPos])); break;
                case 11:
                case 12:
                case 13:
                case 14:
                    NextPos = calcNextPos(PlayerPos, 3);
                    resYut.Add((3, Kans[NextPos])); break;
                case 15:
                    NextPos = calcNextPos(PlayerPos, 4);
                    resYut.Add((4, Kans[NextPos])); break;
                case 16:
                    NextPos = calcNextPos(PlayerPos, 5);
                    resYut.Add((5, Kans[NextPos])); break;
                default:
                    Debug.LogError("Get Wrong result from moveYut1");
                    break;
            }
        }
        Debug.Log("resYut count: " + resYut.Count);
    }

    public int calcNextPos(int PlayerPos, int res)
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
                NextPos = CurPos * 4 + res;
                break;
            case 10: // 두번째 꼭짓점
                if (res != 3 && res <= 5)
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

    public void showButton()
    {
        for (int i = 0; i < resYut.Count; i++)
        {
            resYut[i].Item2.SetActive(true);
            //string NextPosName = "Kan_" + nextPos.ToString();
            //Kans[nextPos].SetActive(true);
            //activeKans.Add(Kans[nextPos]);
        }
    }

    public void initKans(List<GameObject> kans)
    {
        Kans = kans;
        obj2 = gameObject;
        GameObject startobj = Kans[0];
        obj2.transform.position = startobj.transform.position;
    }

    void unableKans()
    {
        int count = resYut.Count;
        for (int i = 0; i<count; i++)
        {
            resYut[i].Item2.SetActive(false);
        }
    }

    void deleteKan(GameObject toDelete)
    {
        int count = resYut.Count;
        for (int i = 0; i < count; i++)
        {
            if (toDelete.Equals(resYut[i].Item2))
            {
                resYut.Remove(resYut[i]);
                return;
            }
        }
        Debug.LogError("Failed to delete");
    }
}
