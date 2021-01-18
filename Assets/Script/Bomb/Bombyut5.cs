using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombyut5 : MonoBehaviour
{
    bool isRotate;
    float rotSpeed = 20.0f;
    float t = 0;
    public bool bomb;

    // Start is called before the first frame update
    void Start()
    {
        isRotate = false;
        bomb = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isRotate)
        {
            transform.Rotate(Vector3.up * rotSpeed);
            t += Time.deltaTime;
            if (t >= Time.deltaTime * 50)
            {
                isRotate = false;
                t = 0;
            }
        }
    }

    public void RotateYut()
    {
        isRotate = true;
    }

    public void changeImage()
    {
        transform.localEulerAngles = new Vector3(-18, 7, 167);

        System.Random r = new System.Random();
        int res = r.Next(1, 3);

        if (res == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
            bomb = false;
        }
        else if (res == 2) // set bomb
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut4");
            bomb = true;
        }

    }
}
