﻿using UnityEngine;
using System.Collections;

public class NextMessageTutorial_Trigger : MonoBehaviour {

    public bool HasTriggered = false;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Units")
        {
            if (!HasTriggered)
            {
                GameObject.FindGameObjectWithTag("TutorialScript").GetComponent<TutorialScript>().ShowNextMessage();
                HasTriggered = true;
            }
        }
    }
}
