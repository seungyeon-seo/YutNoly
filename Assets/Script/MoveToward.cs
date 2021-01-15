using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    DictionaryClass dict;
    bool isReady = false;
    int numberPressed = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject("name");
        
        dict = new DictionaryClass();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*     while (true)
             {*/

        /*for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                numberPressed = i;
                isReady = true;
                Debug.Log("get number "+ i.ToString());
                break;
            }
        }*/
        if (Input.GetMouseButtonDown(0))
        {
            numberPressed = 1;
            isReady = true;
            Debug.Log("button down");
        }

        if (isReady == true)
        {
            //int numberPressed = 0;
            /*for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    numberPressed = i;
                    Debug.Log("get number");
                    break;
                }
            }*/
            MoveTo(gameObject, numberPressed);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("hi");
                Application.Quit();
            }
            /*break;*/
            /*}*/
        }
    }

    void MoveTo(GameObject a, int numberPressed)
    {
/*        float count = 0;*/
        Vector2 wasPos = a.transform.position;
        /*        float frameSize = 1.4f;*/
        if (dict.GetPos(wasPos) < 0)
            Debug.Log("Error no Position!");
        int toStep = dict.GetPos(wasPos) + numberPressed;
        Vector2 toPos = dict.Kans[toStep];
        Debug.Log("move to!"+ toStep.ToString());
        a.transform.position = Vector2.Lerp(wasPos, toPos, 3);
        isReady = false;
        /*Vector2 moveUp = frameSize * Vector2.up;*/

/*        while(count < numberPressed)
            {
                a.transform.position = Vector2.Lerp(wasPos, wasPos + moveUp, 3);
                count += 1;
            wasPos = a.transform.position;
            }*/
        
    }


/*    string FindPos(GameObject a, DictionaryClass dict)
    {
        a.transform.position
        
    }*/

    private KeyCode[] keyCodes =
    {
        KeyCode.Alpha0,
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

    public class DictionaryClass
    {
        public Dictionary<int, Vector2> Kans;
        /*private Dictionary<string, Vector2> dict;*/

        public DictionaryClass()
        {
            Kans = new Dictionary<int, Vector2>();

            Vector2 a = new Vector2(-2.2f, 0.7f);
            Kans.Add(0, a);
            Kans.Add(1, new Vector2(-2.2f, 2.2f));
            Kans.Add(2, new Vector2(-2.24f, 3.63f));
            Kans.Add(3, new Vector2(-2.24f, 5.16f));
            Kans.Add(4, new Vector2(-2.24f, 6.69f));
            Kans.Add(5, new Vector2(-2.24f, 8.09f));
            /*Vector2 a = new Vector2(3.3f, -4.0f);
            Kans.Add(0, a);
            Kans.Add(1, new Vector2(3.3f, -2.5f));
            Kans.Add(2, new Vector2(3.3f, -1.0f));
            Kans.Add(3, new Vector2(3.3f, 0.5f));
            Kans.Add(4, new Vector2(3.3f, 2.0f));
            Kans.Add(5, new Vector2(3.3f, 3.3f));*/
            Kans.Add(6, new Vector2(1.53f, 3.45f));
            Kans.Add(7, new Vector2(0.03f, 3.45f));
            Kans.Add(8, new Vector2(-1.53f, 3.45f));
            Kans.Add(9, new Vector2(-3.03f, 3.45f));
            Kans.Add(10, new Vector2(-4.77f, 3.45f));
            Kans.Add(11, new Vector2(-4.77f, 2.04f));
            Kans.Add(12, new Vector2(-4.77f, 0.55f));
            Kans.Add(13, new Vector2(-4.77f, -0.96f));
            Kans.Add(14, new Vector2(-4.77f, -2.47f));
            Kans.Add(15, new Vector2(-4.77f, -3.93f));
            Kans.Add(16, new Vector2(-3.03f, -3.93f));
            Kans.Add(17, new Vector2(-1.53f, -3.93f));
            Kans.Add(18, new Vector2(0.03f, -3.93f));
            Kans.Add(19, new Vector2(1.53f, -3.93f));
            Kans.Add(20, new Vector2(3.3f, 3.93f));


          /*  Kans.Add("21", new Vector2(3.8f, 0.6f));
            Kans.Add("22", new Vector2(3.8f, 0.6f));
            Kans.Add("23", new Vector2(3.8f, 0.6f));
            Kans.Add("24", new Vector2(3.8f, 0.6f));
            Kans.Add("25", new Vector2(3.8f, 0.6f));
            Kans.Add("26", new Vector2(3.8f, 0.6f));
            Kans.Add("27", new Vector2(3.8f, 0.6f));
            Kans.Add("28", new Vector2(3.8f, 0.6f));
            Kans.Add("29", new Vector2(3.8f, 0.6f));*/
        }


        public int GetPos(Vector2 vector)
        {
            Debug.Log("GetPos function start");
            for (int i = 0; i < Kans.Count; i++)
            {
                if (Kans[i] == vector)
                    return i;  
            }
            Debug.Log("in GetPos " +vector.ToString());
            return -1;
        }
    }
}
