using UnityEngine;
using System.Collections;

public class UnitProperties : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public float Tank1_Health = 0.4f;
    public float Tank1_Attack = 0.1f;
    public float Tank1_Science = 0.1f;
    public string Tank1_name = "Arthur";
    
    public float Explorer1_Health = 0.2f;
    public float Explorer1_Attack = 0.1f;
    public float Explorer1_Science = 0.4f;
    public string Explorer1_name = "Newton";
    
    public float Damage1_Health = 0.2f;
    public float Damage1_Attack = 0.5f;
    public float Damage1_Science = 0.2f;
    public string Damage1_name = "Jack";
    
    public float Tank2_Health = 0.5f;
    public float Tank2_Attack = 0.2f;
    public float Tank2_Science = 0.1f;
    public string Tank2_name = "Brunhilde";
    
    public float Explorer2_Health = 0.2f;
    public float Explorer2_Attack = 0.2f;
    public float Explorer2_Science = 0.3f;
    public string Explorer2_name = "Titus";
    
    public float Damage2_Health = 0.3f;
    public float Damage2_Attack = 0.4f;
    public float Damage2_Science = 0.1f;
    public string Damage2_name = "Rusty";
    
    public float Tank3_Health = 0.6f;
    public float Tank3_Attack = 0.2f;
    public float Tank3_Science = 0.1f;
    public string Tank3_name = "Dingo";
    
    public float Explorer3_Health = 0.1f;
    public float Explorer3_Attack = 0.2f;
    public float Explorer3_Science = 0.6f;
    public string Explorer3_name = "Siren";
    
    public float Damage3_Health = 0.2f;
    public float Damage3_Attack = 0.6f;
    public float Damage3_Science = 0.1f;
    public string Damage3_name = "Brutus";


    internal float GetHealth(string p)
    {
        if (p.Equals(Damage3_name))
        {
            return Damage3_Health;
        }
        else if (p.Equals(Damage2_name))
        {
            return Damage2_Health;
        }
        else if (p.Equals(Damage1_name))
        {
            return Damage1_Health;
        }
        else if (p.Equals(Explorer1_name))
        {
            return Explorer1_Health;
        }
        else if (p.Equals(Explorer2_name))
        {
            return Explorer2_Health;
        }
        else if (p.Equals(Explorer3_name))
        {
            return Explorer3_Health;
        }
        else if (p.Equals(Tank1_name))
        {
            return Tank1_Health;
        }
        else if (p.Equals(Tank2_name))
        {
            return Tank2_Health;
        }
        else if (p.Equals(Tank3_name))
        {
            return Tank3_Health;
        }
        return 0;
    }

    internal float GetAttack(string p)
    {
        if (p.Equals(Damage3_name))
        {
            return Damage3_Attack;
        }
        else if (p.Equals(Damage2_name))
        {
            return Damage2_Health;
        }
        else if (p.Equals(Damage1_name))
        {
            return Damage1_Attack;
        }
        else if (p.Equals(Explorer1_name))
        {
            return Explorer1_Health;
        }
        else if (p.Equals(Explorer2_name))
        {
            return Explorer2_Attack;
        }
        else if (p.Equals(Explorer3_name))
        {
            return Explorer3_Attack;
        }
        else if (p.Equals(Tank1_name))
        {
            return Tank1_Attack;
        }
        else if (p.Equals(Tank2_name))
        {
            return Tank2_Attack;
        }
        else if (p.Equals(Tank3_name))
        {
            return Tank3_Attack;
        }

        return 0;
    }

    internal float GetScience(string p)
    {
        if (p.Equals(Damage3_name))
        {
            return Damage3_Science;
        }
        else if (p.Equals(Damage2_name))
        {
            return Damage2_Science;
        }
        else if (p.Equals(Damage1_name))
        {
            return Damage1_Science;
        }
        else if (p.Equals(Explorer1_name))
        {
            return Explorer1_Science;
        }
        else if (p.Equals(Explorer2_name))
        {
            return Explorer2_Science;
        }
        else if (p.Equals(Explorer3_name))
        {
            return Explorer3_Science;
        }
        else if (p.Equals(Tank1_name))
        {
            return Tank1_Science;
        }
        else if (p.Equals(Tank2_name))
        {
            return Tank2_Science;
        }
        else if (p.Equals(Tank3_name))
        {
            return Tank3_Science;
        }
    return 0;
    }
}
