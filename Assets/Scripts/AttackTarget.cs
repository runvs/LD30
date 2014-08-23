using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

    public string Name;
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
        Debug.Log("You clicked Enemy!");

        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().SetAttacker(this.gameObject);
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().InputTimer += 0.5f;
        
    }


    internal void PushBack(Vector3 direction, float AttackAttribute)
    {
        this.GetComponent<Rigidbody2D>().AddForce(direction * AttackAttribute * GameProperties.AttackPushBackForceFactor);
    }
}
