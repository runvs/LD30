using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
    public GameObject Shooter;
    public GameObject AttackTarget;
    private float LifeTime;
    public float Damage;

    // Use this for initialization
    void Start () 
    {
        LifeTime = 10.0f;
        AttackTargetEventManager.OnDelete += RemoveAttackTarget;
    }

    private void RemoveAttackTarget(string name)
    {
        if(AttackTarget && AttackTarget.GetComponent<AttackTarget>() &&AttackTarget.GetComponent<AttackTarget>().Name.Equals(name))
        {
            //Destroy(this.gameObject);
            AttackTargetEventManager.OnDelete -= RemoveAttackTarget;
            Debug.Log("Taget Got Destroyed");
        }
    }
    
    // Update is called once per frame
    void Update () 
    {
        LifeTime -= Time.deltaTime;

        if(LifeTime <= 0)
        {
            Debug.Log("Lifetime up");
            Destroy(this.gameObject);
            AttackTargetEventManager.OnDelete -= RemoveAttackTarget;
            return;
        }

        if (!AttackTarget)
        {
            Debug.Log("No Valid Target");
            Destroy(this.gameObject);
            AttackTargetEventManager.OnDelete -= RemoveAttackTarget;
            return;
        }

        //if((AttackTarget.transform.position - this.transform.position).sqrMagnitude <= )

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "BadGuys")
        {
            //Debug.Log("Coll");
            coll.collider.GetComponent<HealthController>().RemoveHealth(Damage);
            coll.collider.gameObject.GetComponent<EnemyAttacker>().SetTarget(Shooter);
            //coll.collider.GetComponent<AttackTarget>().PushBack(this.GetComponent<Rigidbody2D>().velocity.normalized);
            Destroy(this.gameObject);

        }
        else if (coll.collider.tag == "Units")
        {
            // hurt your Teammate?
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
