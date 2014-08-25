using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static List<string> SelectedTeamMembers = new List<string>();
    public static List<string> TeamMembersInExercise = new List<string>();
    public static List<string> DeadUnits;

    public int Money = GameProperties.StartingMoney;
    public int ResearchPoints = GameProperties.StartingResearchPoints;

    public bool Tier2Available = false;
    public bool Tier3Available = false;

    public static bool IsAtBase { get { return (Application.loadedLevelName == "Headquarters" || Application.loadedLevelName == "Menu"); } }

    public static bool LastLevelWasSuccessful;

    #region Debriefing Stuff

    public int Electricity = 0;
    public int Water = 0;
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
        NextLevelName = "AncientTemple";
        LastLevelWasSuccessful = true;


        UnitTargetEvenetManager.OnDelete += DeadUnitList;
        DeadUnits = new List<string>();
    }

    private void DeadUnitList(string name)
    {
        DeadUnits.Add(name);
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
        #region Set electricity/water

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
        Electricity = (int)Math.Floor(TotalIncome * rand * multiplier);

        rand = UnityEngine.Random.Range(GameProperties.MinFixedCostsRange, GameProperties.MaxFixedCostsRange);
        Water = (int)Math.Floor(TotalIncome * rand * multiplier);

        #endregion

        // back at base
        //IsAtBase = true;

        Application.LoadLevel("Headquarters");


        GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().SetNormal();

        // destroy Units
        foreach (GameObject u in GameObject.FindGameObjectsWithTag("Units"))
        {
            Destroy(u);
        }
        foreach (var go in GameObject.FindGameObjectsWithTag("Shots"))
        {
            Destroy(go);
        }

        if (success)
        {
            FoundArtefacts += GameProperties.FoundArtifactMoneyReward;
            MoneyAdd(GameProperties.FoundArtifactMoneyReward);

            GainedResearchPoints += GameProperties.FoundArtifactRPReward;
            ResearchPointsAdd(GameProperties.FoundArtifactRPReward);
            NextLevel();    // if the player was not successful, play the same level again
            LastLevelWasSuccessful = true;
        }
        else
        {
            LastLevelWasSuccessful = false;
        }


        //Destroy(GameObject.FindGameObjectWithTag("MainUICanvas"));    // this will be kept
        MoneyRemove(FixedCosts);

        GameObject.FindGameObjectWithTag("bgm").GetComponent<MusicManager>().StartMenuMusic();
    }

    public void QuitToMenu()
    {

        CanvasQuitDisplay cqd = GameObject.FindGameObjectWithTag("CanvasQuitDisplay").GetComponent<CanvasQuitDisplay>();

        cqd.ShowMessage("This is the End of WorldGate! You are awesome!");  // blabla TODO  
    }

    internal void NowReallyQuit()
    {

        // destroy Units
        foreach (GameObject u in GameObject.FindGameObjectsWithTag("Units"))
        {
            Destroy(u);
        }
        foreach (var go in GameObject.FindGameObjectsWithTag("Shots"))
        {
            Destroy(go);
        }

        Application.LoadLevel("Menu");
        Destroy(GameObject.FindGameObjectWithTag("MainUICanvas"));    // this will be kept
        Destroy(GameObject.FindGameObjectWithTag("bgm"));
        Destroy(GameObject.FindGameObjectWithTag("ShotGroup"));

        Destroy(GameObject.FindGameObjectWithTag("UnitProperties"));
        Destroy(GameObject.FindGameObjectWithTag("BattleSystem"));
        Destroy(GameObject.FindGameObjectWithTag("UnitSelector"));
        //Destroy(GameObject.FindGameObjectWithTag("EventSystem"));

        Destroy(GameObject.FindGameObjectWithTag("CursorManager"));
        Destroy(this.gameObject);


    }


    private void CreateMapDebriefingText()
    {
        MapDebriefingText = new Dictionary<string, string>();
        MapDebriefingText.Add("DesertCanyon", "The artefact you recovered is unlike anything we have ever seen. It seems like it inherits some kind of mechanism to open up bridges between planets. Our guys just need to figure it out, visit them in the lab!"); // blablabla
        MapDebriefingText.Add("AlienBase", "Good thing you made it out of there alive. On the bright side the new data you stumbled upon really helps to understand the artefact's powers. Keep up the good work.");
        MapDebriefingText.Add("GreatPlains", "Great job. Everyone is very excited, as we get offers from the government to recover more artefacts. Get to it.");
        MapDebriefingText.Add("Mothership", "One hour ago a large alien ship came to one of our bridges. They look angry. Do something about it.");

        MapBriefingText = new Dictionary<string, string>();
        MapBriefingText.Add("DesertCanyon", "While our scientists investigated the data you recovered from the temple, we discovered another inhabitable world. Our exploration drone was downed, prepare yourself!");
        MapBriefingText.Add("AlienBase", "We found the source of that alien aggressors. You have got to take care of them. Bonus payments to your retirement fond if you succeed.");
        MapBriefingText.Add("GreatPlains", "Well done, we will assign you employee of the month. Oh but it's all top secret, so don't talk to anyone about it.");
        MapBriefingText.Add("Mothership", "That was the last one of them. We have to be more careful with those bridges. Never mind there are more planets to conquer.");

        MapNextLevelName = new Dictionary<string, string>();
        MapNextLevelName.Add("AncientTemple", "DesertCanyon");
        MapNextLevelName.Add("DesertCanyon", "AlienBase");
        MapNextLevelName.Add("AlienBase", "GreatPlains");
        MapNextLevelName.Add("GreatPlains", "Mothership");
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
