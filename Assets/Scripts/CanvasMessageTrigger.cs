using UnityEngine;
using System.Collections;

public class CanvasMessageTrigger : MonoBehaviour
{

    public string Message;
    public CanvasMessageDisplay Display;

    public bool HasTriggered;

    // Use this for initialization
    void Start()
    {
        HasTriggered = false;
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!HasTriggered)
        {
            HasTriggered = true;
            if (coll.tag == "Units")
            {
                Display.ShowMessage(Message);
            }
        }
    }

}
