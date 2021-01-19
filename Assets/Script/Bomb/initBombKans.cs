using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initBombKans : MonoBehaviour
{
    public List<GameObject> Kans;
    int Bombflag = 0;
    
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

    private void Update()
    {
        if (Bombflag == 30)
        {
            setBombs();
        }
    }

    void setBombs()
    {
        System.Random r = new System.Random();
        for (int i = 0; i < 7; i++)
        {
            int res = r.Next(1, 30);
            Kans[res].GetComponent<BombCheck>().setIsBomb(true);
            Debug.Log(Kans[res].name + " is set");
            // Kans[res].GetComponent<BombCheck>().isBomb = true;
            GameObject.Find("bomb" + res).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bomb");
        }
    }

    public void increment()
    {
        Bombflag++;
    }
}
