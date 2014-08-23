using UnityEngine;
using System.Collections;

public class UnitTargetEvenetManager : MonoBehaviour {

    public delegate void DeleteUnitTarget(string name);
    public static event DeleteUnitTarget OnDelete;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    public static void Call(string name)
    {
        if (OnDelete != null)
        {
            OnDelete(name);
        }
    }

}
