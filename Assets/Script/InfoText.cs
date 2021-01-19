using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoText : MonoBehaviour
{
    GameObject anim;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        anim = GameObject.Find("animation");
        anim.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setImage(int type)
    {
        anim.SetActive(true);
        switch(type)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("oneMoreText");
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("catchText");
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bombText");
                break;
        }
    }

    public void resetImage()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        anim.SetActive(false);
    }
}
