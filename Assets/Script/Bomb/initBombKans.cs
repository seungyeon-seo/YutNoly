using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initBombKans : MonoBehaviour
{
    public List<GameObject> Kans;
    
    // Start is called before the first frame update
    void Start()
    {   
        Kans = new List<GameObject>();
        for (int i = 0; i < 31; i++)
        {
            GameObject obj1 = GameObject.Find("Kan_" + i.ToString());
            Kans.Add(obj1);
            GameObject.Find("show_kan" + i.ToString()).GetComponent<SpriteRenderer>().sprite = null;
            GameObject.Find("bomb" + i.ToString()).GetComponent<SpriteRenderer>().sprite = null;
        }
        
        setBombs();
        
        GameObject.Find("player1").GetComponent<MovePlayer>().initKans(Kans);
        GameObject.Find("player2").GetComponent<MovePlayer>().initKans(Kans);
    }

    void setBombs()
    {
        System.Random r = new System.Random();
        for (int i = 0; i < 5; i++)
        {
            int res = r.Next(1, 30);
            Kans[res].GetComponent<BombCheck>().isBomb = true;
            GameObject.Find("bomb" + res).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bomb");
        }
    }
}
