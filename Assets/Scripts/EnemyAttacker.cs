using UnityEngine;
using System.Collections;

public class EnemyAttacker : MonoBehaviour 
{

    private float AttackTimer;
    public GameObject Target;
    private float minimalRange = GameProperties.EnemyAttackMinimalRange;
    public float MoveFactor = 1.0f;

    Rigidbody2D rgdb2d;

    // Use this for initialization
    void Start () 
    {
        rgdb2d = this.gameObject.GetComponent<Rigidbody2D>();
        UnitTargetEvenetManager.OnDelete += RemoveTarget;
        this.GetComponent<AttackTarget>().SetNames();
        this.GetComponent<HealthController>().GetVariables(this.GetComponent<AttackTarget>().Name);

    }

    private void RemoveTarget(string name)
    {
        Target = null;
    }
    
    // Update is called once per frame
    void Update () 
    {
        AttackTimer -= Time.deltaTime;
        if (Target)
        {
            Vector3 TargetPosition = Target.transform.position;

            Vector3 CurrentPosition = gameObject.transform.position;
            Vector3 difference = (TargetPosition - CurrentPosition);
            if (difference.magnitude >= 0.5f)
            {
                //Debug.Log(CurrentPosition + " " + TargetPosition + " " + difference);
                rgdb2d.AddForce(difference.normalized * MoveFactor);
            }
            else
            {
                rgdb2d.velocity = gameObject.GetComponent<Rigidbody2D>().velocity * 0.95f;

            }

            CapVelocity();
        }
        else
        {
            Target = GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().GetUnitClosestTo(this.transform.position);
            if (Target)
            {
                if ((Target.transform.position - this.transform.position).magnitude > minimalRange)
                {
                    Target = null;
                }
            }
        }


    }

    public void CapVelocity()
    {
        // no rotation
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (rgdb2d.velocity.SqrMagnitude() >= GameProperties.EnemyMaxVelocity * GameProperties.EnemyMaxVelocity)
        {
            rgdb2d.velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * GameProperties.EnemyMaxVelocity;
        }
        //Debug.Log(rgdb2d.velocity);
    }

    internal void SetTarget(GameObject shooter)
    {
        //Debug.Log("Set Target To " + shooter.name);
        if (shooter)
        {
            Target = shooter;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (AttackTimer <= 0)
        {
            if (coll.collider.tag == "Units")
            {
                Debug.Log("Attack Unit!");
                Target.GetComponent<HealthController>().TakeDamage(AttributeConverter.GetAttackDamageFromAttribute(GetComponent<HealthController>().Attribute_Attack, true));
                AttackTimer = GameProperties.EnemyAttackTimerMax * AttributeConverter.GetAttackTimeFactorFromAttribute(GetComponent<HealthController>().Attribute_Attack, true);
            }
        }
    }

}
