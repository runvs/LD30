using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Attribute_Health;
    public float Attribute_Attack;
    public float Attribute_Science;

    public float CurrenteHealth;
    public float HealthMax;

    void Start()
    {
        //GetVariables(gameObject.GetComponent<UnitScript>().Name);
    }

    public void GetVariables(string Name)
    {
        if (this.tag == "Units")
        {
            this.Attribute_Health = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetHealth(Name);
            this.Attribute_Attack = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetAttack(Name);
            this.Attribute_Science = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetScience(Name);

        }
        else
        {
            this.Attribute_Health = 1;
            this.Attribute_Attack = 1;
            this.Attribute_Science = 1;
        }
        CurrenteHealth = AttributeConverter.GetMaxHealthFromAttribute(Attribute_Health, this.tag != "Units");
        HealthMax = AttributeConverter.GetMaxHealthFromAttribute(Attribute_Health, this.tag != "Units");
    }

    void Update()
    {
        CheckDead();
    }

    private void CheckDead()
    {
        
        if (CurrenteHealth <= 0.0f)
        {
            Destroy(this.gameObject);
            if (this.tag == "Units")
            {
                UnitTargetEvenetManager.Call(this.gameObject.GetComponent<UnitScript>().Name);
            }
            else
            {
                AttackTargetEventManager.Call(this.gameObject.GetComponent<AttackTarget>().Name);
            }
        }
    }

    public void RemoveHealth(float value)
    {
        //Debug.Log("RemoveHealth");
        CurrenteHealth -= value;
        CheckDead();
    }
    public float GetHealth ()
    {
        return CurrenteHealth;
    }

    public void ReFillHealth ()
    {
        CurrenteHealth = HealthMax;
    }

    
}
