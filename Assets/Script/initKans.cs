using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initKans : MonoBehaviour
{
    public List<GameObject> Kans;
    

    // Start is called before the first frame update
    void Start()
    {
        Kans = new List<GameObject>();
        for (int i = 0; i < 31; i++)
        {
            GameObject obj1 = GameObject.Find("Kan_" + i.ToString());
            /*if (obj1.GetComponent<SpriteRenderer>() != null)
            {
                Debug.Log("has Renderer");
                obj1.GetComponent<SpriteRenderer>().enabled = false;
            }*/
            Kans.Add(obj1);
            GameObject.Find("Kan_" + i.ToString()).SetActive(false);
        }

        GameObject.Find("player1_1").GetComponent<MapButton>().initKans(Kans);
        GameObject.Find("player1_2").GetComponent<MapButton>().initKans(Kans);
        GameObject.Find("player1_3").GetComponent<MapButton>().initKans(Kans);
        GameObject.Find("player1_4").GetComponent<MapButton>().initKans(Kans);
        GameObject.Find("player2_1").GetComponent<MapButton>().initKans(Kans);
        GameObject.Find("player2_2").GetComponent<MapButton>().initKans(Kans);
        GameObject.Find("player2_3").GetComponent<MapButton>().initKans(Kans);
        GameObject.Find("player2_4").GetComponent<MapButton>().initKans(Kans);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
