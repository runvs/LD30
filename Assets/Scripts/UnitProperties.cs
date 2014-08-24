using UnityEngine;

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
    public string Tank1_Name = "Arthur";

    public float Explorer1_Health = 0.2f;
    public float Explorer1_Attack = 0.1f;
    public float Explorer1_Science = 0.4f;
    public string Explorer1_Name = "Newton";

    public float Damage1_Health = 0.2f;
    public float Damage1_Attack = 0.5f;
    public float Damage1_Science = 0.2f;
    public string Damage1_Name = "Jack";

    public float Tank2_Health = 0.5f;
    public float Tank2_Attack = 0.2f;
    public float Tank2_Science = 0.1f;
    public string Tank2_Name = "Brunhilde";

    public float Explorer2_Health = 0.2f;
    public float Explorer2_Attack = 0.2f;
    public float Explorer2_Science = 0.3f;
    public string Explorer2_Name = "Titus";

    public float Damage2_Health = 0.3f;
    public float Damage2_Attack = 0.4f;
    public float Damage2_Science = 0.1f;
    public string Damage2_Name = "Rusty";

    public float Tank3_Health = 0.6f;
    public float Tank3_Attack = 0.2f;
    public float Tank3_Science = 0.1f;
    public string Tank3_Name = "Dingo";

    public float Explorer3_Health = 0.1f;
    public float Explorer3_Attack = 0.2f;
    public float Explorer3_Science = 0.6f;
    public string Explorer3_Name = "Siren";

    public float Damage3_Health = 0.2f;
    public float Damage3_Attack = 0.6f;
    public float Damage3_Science = 0.1f;
    public string Damage3_Name = "Brutus";

    internal void Exercise(string name, string attribute)
    {
        Debug.Log(name + " exercises " + attribute);

        if (name == Tank1_Name)
        {
            if (attribute.ToLower() == "health")
            {
                Tank1_Health += 0.1f;
            }
            else if (attribute.ToLower() == "attack")
            {
                Tank1_Attack += 0.1f;
            }
            else if (attribute.ToLower() == "science")
            {
                Tank1_Science += 0.1f;
            }
        }
        else if (name == Explorer1_Name)
        {
            if (attribute.ToLower() == "health")
            {
                Explorer1_Health += 0.1f;
            }
            else if (attribute.ToLower() == "attack")
            {
                Explorer1_Attack += 0.1f;
            }
            else if (attribute.ToLower() == "science")
            {
                Explorer1_Science += 0.1f;
            }
        }
        else if (name == Damage1_Name)
        {
            if (attribute.ToLower() == "health")
            {
                Damage1_Health += 0.1f;
            }
            else if (attribute.ToLower() == "attack")
            {
                Damage1_Attack += 0.1f;
            }
            else if (attribute.ToLower() == "science")
            {
                Damage1_Science += 0.1f;
            }
        }
    }

    internal string GetDescription(string name)
    {
        return "No text";
    }

    internal float GetHealth(string p)
    {
        if (p.Equals(Damage3_Name))
        {
            return Damage3_Health;
        }
        else if (p.Equals(Damage2_Name))
        {
            return Damage2_Health;
        }
        else if (p.Equals(Damage1_Name))
        {
            return Damage1_Health;
        }
        else if (p.Equals(Explorer1_Name))
        {
            return Explorer1_Health;
        }
        else if (p.Equals(Explorer2_Name))
        {
            return Explorer2_Health;
        }
        else if (p.Equals(Explorer3_Name))
        {
            return Explorer3_Health;
        }
        else if (p.Equals(Tank1_Name))
        {
            return Tank1_Health;
        }
        else if (p.Equals(Tank2_Name))
        {
            return Tank2_Health;
        }
        else if (p.Equals(Tank3_Name))
        {
            return Tank3_Health;
        }
        return 0;
    }

    internal float GetAttack(string p)
    {
        if (p.Equals(Damage3_Name))
        {
            return Damage3_Attack;
        }
        else if (p.Equals(Damage2_Name))
        {
            return Damage2_Health;
        }
        else if (p.Equals(Damage1_Name))
        {
            return Damage1_Attack;
        }
        else if (p.Equals(Explorer1_Name))
        {
            return Explorer1_Health;
        }
        else if (p.Equals(Explorer2_Name))
        {
            return Explorer2_Attack;
        }
        else if (p.Equals(Explorer3_Name))
        {
            return Explorer3_Attack;
        }
        else if (p.Equals(Tank1_Name))
        {
            return Tank1_Attack;
        }
        else if (p.Equals(Tank2_Name))
        {
            return Tank2_Attack;
        }
        else if (p.Equals(Tank3_Name))
        {
            return Tank3_Attack;
        }

        return 0;
    }

    internal float GetScience(string p)
    {
        if (p.Equals(Damage3_Name))
        {
            return Damage3_Science;
        }
        else if (p.Equals(Damage2_Name))
        {
            return Damage2_Science;
        }
        else if (p.Equals(Damage1_Name))
        {
            return Damage1_Science;
        }
        else if (p.Equals(Explorer1_Name))
        {
            return Explorer1_Science;
        }
        else if (p.Equals(Explorer2_Name))
        {
            return Explorer2_Science;
        }
        else if (p.Equals(Explorer3_Name))
        {
            return Explorer3_Science;
        }
        else if (p.Equals(Tank1_Name))
        {
            return Tank1_Science;
        }
        else if (p.Equals(Tank2_Name))
        {
            return Tank2_Science;
        }
        else if (p.Equals(Tank3_Name))
        {
            return Tank3_Science;
        }
        return 0;
    }
}
