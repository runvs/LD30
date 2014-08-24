using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {


    private float TutorialTimer = 5.0f;

    public bool TutorialRunning;


    public bool IsWaitingForCameraMove { get; set; }
    public bool HasMovedCamera { get { return hasMovedCamera; } set { hasMovedCamera = value; if (value == true) { ShowNextMessage(); IsWaitingForCameraMove = false; IsWaitingForSelectUnits = true; } } }
    private bool hasMovedCamera;

    public bool IsWaitingForSelectUnits { get; set; }
    public bool HasSelectedUnit { get { return hasSelectedUnit; } set { hasSelectedUnit = value; if (value == true) { ShowNextMessage(); IsWaitingForSelectUnits = false; SetTimer(2.5f); } } }
    private bool hasSelectedUnit;


    public bool IsWaitingForDeSelectUnits { get; set; }
    public bool HasDeSelectedUnit { get { return hasDeSelectedUnit; } set { hasDeSelectedUnit = value; if (value == true) { ShowNextMessage(); IsWaitingForDeSelectUnits = false;  IsWaitingForMoveUnit = true; } } }
    private bool hasDeSelectedUnit;

    public bool IsWaitingForMoveUnit { get; set; }
    public bool HasMovedUnit { get { return hasMovedUnit; } set { hasMovedUnit = value; if (value == true) { ShowNextMessage(); IsWaitingForMoveUnit = false; } } }
    private bool hasMovedUnit;

    public bool IsMessagePresent { get { return GetComponent<Canvas>().enabled; } }

    List<string> Messages;
    


    public bool IsWaitingForTimer = false;


    // Use this for initialization
    void Start () 
    {
        Messages = new List<string>();

        Messages.Add("asd");
        Messages.Add("To move the Camera, press WASD or use the arrow Keys.");
        Messages.Add("To give orders to your troops, you need to select them by clicking on them.");
        Messages.Add("You can have multiple units selected at the same time.");
        Messages.Add("To deselect a unit just perform a right click.");
        Messages.Add("To give a move order select a unit and left click anywhere. It will try to move reach the position.");
        Messages.Add("If you want your Troops to attack an enemy, select them, leftclick on the bad guy and watch him getting wasted.");
        SetTimer(0.1f);
        TutorialRunning = true;

        IsWaitingForCameraMove = true;
        HasMovedCamera = false;
        
        IsWaitingForSelectUnits = false;
        HasSelectedUnit = false;

        IsWaitingForDeSelectUnits = false;
        hasDeSelectedUnit = false;

        IsWaitingForMoveUnit = false;
        HasMovedUnit = false;
    }

    public void SetTimer (float Timer)
    {
        TutorialTimer = Timer;
        IsWaitingForTimer = true;
    }
    
    // Update is called once per frame
    void Update () 
    {

        if (IsWaitingForTimer)
        {
            if (GetComponent<Canvas>() && GetComponent<Canvas>().enabled == false)
            {
                TutorialTimer -= Time.deltaTime;
                if (TutorialTimer <= 0)
                {
                    
                    ShowNextMessage();
                    if (Messages[0].Contains("deselect"))
                    {
                        IsWaitingForDeSelectUnits = true;
                    }
                    IsWaitingForTimer = false;
                }
            }
        }
    }





    // show the current message without altering the Messages list
    public void ShowMessage()
    {
        if (Messages.Count != 0)
        {
            this.transform.GetComponentInChildren<Text>().text = Messages[0];
            GetComponent<Canvas>().enabled = true;
        }
    }

    // remove the last message and show the new one
    public void ShowNextMessage()
    {
        if (Messages.Count != 0)
        {
            Messages.RemoveAt(0);
        }
        if (Messages.Count != 0)
        {
            this.transform.GetChild(0).transform.FindChild("Text").GetComponent<Text>().text = Messages[0];
            GetComponent<Canvas>().enabled = true;
        }
    }


    public void CloseMessage ()
    {
        GetComponent<Canvas>().enabled = false;
    }

}
