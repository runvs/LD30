using UnityEngine;
using UnityEngine.UI;

public class TeamSelection : MonoBehaviour
{
    public string TeamMemberName;
    public int Tier;

    void Start()
    {
        var toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(CheckTeamMembers);

        if (Tier == 2)
        {
            if (!GameController.Tier2Available)
            {
                toggle.interactable = false;
            }
        }
        else if (Tier == 3)
        {
            if (!GameController.Tier3Available)
            {
                toggle.interactable = false;
            }
        }
    }

    public void CheckTeamMembers(bool added)
    {
        if (added && GameController.SelectedTeamMembers.Count < 3)
        {
            GameController.SelectedTeamMembers.Add(TeamMemberName);
        }
        else if (!added)
        {
            GameController.SelectedTeamMembers.Remove(TeamMemberName);
        }
        else
        {
            var toggle = GetComponent<Toggle>();
            toggle.isOn = false;
        }
    }
}
