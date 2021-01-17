using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    int owner;
    List<GameObject> players;
    Vector2 mousePos2D;
    bool isClick = false;
    bool isReady = false;
    List<int> yutInfo;

    // Start is called before the first frame update
    void Start()
    {
        // set type
        string[] separatingStrings = { "player", "_" };
        string[] str = gameObject.name.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
        owner = Int32.Parse(str[0]);
        yutInfo = new List<int>();

        // init players
        players = new List<GameObject>();
        players.Add(GameObject.Find("player" + owner + "_1"));
        players.Add(GameObject.Find("player" + owner + "_2"));
        players.Add(GameObject.Find("player" + owner + "_3"));
        players.Add(GameObject.Find("player" + owner + "_4"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isReady)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos2D = new Vector2(mousePos.x, mousePos.y);
            isClick = true;
        }
    }

    private void FixedUpdate()
    {
        getSelected();
    }

    void getSelected()
    {
        if (!isClick)
            return;

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            GameObject movingCharac = hit.collider.gameObject;
            movingCharac.GetComponent<MapButton>().getResult(yutInfo);
        }
        isClick = false;
        isReady = false;
    }

    List<GameObject> getMovable()
    {
        List<GameObject> res = new List<GameObject>();
        bool check = false;
        for (int i = 0; i < 4; i++)
        {
            if (players[i].GetComponent<MapButton>().getPosition() != 0)
            {
                res.Add(players[i]);
            }
            else
            {
                if (!check)
                {
                    res.Add(players[i]);
                    check = true;
                }
            }
        }
        return res;
    }

    public void getMal(List<int> yut)
    {
        for (int i = 0; i < yut.Count; i++)
            yutInfo.Add(yut[i]);
        List<GameObject> movable = getMovable();
        showEffect(movable);
        isReady = true;
    }

    void showEffect(List<GameObject> objs)
    {
        foreach (GameObject obj in objs)
        {
            // set active true
        }
    }
}
