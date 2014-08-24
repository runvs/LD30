using System.Collections.Generic;
using UnityEngine;

public class TeamMember
{
    public float Health;
    public float Attack;
    public float Science;
    public string Name;
    public string Description;
}

public class UnitProperties : MonoBehaviour
{
    public Dictionary<string, TeamMember> TeamMembers = new Dictionary<string, TeamMember>();

    void Awake()
    {
        TeamMembers.Add("Arthur", new TeamMember { Name = "Arthur", Health = 0.4f, Attack = 0.1f, Science = 0.1f });
        TeamMembers.Add("Newton", new TeamMember { Name = "Newton", Health = 0.2f, Attack = 0.1f, Science = 0.4f });
        TeamMembers.Add("Jack", new TeamMember { Name = "Jack", Health = 0.2f, Attack = 0.5f, Science = 0.2f });

        TeamMembers.Add("Brunhilde", new TeamMember { Name = "Brunhilde", Health = 0.5f, Attack = 0.2f, Science = 0.1f });
        TeamMembers.Add("Titus", new TeamMember { Name = "Titus", Health = 0.2f, Attack = 0.2f, Science = 0.3f });
        TeamMembers.Add("Rusty", new TeamMember { Name = "Rusty", Health = 0.3f, Attack = 0.4f, Science = 0.1f });

        TeamMembers.Add("Dingo", new TeamMember { Name = "Dingo", Health = 0.6f, Attack = 0.2f, Science = 0.1f });
        TeamMembers.Add("Siren", new TeamMember { Name = "Siren", Health = 0.1f, Attack = 0.2f, Science = 0.6f });
        TeamMembers.Add("Brutus", new TeamMember { Name = "Brutus", Health = 0.2f, Attack = 0.6f, Science = 0.1f });
    }

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int CalculateCosts(string name, string attribute)
    {
        if (attribute.ToLower() == "health")
        {
            return (int)((TeamMembers[name].Health + GameProperties.AttributeIncreaseValue) * GameProperties.BaseAttributeCosts);
        }
        else if (attribute.ToLower() == "attack")
        {
            return (int)((TeamMembers[name].Attack + GameProperties.AttributeIncreaseValue) * GameProperties.BaseAttributeCosts);
        }
        else if (attribute.ToLower() == "science")
        {
            return (int)((TeamMembers[name].Science + GameProperties.AttributeIncreaseValue) * GameProperties.BaseAttributeCosts);
        }

        return 0;
    }

    public void Exercise(string name, string attribute)
    {
        var gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gc.MoneyRemove(CalculateCosts(name, attribute));

        if (attribute.ToLower() == "health")
        {
            TeamMembers[name].Health += GameProperties.AttributeIncreaseValue;
        }
        else if (attribute.ToLower() == "attack")
        {
            TeamMembers[name].Attack += GameProperties.AttributeIncreaseValue;
        }
        else if (attribute.ToLower() == "science")
        {
            TeamMembers[name].Science += GameProperties.AttributeIncreaseValue;
        }
    }

    public string GetDescription(string name)
    {
        return TeamMembers[name].Description ?? "";
    }

    public float GetHealth(string name)
    {
        return TeamMembers[name].Health;
    }

    public float GetAttack(string name)
    {
        return TeamMembers[name].Attack;
    }

    public float GetScience(string name)
    {
        return TeamMembers[name].Science;
    }
}
