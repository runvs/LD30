using UnityEngine;
using System.Collections;
using System;

public class AttackTarget : MonoBehaviour {

    public Texture2D AttackCursor;
    public string Name;
    // Use this for initialization
    void Start () 
    {
      
        
    }

    public void SetNames()
    {
        if (this.gameObject.name == "bug")
        {
            Name = "bug_" + Guid.NewGuid().ToString();
        }
        else if (this.gameObject.name == "bug_fast")
        {
            Name = "bug_fast" + Guid.NewGuid().ToString();
        }
        else if (this.gameObject.name == "enemy_weapon")
        {
            Name = "enemy_weapon" + Guid.NewGuid().ToString();
        }
        else if (this.gameObject.name == "enemy")
        {
            Name = "enemy" + Guid.NewGuid().ToString();
        }
        else
        {
            Name = "badguy_" + Guid.NewGuid().ToString();
        }
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

    void OnMouseEnter()
    {
        GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().SetAttack();
    }

    void OnMouseExit()
    {
        GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().SetNormal();
    }

}
