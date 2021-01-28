using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string str;
        if (gameObject.name == "Player_1 Text")
            str = getBoyName.input;
        else
            str = getGirlName.input;
        GetComponent<Text>().text = str;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
