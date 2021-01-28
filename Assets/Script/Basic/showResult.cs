using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showResult : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setEmpty()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    public void setImage(int res)
    {
        int result = translateRes(res);
        switch (result)
        {
            case -1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("res_back");
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("res_do");
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("res_gae");
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("res_gir");
                break;
            case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("res_yoot");
                break;
            case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("res_mo");
                break;
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
                break;
            default:
                break;
        }
    }

    int translateRes(int res)
    {
        if (res >= 1 && res <= 3)
            return 1;
        else if (res == 4)
            return -1;
        else if (res <= 10)
            return 2;
        else if (res <= 14)
            return 3;
        else if (res == 15)
            return 4;
        else if (res == 16)
            return 5;
        else
        {
            Debug.LogError("Wrong Result");
            return 0;
        }
    }
}
