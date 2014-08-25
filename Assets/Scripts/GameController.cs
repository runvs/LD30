﻿using System;
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

    public static bool IsAtBase { get { return (Application.loadedLevelName == "Headquarters" || Application.loadedLevelName == "Menu"); } }

    public static bool LastLevelWasSuccessful;

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

    public string DebriefingText { get { string retval; if (!MapDebriefingText.TryGetValue(NextLevelName, out retval)) { retval = ""; Debug.Log("Not Found"); } return retval; ; } }
    public string BriefingText { get { string retval; if (!MapBriefingText.TryGetValue(NextLevelName, out retval)) { retval = ""; } return retval; ; } }

    #endregion Debriefing Stuff

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        CreateMapDebriefingText();
        NextLevelName = "DesertCanyon";
        LastLevelWasSuccessful = true;
    }



    void Update()
    {
        if (!IsAtBase)
        {
            GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

            if (units.Length == 0)
            {
                ResetGame(false);
            }
        }
    }

    public void ResetDebriefingValues()
    {
        TeamCosts = 0;
        DeadTeamMembers = 0;
        FoundArtefacts = 0;
        KilledEnemies = 0;
        GainedResearchPoints = 0;
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

    public void ResetGame(bool success)
    {
        // back at base
        //IsAtBase = true;
        Application.LoadLevel("Headquarters");

        // destroy Units
        foreach (GameObject u in GameObject.FindGameObjectsWithTag("Units"))
        {
            Destroy(u);
        }

        if (success)
        {
            FoundArtefacts += GameProperties.FoundArtifactReward;
            MoneyAdd(GameProperties.FoundArtifactReward);

            GainedResearchPoints += 15;
            ResearchPointsAdd(15);
            NextLevel();    // if the player was not successful, play the same level again
            LastLevelWasSuccessful = true;
        }
        else
        {
            LastLevelWasSuccessful = false;
        }

        foreach (var go in GameObject.FindGameObjectsWithTag("Shots"))
        {
            Destroy(go);
        }
        Destroy(GameObject.FindGameObjectWithTag("MainUICanvas"));
        MoneyRemove(FixedCosts);

        GameObject.FindGameObjectWithTag("bgm").GetComponent<MusicManager>().StartMenuMusic();

    }

    public void QuitToMenu()
    {

    }

    private void CreateMapDebriefingText()
    {
        MapDebriefingText = new Dictionary<string, string>();
        MapDebriefingText.Add("DesertCanyon", "The Bridging Technology works fine..."); // blablabla
        MapDebriefingText.Add("AlienBase", "To Be Done1");
        MapDebriefingText.Add("GreatPlains", "To Be Done2");
        MapDebriefingText.Add("MotherShip", "To Be Done3");

        MapBriefingText = new Dictionary<string, string>();
        MapBriefingText.Add("DesertCanyon", "While our Scientists investigate the data you rescued from the temple, we discovered another world to travel to. There we found signs of intelligent life. Be prepared!"); // blabla
        MapBriefingText.Add("AlienBase", "To Be Done1"); // blabla
        MapBriefingText.Add("GreatPlains", "To Be Done2"); // blabla
        MapBriefingText.Add("MotherShip", "To Be Done3"); // blabla

        MapNextLevelName = new Dictionary<string, string>();
        MapNextLevelName.Add("AncientTemple", "DesertCanyon");
        MapNextLevelName.Add("DesertCanyon", "AlienBase");
        MapNextLevelName.Add("AlienBase", "GreatPlains");
        MapNextLevelName.Add("GreatPlains", "MotherShip");
    }

    // for debriefing
    private Dictionary<string, string> MapDebriefingText;
    // for next mission introduction
    private Dictionary<string, string> MapBriefingText;
    // for Selecting the next Level String
    private Dictionary<string, string> MapNextLevelName;

    public static string NextLevelName { get; set; }

    private void NextLevel()
    {
        NextLevelName = MapNextLevelName[NextLevelName];

    }
}
