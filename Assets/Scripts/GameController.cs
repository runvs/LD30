using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static List<string> SelectedTeamMembers = new List<string>();
    public static List<string> TeamMembersInExercise = new List<string>();

    public static int Money = 10000;
    public static int ResearchPoints = 10;

    public static bool Tier2Available = false;
    public static bool Tier3Available = false;

    public static bool IsAtBase = true;

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
