using UnityEngine;
using System.Collections;

public class AltarAction : MonoBehaviour {

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
        Debug.Log("You clicked Altar!");
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().SetAttackTarget(this.gameObject);
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().InputTimer += 0.5f;
    }
}
