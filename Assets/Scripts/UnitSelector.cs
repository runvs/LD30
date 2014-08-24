﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSelector : MonoBehaviour {


    private List<string> SelectedUnits;

    TutorialScript tut;

    public int NumberOfSelectedUnits()
    {
        return SelectedUnits.Count;
        
    }

    private void RemoveFromSelection(string name)
    {
        if(SelectedUnits.Contains(name))
        {
            SelectedUnits.Remove(name);
        }
    }

    public float InputTimer = 0;




    // Use this for initialization
    void Start () 
    {
        SelectedUnits = new List<string>();
        UnitTargetEvenetManager.OnDelete += RemoveFromSelection;
        DeselectAllUnits();
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (!tut && Application.loadedLevelName == "AncientTemple")
        {
            tut = GameObject.FindGameObjectWithTag("TutorialScript").GetComponent<TutorialScript>();
        }

        if (InputTimer > 0)
        {
            InputTimer -= Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (SelectedUnits.Count != 0 )
                {
                    if (tut && !tut.IsMessagePresent || !tut)
                    {
                        InputTimer += 0.15f;

                        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

                        TutorialMove();

                        foreach (var s in SelectedUnits)
                        {
                            foreach (var o in units)
                            {
                                UnitScript u = o.GetComponent<UnitScript>();
                                if (u.Name == s)
                                {
                                    Vector3 v3 = Input.mousePosition;
                                    v3.z = 10.0f;
                                    v3 = Camera.main.ScreenToWorldPoint(v3);
                                    u.SetTargetPosition(v3);
                                }
                            }
                        }
                    }
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                DeselectAllUnits();
                InputTimer += 0.05f;
            }
        }
    }




    public void DeselectAllUnits()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

        foreach (var o in units)
        {
            UnitScript u = o.GetComponent<UnitScript>();
            u.SetSelectionEnabled(false);
        }

        TutorialDeSelect();
        SelectedUnits.Clear();
    }


    public void TutorialSelect()
    {
        if (tut)
        {
            if (tut.TutorialRunning)
            {
                if (tut.IsWaitingForSelectUnits)
                {
                    tut.HasSelectedUnit = true;
                }
            }
        }
    }

    public void TutorialDeSelect()
    {
        if (tut)
        {
            if (tut.TutorialRunning)
            {
                if (tut.IsWaitingForDeSelectUnits)
                {
                    tut.HasDeSelectedUnit = true;
                }
            }
        }
    }

    public void TutorialMove()
    {
        if (tut)
        {
            if (tut.TutorialRunning)
            {
                if (tut.IsWaitingForMoveUnit)
                {
                    tut.HasMovedUnit = true;
                }
            }
        }
    }


    public void AddSelection (string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SelectedUnits.Add(name);
            TutorialSelect();
        }

        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");
        foreach (var s in SelectedUnits)
        {
            foreach (var o in units)
            {
                UnitScript u = o.GetComponent<UnitScript>();
                if (u.Name == s)
                {
                    u.SetSelectionEnabled(true);
                }
            }
        }

    }



    internal void SetAttackTarget(GameObject gameObject)
    {
        if (NumberOfSelectedUnits() != 0)
        {
            GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

            foreach (var s in SelectedUnits)
            {
                foreach (var o in units)
                {
                    UnitScript u = o.GetComponent<UnitScript>();
                    if (u.Name == s)
                    {
                        u.SetAttackTarget(gameObject);
                    }
                }
            }
        }
    }

    internal void SetAltar(GameObject altar)
    {
        if (NumberOfSelectedUnits() != 0)
        {
            Debug.Log("Unit found for altar" );
            GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

            units[0].GetComponent<UnitScript>().SetAltar(altar);
        }
    }
}
