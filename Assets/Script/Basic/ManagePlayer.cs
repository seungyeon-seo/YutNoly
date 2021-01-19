using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlayer : MonoBehaviour
{
    int owner;
    List<GameObject> players;
    List<GameObject> winners;
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

        winners = new List<GameObject>();
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
            yutInfo.Clear();
        }
        isClick = false;
        isReady = false;
    }

    List<GameObject> getMovable()
    {
        List<GameObject> res = new List<GameObject>();
        bool check = false;
       
        foreach (GameObject player in players)
        {
            if (player.GetComponent<MapButton>().getPosition() != 0)
            {
                res.Add(player);
            }
            else
            {
                if (!check)
                {
                    res.Add(player);
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
        isReady = true;
    }

    public void checkPos(GameObject obj1, int turn)
    {
        int pos = obj1.GetComponent<MapButton>().getPosition();
        foreach (GameObject obj in getOtherPlayers())
        {
            if (pos == obj.GetComponent<MapButton>().getPosition())
            {
                Debug.Log("catch!");
                obj.GetComponent<MapButton>().setPosition(0);
                clearAttach(obj);
                obj.GetComponent<MapButton>().catchOther(turn);
                GameObject.Find("infoText").GetComponent<InfoText>().setImage(2);
            }
        }

        List<GameObject> attacher = new List<GameObject>();
        foreach (GameObject obj2 in players)
        {
            if (pos == obj2.GetComponent<MapButton>().getPosition() && !obj1.Equals(obj2))
            {
                if (!isAttacher(obj1, obj2))
                {
                    countAttach(obj1, attacher);
                    Debug.Log("ATTACH " + obj1.name + " with " + obj2.name + " position: " + pos + obj2.GetComponent<MapButton>().getPosition());
                    countAttach(obj2, attacher);
                    obj1.GetComponent<MapButton>().attach(obj2);
                    Debug.Log(obj1.name + " call attach1");
                    obj2.GetComponent<MapButton>().attach(obj1);
                    Debug.Log(obj2.name + " call attach2");
                }
            }
        }
        setAttachImage(attacher);
    }

    void countAttach(GameObject obj, List<GameObject> count)
    {
        if (!count.Contains(obj))
            count.Add(obj);
        foreach (GameObject oj in obj.GetComponent<MapButton>().getAttach())
        {
            if (!count.Contains(oj))
                count.Add(oj);
        }
    }

    void setAttachImage(List<GameObject> attacher)
    {
        string[] separatingStrings = { "player1_", "player2_" };
        string type = null;
        switch (owner)
        {
            case 1:
                type = "boy";
                break;
            case 2:
                type = "girl";
                break;
        }
        foreach (GameObject obj in attacher)
        {
            string[] str = obj.name.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            GameObject.Find(type + "charac" + str[0]).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(type + attacher.Count);
        }
    }

    bool isAttacher(GameObject obj1, GameObject obj2)
    {
        return obj1.GetComponent<MapButton>().getAttach().Contains(obj2);
    }

    void clearAttach(GameObject obj)
    {
        Debug.Log("CLEAR");
        List<GameObject> att = obj.GetComponent<MapButton>().getAttach();
        obj.GetComponent<MapButton>().clearAttach();
        foreach (GameObject oj in att)
        {
            oj.GetComponent<MapButton>().clearAttach();
        }
    }

    List<GameObject> getOtherPlayers()
    {
        if (owner == 1)
        {
            return GameObject.Find("player2_1").GetComponent<ManagePlayer>().getPlayers();
        }
        else
        {
            return GameObject.Find("player1_1").GetComponent<ManagePlayer>().getPlayers();
        }
    }

    public List<GameObject> getPlayers()
    {
        return players;
    }

    public void AddWinner(GameObject win)
    {
        winners.Add(win); 
        players.Remove(win);
        setImageNull(win);

        List<GameObject> att = win.GetComponent<MapButton>().getAttach();
        foreach (GameObject obj in att)
        {
            winners.Add(obj);
            players.Remove(obj);
            setImageNull(obj);
        }

        if (winners.Count == 4)
        {
            Debug.Log("player" + owner + " is WIN!!");
        }
    }

    void setImageNull(GameObject obj)
    {
        string[] separatingStrings = { "player1_", "player2_" };
        string[] str = obj.name.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
        string type = null;
        switch (owner)
        {
            case 1:
                type = "boy";
                break;
            case 2:
                type = "girl";
                break;
        }
        GameObject.Find(type + "charac" + str[0]).GetComponent<SpriteRenderer>().sprite = null;
    }
}
