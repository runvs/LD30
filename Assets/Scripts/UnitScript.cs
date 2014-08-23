using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {


    private Vector3 TargetPosition;
    public GameObject AttackTarget;
    private Rigidbody2D rgdb2d;

    public string Name;
    // Use this for initialization
    void Start () 
    {
        TargetPosition = gameObject.transform.position;
        rgdb2d = gameObject.GetComponent<Rigidbody2D>();
        if (!rgdb2d)
        {
            throw new UnityException("No Rigidbody2d");
        }

        AttackTargetEventManager.OnDelete += RemoveAttackTarget;

    }

    private void RemoveAttackTarget(string name)
    {

        if (this.AttackTarget.GetComponent<AttackTarget>() && this.AttackTarget.GetComponent<AttackTarget>().name.Equals(name))
        {
            this.AttackTarget = null;
        }
    }
    
    // Update is called once per frame
    void Update () 
    {
        Vector3 CurrentPosition = gameObject.transform.position;
        Vector3 difference = (TargetPosition - CurrentPosition);
        if (difference.magnitude >= 0.5f)
        {
            //Debug.Log(CurrentPosition + " " + TargetPosition + " " + difference);
            rgdb2d.AddForce(difference.normalized * GameProperties.UnitMoveForceFactor);
        }
        else
        {
            rgdb2d.velocity = gameObject.GetComponent<Rigidbody2D>().velocity * 0.95f;
        }

        if (AttackTarget)
        {
            PerformAttack();
        }
        

        //if(rgdb2d.)
        CapVelocity();
    }

    public void CapVelocity()
    {
        // no rotation
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (rgdb2d.velocity.SqrMagnitude() >= GameProperties.UnitMaxVelocity * GameProperties.UnitMaxVelocity)
        {
            rgdb2d.velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * GameProperties.UnitMaxVelocity;
        }
        Debug.Log(rgdb2d.velocity);
    }

    internal void SetTargetPosition(Vector3 newPos)
    {
        Debug.Log(Name + " will Move to " + newPos);
        TargetPosition = newPos;
    }

    internal void SetAttackTarget(GameObject target)
    {
        AttackTarget = target;
    }

    internal void PerformAttack()
    {
        if (AttackTarget)
        {
            AttackTarget.GetComponent<HealthController>().RemoveHealth(this.GetComponent<HealthController>().Attack);
        }
    }


}
