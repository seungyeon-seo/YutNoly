using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoView : MonoBehaviour
{
    int cur = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextPage()
    {
        cur++;
        switch (cur)
        {
            case 2:
            case 3:
            case 4:
                GameObject.Find("infoView").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info" + cur);
                break;
        }
    }
}
