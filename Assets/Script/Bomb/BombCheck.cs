using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCheck : MonoBehaviour
{
    public bool isBomb = false;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject.Find("Kan_1").GetComponent<initBombKans>().increment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setIsBomb(bool input)
    {
        isBomb = input;
    }
}
