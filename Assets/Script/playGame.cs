using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class playGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickBasicButton()
    {
        SceneManager.LoadScene("BasicYut");
    }

    public void clickBombButton()
    {
        SceneManager.LoadScene("BombYut");
    }

}
