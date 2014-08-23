using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {


    private Vector3 TargetPosition;
    public GameObject AttackTarget;

    private float AttackTimer;

    private float AttackRange = 4.0f;

    private Rigidbody2D rgdb2d; // for  easy writing

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

        if (this.AttackTarget && this.AttackTarget.GetComponent<AttackTarget>() != null && this.AttackTarget.GetComponent<AttackTarget>().Name.Equals(name))
        {
            this.AttackTarget = null;
        }
    }
    
    // Update is called once per frame
    void Update () 
    {

        if (AttackTimer > 0.0f)
        {
            AttackTimer -= Time.deltaTime;
        }
        else
        {
            if (AttackTarget)
            {
                PerformAttack();
            }
        }

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
        //Debug.Log(rgdb2d.velocity);
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
            Vector3 direction = (AttackTarget.transform.position - this.transform.position);
            if (IsInRange(direction))
            {
                float Damage = AttributeConverter.GetAttackDamageFromAttribute(this.GetComponent<HealthController>().Attribute_Attack, false);
                AttackTarget.GetComponent<HealthController>().RemoveHealth(Damage);
                AttackTimer += GameProperties.UnitAttackTimerMax * AttributeConverter.GetAttackTimeFactorFromAttribute(this.gameObject.GetComponent<HealthController>().Attribute_Attack, false);
                AttackTarget.GetComponent<AttackTarget>().PushBack(direction.normalized, this.GetComponent<HealthController>().Attribute_Attack);
            }
            else
            {
                TargetPosition = this.transform.position + direction * 0.25f; 
            }
        }
    }

    private bool IsInRange(Vector3 direction)
    {
        bool retVal = direction.magnitude <= AttackRange;
        return retVal;        
    }


}
