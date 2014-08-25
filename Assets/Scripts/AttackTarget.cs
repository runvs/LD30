using System;
using UnityEngine;

public class AttackTarget : MonoBehaviour
{

    public Texture2D AttackCursor;
    public string Name;
    // Use this for initialization
    void Start()
    {

    }

    public void SetNames()
    {
        if (this.gameObject.name.Contains("bug_fast"))
        {
            Name = "bug_fast" + Guid.NewGuid().ToString();
        }
        else if (this.gameObject.name.Contains("bug"))
        {
            Name = "bug_" + Guid.NewGuid().ToString();
        }

        else if (this.gameObject.name.Contains("enemy_weapon"))
        {
            Name = "enemy_weapon" + Guid.NewGuid().ToString();
        }
        else if (this.gameObject.name.Contains("enemy"))
        {
            Name = "enemy" + Guid.NewGuid().ToString();
        }
        else
        {
            Name = "badguy_" + Guid.NewGuid().ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("You clicked Enemy!");
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().SetAttackTarget(this.gameObject);
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().InputTimer += 0.15f;
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
