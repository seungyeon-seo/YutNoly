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
        }
        GameObject.Find("player1").GetComponent<MovePlayer>().initKans(Kans);
        GameObject.Find("player2").GetComponent<MovePlayer>().initKans(Kans);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
