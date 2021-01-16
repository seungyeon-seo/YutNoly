using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    DictionaryClass dict;
    bool isReady = false;
    
    // Start is called before the first frame update
    void Start()
    {        
        dict = new DictionaryClass();
        StartPos(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isReady = true;
            Debug.Log("button down");
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isReady == false)
            return;

        MoveTo(gameObject, 1);
    }

    void MoveTo(GameObject a, int numberPressed)
    {
        Vector2 wasPos = a.transform.position;
        int pos = dict.GetPos(wasPos);
        if (pos < 0)
        {
            Debug.Log("Error no Position! "+wasPos.ToString());
            return;
        }
        Debug.Log("current position is " + wasPos.ToString());

        Vector2 toPos = nextToMove(pos, numberPressed);
        Debug.Log("update position is "+ toPos.ToString());

        a.transform.position = Vector2.Lerp(wasPos, toPos, 3);
        isReady = false;

        Debug.Log("move is done: " + a.transform.position.ToString());
    }

    void StartPos(GameObject a)
    {
        a.transform.position = dict.Kans[0];
        Debug.Log("position is " + dict.Kans[0].ToString());
    }

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

            Vector2 a = new Vector2(-5.22f, -1.72f);
            Kans.Add(0, a);
            Kans.Add(1, new Vector2(-5.22f, -0.18f));
            Kans.Add(2, new Vector2(-5.22f, 1.31f));
            Kans.Add(3, new Vector2(-5.22f, 2.8f));
            Kans.Add(4, new Vector2(-5.22f, 4.24f));
            Kans.Add(5, new Vector2(6.28f, 5.85f));
            Kans.Add(6, new Vector2(4.54f, 5.85f));
            Kans.Add(7, new Vector2(3f, 5.85f));
            Kans.Add(8, new Vector2(1.46f, 5.85f));
            Kans.Add(9, new Vector2(-0.05f, 5.85f));
            Kans.Add(10, new Vector2(-1.82f, 5.85f));
            Kans.Add(11, new Vector2(-1.82f, 4.41f));
            Kans.Add(12, new Vector2(-1.82f, 2.92f));
            Kans.Add(13, new Vector2(-1.82f, 1.46f));
            Kans.Add(14, new Vector2(-1.82f,-0.03f));
            Kans.Add(15, new Vector2(-1.82f, -1.54f));
            Kans.Add(16, new Vector2(-0.05f, -1.54f));
            Kans.Add(17, new Vector2(1.46f, -1.54f));
            Kans.Add(18, new Vector2(3f, -1.54f));
            Kans.Add(19, new Vector2(4.51f, -1.54f));
            Kans.Add(20, new Vector2(6.28f, -1.54f));


            Kans.Add(21, new Vector2(3.8f, 0.6f));
            Kans.Add(22, new Vector2(3.8f, 0.6f));
            Kans.Add(23, new Vector2(3.8f, 0.6f));
            Kans.Add(24, new Vector2(3.8f, 0.6f));
            Kans.Add(25, new Vector2(3.8f, 0.6f));
            Kans.Add(26, new Vector2(3.8f, 0.6f));
            Kans.Add(27, new Vector2(3.8f, 0.6f));
            Kans.Add(28, new Vector2(3.8f, 0.6f));
            Kans.Add(29, new Vector2(3.8f, 0.6f));
        }


        public int GetPos(Vector2 vector)
        {
            for (int i = 0; i < Kans.Count; i++)
            {
                if (Kans[i] == vector)
                    return i;  
            }
            return -1;
        }
    }

    private Vector2 nextToMove(int wasPos, int number)
    {
        if (wasPos != 19)
            return dict.Kans[wasPos + number];

        else if (wasPos == 5) // 모에 와서 안으로 꺾어질 때 
            return dict.Kans[wasPos * 4 + number];

        //else if (wasPos == 23) // 정가운데 
            

        else
            return new Vector2(-0.15f, 0.7f);
    }

    public void OnClickButton()
    {

        return;
    }

}
