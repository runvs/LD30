using UnityEngine;
using System.Collections;
using System;

public class AttackTarget : MonoBehaviour {

    public string Name;
    // Use this for initialization
    void Start () 
    {
        Name = Guid.NewGuid().ToString();
    }
    
    // Update is called once per frame
    void Update () 
    {
    
    }

    void OnMouseDown()
    {
        Debug.Log("You clicked Enemy!");
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().SetAttackTarget(this.gameObject);
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().InputTimer += 0.15f;
    }

    internal void PushBack(Vector3 direction)
    {
        this.GetComponent<Rigidbody2D>().AddForce(direction * 1.0f * GameProperties.AttackPushBackForceFactor);
    }

}
