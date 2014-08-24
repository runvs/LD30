using UnityEngine;
using System.Collections;

public class EnemyAttacker : MonoBehaviour 
{

    private float AttackTimer;
    public GameObject Target;

    Rigidbody2D rgdb2d;

    // Use this for initialization
    void Start () 
    {
        rgdb2d = this.gameObject.GetComponent<Rigidbody2D>();
        UnitTargetEvenetManager.OnDelete += RemoveTarget;
        this.GetComponent<HealthController>().GetVariables();
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
                rgdb2d.AddForce(difference.normalized * GameProperties.EnemyMoveFactor);
            }
            else
            {
                rgdb2d.velocity = gameObject.GetComponent<Rigidbody2D>().velocity * 0.95f;
                
            }

            CapVelocity();
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
                Target.GetComponent<HealthController>().RemoveHealth(AttributeConverter.GetAttackDamageFromAttribute(GetComponent<HealthController>().Attribute_Attack, true));
                AttackTimer = GameProperties.EnemyAttackTimerMax * AttributeConverter.GetAttackTimeFactorFromAttribute(GetComponent<HealthController>().Attribute_Attack, true);
            }
        }
    }

}
