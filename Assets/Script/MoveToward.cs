using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject("name");
    }

    // Update is called once per frame
    void Update()
    {
        /*while (true)
        {*/
            int numberPressed = 0;
            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    numberPressed = i + 1;
                    break;
                }
            }
            Vector3 wasPos = gameObject.transform.position;
            MoveTo(gameObject, numberPressed);
        if (Input.GetKeyDown(KeyCode.Return)) 
            Debug.Log("hi");
                /*break;*/
        /*}*/
    }

    void MoveTo(GameObject a, int numberPressed)
    {
        float count = 0;
        Vector3 wasPos = a.transform.position;

        while(count < numberPressed)
            {
                a.transform.position = Vector3.Lerp(wasPos, wasPos +Vector3.up, 3);
                count += 1;
            wasPos = a.transform.position;
            }
    }

    private KeyCode[] keyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };
}
