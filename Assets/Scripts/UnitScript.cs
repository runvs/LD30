using UnityEngine;
using System.Collections;

public class UnitScript : MonoBehaviour {


    private Vector3 TargetPosition;

    public GameObject AttackTarget;
    private float AttackTimerRemaining;
    private float AttackRange = 4.0f;

    public GameObject AltarTarget;
    private float AltarTimeRemaining;


    private Rigidbody2D rgdb2d; // for  easy writing
    private SpriteRenderer selectorRenderer;

    public string Name;
    // Use this for initialization
    void Start () 
    {
        TargetPosition = gameObject.transform.position;
        rgdb2d = gameObject.GetComponent<Rigidbody2D>();
        if (!rgdb2d)
        {
            throw new UnityException("Unit with No Rigidbody2d");
        }

        AttackTargetEventManager.OnDelete += RemoveAttackTarget;

        DontDestroyOnLoad(this.gameObject);
        selectorRenderer = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (!selectorRenderer)
        {
            throw new UnityException("Unit with No Selector");
        }
    }

    private void RemoveAttackTarget(string name)
    {

        if (this.AttackTarget && this.AttackTarget.GetComponent<AttackTarget>() != null && this.AttackTarget.GetComponent<AttackTarget>().Name.Equals(name))
        {
            this.AttackTarget = null;
        }
    }

    public void SetSelectionEnabled ( bool value)
    {
        selectorRenderer.enabled = value;
    }

    
    // Update is called once per frame
    void Update () 
    {

        if (AttackTimerRemaining > 0.0f)
        {
            AttackTimerRemaining -= Time.deltaTime;
        }
        else
        {
            if (AttackTarget)
            {
                PerformAttack();
            }
        }

        if (AltarTimeRemaining > 0)
        {
            AltarTimeRemaining -= Time.deltaTime / AttributeConverter.GetScienceTimeFactorFromAttribute(GetComponent<HealthController>().Attribute_Science, false);
            if (AltarTimeRemaining <= 0)
            {
                AltarTarget.GetComponent<AltarAction>().SetFinished();
            }
        }


        Vector3 CurrentPosition = gameObject.transform.position;
        Vector3 difference = (TargetPosition - CurrentPosition);
        if (difference.magnitude >= 0.5f)
        {
            //Debug.Log(CurrentPosition + " " + TargetPosition + " " + difference);
            rgdb2d.velocity = difference.normalized * GameProperties.UnitMoveVelocityFactor;
            //rgdb2d.AddForce(difference.normalized * GameProperties.UnitMoveForceFactor);
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
            //Debug.Log("Cap Velo");
            rgdb2d.velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * GameProperties.UnitMaxVelocity;
        }
        //Debug.Log(rgdb2d.velocity);
    }

    internal void SetTargetPosition(Vector3 newPos)
    {
        //Debug.Log(Name + " will Move to " + newPos);
        TargetPosition = newPos;

        // reset Attack Target so you can run away from enemies if needed
        AttackTarget = null;
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
                AttackTimerRemaining += GameProperties.UnitAttackTimerMax * AttributeConverter.GetAttackTimeFactorFromAttribute(this.gameObject.GetComponent<HealthController>().Attribute_Attack, false);
                if (AttackTarget)
                {
                    GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>().SpawnShot1(this.transform.position + direction * 0.25f, direction.normalized, AttackTarget, this.gameObject);
                }
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



    internal void SetAltar(GameObject altar)
    {
        this.AltarTarget = altar;
        this.AltarTimeRemaining = altar.GetComponent<AltarAction>().AltarTime;

        this.TargetPosition = altar.transform.position; // walk to the altar
    }
}
