using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    GameObject obj1 = null;
    GameObject obj2 = null;
    // Start is called before the first frame update
    void Start()
    {   
        obj1 = GameObject.Find("Kan_1");
        obj2 = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {   Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                Vector2 a = hit.collider.gameObject.transform.position;
                Vector2 b = obj2.transform.position;
                obj2.transform.position = Vector2.Lerp(b, a, 10);
            }
        }
    }
}
