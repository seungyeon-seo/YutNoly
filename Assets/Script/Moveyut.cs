using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveyut : MonoBehaviour
{
    float rotSpeed = 20.0f;
    bool isButton = false;
    Rigidbody2D rigid;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isButton = true;
        }
    }

    private void FixedUpdate()
    {
        RotateYut();
    }

    void RotateYut()
    {
        if (!isButton)
            return; 
       
        transform.Rotate(Vector3.up * rotSpeed);
        t += Time.deltaTime;
      
        if (t >= Time.deltaTime * 50)
        {
            Debug.Log("Stop");
            isButton = false;
            t = 0;
        }
    }
}
