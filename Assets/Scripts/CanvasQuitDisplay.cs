using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasQuitDisplay : MonoBehaviour
{

    private Canvas myCanvas;
    private bool HasBeenShown = false;

    public void ShowMessage(string message)
    {
        myCanvas.enabled = true;
        this.transform.GetComponentInChildren<Text>().text = message;
        HasBeenShown = true;
    }

    public void CloseMessage()
    {
        myCanvas.enabled = false;
        if (HasBeenShown)
        {
            NowReallyQuit();
        }
    }


    // Use this for initialization
    void Start()
    {
        myCanvas = this.gameObject.GetComponent<Canvas>();
    }

    public void NowReallyQuit()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().NowReallyQuit();
    }

}
