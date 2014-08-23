using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Health;
    public float Attack;
    public float Science;

    void Start()
    {
        if (this.tag == "Units")
        {
            this.Health = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetHealth(gameObject.GetComponent<UnitScript>().Name);
            this.Attack = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetAttack(gameObject.GetComponent<UnitScript>().Name);
            this.Science = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetScience(gameObject.GetComponent<UnitScript>().Name);
        }
        else
        {
            this.Health = 1;
            this.Attack = 1;
            this.Science = 1;
        }
    }

    void Update()
    {
        CheckDead();
    }

    private void CheckDead()
    {
        
        if (Health <= 0.0f)
        {
            Destroy(this.gameObject);
            if (this.tag == "Units")
            {

            }
            else
            {
                AttackTargetEventManager.Call(this.gameObject.GetComponent<AttackTarget>().Name);
            }
            
        }
    }

    public void RemoveHealth(float value)
    {
        Health -= value;
        CheckDead();
    }
    public float GetHealth ()
    {
        return Health;
    }

    
}
