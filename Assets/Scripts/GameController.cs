using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static List<string> SelectedTeamMembers = new List<string>();
    public static bool Tier2Available = false;
    public static bool Tier3Available = false;

    private bool _isAtBase = true;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!_isAtBase)
        {
            GameObject[] units = GameObject.FindGameObjectsWithTag("Units");

            if (units.Length == 0)
            {
                ResetGame();
            }
        }

    }

    public void ResetGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        Destroy(GameObject.FindGameObjectWithTag("bgm"));
        Destroy(GameObject.FindGameObjectWithTag("StoryManager"));

        //Application.LoadLevel("Menu");
    }
}
