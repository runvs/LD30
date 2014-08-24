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
            if (Name.Contains("bug_fast"))
            {
                this.Attribute_Health = GameProperties.EnemyAttribute_BugFast_Health;
                this.Attribute_Attack = GameProperties.EnemyAttribute_BugFast_Attack;
                this.Attribute_Science = GameProperties.EnemyAttributeDefaultScience;
                this.GetComponent<EnemyAttacker>().MoveFactor = GameProperties.EnemyMoveFactor_BugFast;
            }
            else if (Name.Contains("bug"))
            {
                this.Attribute_Health = GameProperties.EnemyAttribute_Bug_Health;
                this.Attribute_Attack = GameProperties.EnemyAttribute_Bug_Attack;
                this.Attribute_Science = GameProperties.EnemyAttributeDefaultScience;
                this.GetComponent<EnemyAttacker>().MoveFactor = GameProperties.EnemyMoveFactor_Bug;
            }
            else if (Name.Contains("enemy_weapon"))
            {
                this.Attribute_Health = GameProperties.EnemyAttribute_EnemyWP_Health;
                this.Attribute_Attack = GameProperties.EnemyAttribute_EnemyWP_Attack;
                this.Attribute_Science = GameProperties.EnemyAttributeDefaultScience;
                this.GetComponent<EnemyAttacker>().MoveFactor = GameProperties.EnemyMoveFactor_EnemyWP;
            }
            else if (Name.Contains("enemy"))
            {
                this.Attribute_Health = GameProperties.EnemyAttribute_Enemy_Health;
                this.Attribute_Attack = GameProperties.EnemyAttribute_Enemy_Attack;
                this.Attribute_Science = GameProperties.EnemyAttributeDefaultScience;
                this.GetComponent<EnemyAttacker>().MoveFactor = GameProperties.EnemyMoveFactor_Enemy;
            }
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
            renderer.color = Color.Lerp(flashColor, Color.white, (flashTimeMax - flashTimeRemaining) / flashTimeMax); ;
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
        if (this.tag == "Units")
        {
            SfxrSynth synth = new SfxrSynth();
            synth.parameters.SetSettingsString("0,.85,.006,.0168,,.257,.3,.2546,,-.3348,,,,,,,,,,,.5682,,,,,1,,,.2569,,,");
            synth.PlayMutated();
        }
        else
        {
            SfxrSynth synth = new SfxrSynth();
            synth.parameters.SetSettingsString("0,.75,.006,.0168,,.257,.3,.2546,,-.3348,,,,,,,,,,,.5682,,,,,1,,,.2569,,,");
            synth.PlayMutated();
        }
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
    public float GetHealth()
    {
        return CurrenteHealth;
    }

    public void ReFillHealth()
    {
        CurrenteHealth = HealthMax;
    }


}
