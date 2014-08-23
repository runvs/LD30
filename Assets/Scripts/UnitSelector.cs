using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSelector : MonoBehaviour {


    private List<string> SelectedUnits;

    public float InputTimer = 0;


    // Use this for initialization
    void Start () 
    {
        SelectedUnits = new List<string>();
    }
    
    // Update is called once per frame
    void Update () 
    {
        if (InputTimer > 0)
        {
            InputTimer -= Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (SelectedUnits.Count != 0)
                {
                    InputTimer += 0.5f;

                    GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

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
            if (Input.GetMouseButtonUp(1))
            {
                DeselectAllUnits();
                InputTimer += 0.25f;
            }
        }
    }

    public void DeselectAllUnits()
    {
        SelectedUnits.Clear();
    }
    public void AddSelection (string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SelectedUnits.Add(name);
        }
    }


}
