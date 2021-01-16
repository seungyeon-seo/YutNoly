using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    DictionaryClass dict;
    bool isReady = false;
    int resYut = 0;
    
    // Start is called before the first frame update
    void Start()
    {        
        dict = new DictionaryClass();
    }

    private void Update()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isReady == false)
            return;

        MoveTo(gameObject, resYut);
    }

    void MoveTo(GameObject a, int numberPressed)
    {
        Vector2 wasPos = a.transform.position;

        int pos = dict.GetPos(wasPos);
        if (pos < 0)
        {
            return;
        }
        Debug.Log("current position is " + wasPos.ToString());

        Vector2 toPos = nextToMove(pos, numberPressed);
        Debug.Log("update position is "+ toPos.ToString());

        a.transform.position = Vector2.Lerp(wasPos, toPos, 3);
        isReady = false;
        resYut = 0;

        Debug.Log("move is done: " + a.transform.position.ToString());
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

            Kans.Add(0, new Vector2(13.72f, 9.93f));
            Kans.Add(1, new Vector2(13.63f, 11.68f));
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
            for (int i = 0; i < Kans.Count; i++)
            {
                if (i == 0)
                {
                    Debug.Log("kan 0: "+Kans[0].ToString());
                    Debug.Log(Kans[0].x + ", " + Kans[0].y);
                    Debug.Log("cur pos: "+vector.ToString()); 
                    Debug.Log(vector.x + ", " + vector.y);
                }
                if (Kans[i].Equals(vector))
                {
                    Debug.Log("EQ");
                    return i;
                }
            }
            return -1;
        }
    }

    private Vector2 nextToMove(int wasPos, int number)
    {
        return dict.Kans[wasPos + number];
    }

   
}
