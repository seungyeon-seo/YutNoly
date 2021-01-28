using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombyut2 : MonoBehaviour
{
    public GameObject yut2;
    float rotSpeed = 20.0f;
    float t = 0;
    bool isRotate;

    // Start is called before the first frame update
    void Start()
    {
        yut2 = gameObject;
    }

    public void OnButtonClick()
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

    public void changeImage(int res)
    {
        transform.localEulerAngles = new Vector3(-18, 7, 167);

        // calc result
        if ((res >= 5 && res <= 10) || (res >= 11 && res <= 14) || res == 15) // 개 걸 윷
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut2");
        else // 도 도' 모
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yut1");
    }
}
