using UnityEngine;
using UnityEngine.UI;

public class TeamSelection : MonoBehaviour
{
    public string TeamMemberName;

    void Start()
    {
        var toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(CheckTeamMembers);
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
