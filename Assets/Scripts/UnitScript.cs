using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {

    public string Name;
    // Use this for initialization
    void Start () 
    {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    internal void SetTargetPosition(Vector3 newPos)
    {
        Debug.Log(Name + " will Move to " + newPos);
    }
}
