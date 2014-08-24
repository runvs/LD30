using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static List<string> SelectedTeamMembers = new List<string>();
    public static List<string> TeamMembersInExercise = new List<string>();

    public int Money = GameProperties.StartingMoney;
    public int ResearchPoints = GameProperties.StartingResearchPoints;

    public bool Tier2Available = false;
    public bool Tier3Available = false;

    public static bool IsAtBase = true;

    #region Debriefing Stuff

    public int Electricity
    {
        get
        {
            var multiplier = 1.0f;

            if (Tier2Available)
            {
                multiplier = GameProperties.Tier2Multiplier;
                if (Tier3Available)
                {
                    multiplier = GameProperties.Tier3Multiplier;
                }
            }

            var rand = UnityEngine.Random.Range(GameProperties.MinFixedCostsRange, GameProperties.MaxFixedCostsRange);
            return (int)Math.Floor(TotalIncome * rand * multiplier);
        }
    }
    public int Water
    {
        get
        {
            var multiplier = 1.0f;

            if (Tier2Available)
            {
                multiplier = GameProperties.Tier2Multiplier;
                if (Tier3Available)
                {
                    multiplier = GameProperties.Tier3Multiplier;
                }
            }

            var rand = UnityEngine.Random.Range(GameProperties.MinFixedCostsRange, GameProperties.MaxFixedCostsRange);
            return (int)Math.Floor(TotalIncome * rand * multiplier);
        }
    }
    public int Rent { get { return GameProperties.Rent; } }

    public int TeamCosts = 0;
    public int DeadTeamMembers = 0;
    public int FoundArtefacts = 0;
    public int KilledEnemies = 0;
    public int GainedResearchPoints = 0;

    public int TotalIncome { get { return FoundArtefacts + KilledEnemies; } }
    public int FixedCosts { get { return Electricity + Water + Rent; } }
    public int TotalExpenses { get { return FixedCosts + TeamCosts + DeadTeamMembers; } }
    public int TotalValue { get { return TotalIncome - TotalExpenses; } }

    #endregion Debriefing Stuff

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!IsAtBase)
        {
            GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

            if (units.Length == 0)
            {
                ResetGame();
            }
        }

    }

    public void MoneyAdd(int amount)
    {
        Money += amount;
    }

    public void MoneyRemove(int amount)
    {
        Money -= amount;
    }

    public void ResearchPointsAdd(int amount)
    {
        ResearchPoints += amount;
    }

    public void ResearchPointsRemove(int amount)
    {
        ResearchPoints -= amount;
    }

    public void ResetGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        Destroy(GameObject.FindGameObjectWithTag("bgm"));

        IsAtBase = true;
        //Application.LoadLevel("Menu");
    }
}
