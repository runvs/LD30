using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitSelector : MonoBehaviour {


    private List<string> SelectedUnits;


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
        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

        foreach (var o in units)
        {
            UnitScript u = o.GetComponent<UnitScript>();
            u.SetSelectionEnabled(false);
        }

        SelectedUnits.Clear();
    }
    public void AddSelection (string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SelectedUnits.Add(name);
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
