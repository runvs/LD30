using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Health;

    void Start()
    {
        this.gameObject.GetComponent<UnitScript>().Name
    }

    void Update()
    {
        if (Health <= 0.0f)
        {
            if (this.tag == "Player")
            {
                ResetGame();
            }

            Destroy(this.gameObject);
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
