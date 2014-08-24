using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float Attribute_Health;
    public float Attribute_Attack;
    public float Attribute_Science;

    public float CurrenteHealth;
    public float HealthMax;

    private float flashTimeRemaining;
    private float flashTimeMax;
    private Color flashColor;


    private SpriteRenderer renderer;

    void Start()
    {
        flashTimeMax = 0.35f;
        flashTimeRemaining = -12345.0f;
        flashColor = new Color(0.8f, 0.2f, 0.2f, 1.0f);//204 51 51    // red
        renderer = gameObject.GetComponent<SpriteRenderer>();
        if (!renderer)
        {
            throw new UnityException("No Renderer for HealthController");
        }
    }

    public void GetVariables(string Name = "")
    {
        if (this.tag == "Units")
        {
            this.Attribute_Health = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetHealth(Name);
            this.Attribute_Attack = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetAttack(Name);
            this.Attribute_Science = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().GetScience(Name);

        }
        else
        {
            this.Attribute_Health = GameProperties.EnemyAttributeDefaultHealth;
            this.Attribute_Attack = GameProperties.EnemyAttributeDefaultAttack;
            this.Attribute_Science = GameProperties.EnemyAttributeDefaultScience;
        }
        CurrenteHealth = AttributeConverter.GetMaxHealthFromAttribute(Attribute_Health, this.tag != "Units");
        HealthMax = AttributeConverter.GetMaxHealthFromAttribute(Attribute_Health, this.tag != "Units");
    }

    void Update()
    {
        CheckDead();

        if (flashTimeRemaining > 0.0f)
        {
            flashTimeRemaining -= Time.deltaTime;
            renderer.color = Color.Lerp( flashColor, Color.white, (flashTimeMax - flashTimeRemaining) / flashTimeMax); ;
        }
        else if (flashTimeRemaining == -12345.0f)
        {
            renderer.color = Color.white;
        }
        else
        {

            flashTimeRemaining = -12345.0f;
        }

    }

    private void CheckDead()
    {
        
        if (CurrenteHealth <= 0.0f)
        {
            Destroy(this.gameObject);
            if (this.tag == "Units")
            {
                UnitTargetEvenetManager.Call(this.gameObject.GetComponent<UnitScript>().Name);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().MoneyRemove(GameProperties.UnitLostMoneyFine);
            }
            else
            {
                // then it must be an Enemy
                AttackTargetEventManager.Call(this.gameObject.GetComponent<AttackTarget>().Name);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().MoneyAdd(GameProperties.EnemyKillMoneyReward);
            }
        }
    }

    // just decrease Value
    private void RemoveHealth(float value)
    {
        CurrenteHealth -= value;
        CheckDead();
    }

    // decrease Value and do some visual Feedback
    public void TakeDamage(float value)
    {
        RemoveHealth(value);
        FlashSprite();
        
    }

    private void FlashSprite()
    {
        flashTimeRemaining = flashTimeMax;
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
