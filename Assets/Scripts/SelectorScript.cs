using UnityEngine;
using System.Collections;

public class SelectorScript : MonoBehaviour {

    // Use this for initialization
    void Start () 
    {
    
    }
    
    // Update is called once per frame
    void Update () 
    {
    }

    void OnMouseDown()
    {
        Debug.Log("You clicked me!");

        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().AddSelection(gameObject.GetComponent<UnitScript>().Name);
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().InputTimer+= 0.5f;
    }
}
