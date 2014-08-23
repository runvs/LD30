using UnityEngine;
using System.Collections;

public class AltarAction : MonoBehaviour {


    public bool Finished;

    // Use this for initialization
    void Start () 
    {
        Finished = false;
    }
    
    // Update is called once per frame
    void Update () 
    {
    
    }

    void OnMouseDown()
    {
        if (!Finished)
        {
            Debug.Log("You clicked Altar!");
            GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().SetAltar(this.gameObject);
            GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().InputTimer += 0.5f;
        }
    }

    internal void SetFinished()
    {
        Debug.Log("Altar is finished.");
        Application.LoadLevel("Headquarters");
        Finished = true;
    }
}
