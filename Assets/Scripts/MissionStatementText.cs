using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionStatementText : MonoBehaviour
{

    private GameController gc;


    // Use this for initialization
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<Text>().text = gc.BriefingText;
    }
}
