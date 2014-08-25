using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasMessageDisplay : MonoBehaviour
{
    private Canvas myCanvas;

    public void ShowMessage(string message)
    {
        myCanvas.enabled = true;
        this.transform.GetComponentInChildren<Text>().text = message;
    }

    public void CloseMessage()
    {
        myCanvas.enabled = false;
    }


    // Use this for initialization
    void Start()
    {
        myCanvas = this.gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }




}
