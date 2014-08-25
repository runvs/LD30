using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{


    private List<string> SelectedUnits;

    TutorialScript tut;

    public int NumberOfSelectedUnits()
    {
        return SelectedUnits.Count;

    }

    private void RemoveFromSelection(string name)
    {
        if (SelectedUnits.Contains(name))
        {
            SelectedUnits.Remove(name);
        }
    }

    public float InputTimer = 0;




    // Use this for initialization
    void Start()
    {
        SelectedUnits = new List<string>();
        UnitTargetEvenetManager.OnDelete += RemoveFromSelection;
        DeselectAllUnits();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
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
                if (SelectedUnits.Count != 0)
                {
                    if (tut && !tut.IsMessagePresent || !tut)
                    {
                        InputTimer += 0.15f;

                        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

                        TutorialMove();

                        PlayPlaceOrderSound();

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

    private void PlayPlaceOrderSound()
    {
        SfxrSynth synth = new SfxrSynth();
        synth.parameters.SetSettingsString("1,.496,.006,.1398,,.082,,.568,,,,,,,,,,,,,,,,,,1,,,.1,,,");
        synth.Play();
    }

    private void PlaySelectSound()
    {
        SfxrSynth synth = new SfxrSynth();
        synth.parameters.SetSettingsString("1,.674,,.1398,,.102,,.333,,,,,,,,,,,,,,,,,,.679,,,,,,");
        synth.Play();
    }

    private void PlayDeselectSound()
    {
        SfxrSynth synth = new SfxrSynth();
        synth.parameters.SetSettingsString("1,.674,,.1398,,.102,,.187,,,,,,,,,,,,,,,,,,.679,,,,,,");
        synth.Play();
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


    public void AddSelection(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SelectedUnits.Add(name);
            TutorialSelect();
            PlaySelectSound();



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

        PlayDeselectSound();
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

    public GameObject GetUnitSelectedAndClosestTo(Vector3 targetPosition)
    {
        GameObject retVal = null;
        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");
        float shortestDistance = float.MaxValue;
        if (units.Length == 0)
        {
            return null;
        }
        if (SelectedUnits.Count == 0)
        {
            return null;
        }

        foreach (var s in SelectedUnits)
        {
            foreach (var o in units)
            {
                UnitScript u = o.GetComponent<UnitScript>();
                if (u.Name == s)
                {
                    Vector3 distance = u.transform.position - targetPosition;
                    float sqrmag = distance.sqrMagnitude;
                    if (sqrmag <= shortestDistance)
                    {
                        shortestDistance = sqrmag;
                        retVal = u.gameObject;
                    }
                }
            }
        }
        return retVal;
    }

    public GameObject GetUnitClosestTo(Vector3 targetPosition)
    {
        GameObject retVal = null;
        GameObject[] units = GameObject.FindGameObjectsWithTag("Units");
        float shortestDistance = float.MaxValue;
        if (units.Length == 0)
        {
            return null;
        }

        for (int i = 0; i != units.Length; i++)
        {
            Vector3 distance = units[i].transform.position - targetPosition;
            float sqrmag = distance.sqrMagnitude;
            if (sqrmag <= shortestDistance)
            {
                shortestDistance = sqrmag;
                retVal = units[i].gameObject;
            }
        }
        return retVal;
    }

    internal void SetAltar(GameObject altar)
    {
        if (NumberOfSelectedUnits() != 0)
        {
            //Debug.Log("Unit found for altar");
            GetUnitSelectedAndClosestTo(altar.transform.position).GetComponent<UnitScript>().SetAltar(altar);
        }
    }
}
