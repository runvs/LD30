using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () 
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

        if (units.Length == 0)
        {
            ResetGame();
        }
    
    }

    public void ResetGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        Destroy(GameObject.FindGameObjectWithTag("bgm"));
        Destroy(GameObject.FindGameObjectWithTag("StoryManager"));

        //Application.LoadLevel("Menu");
    }
}
