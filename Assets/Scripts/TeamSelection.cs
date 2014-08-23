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
        if (added && TeamController.SelectedTeamMembers.Count < 3)
        {
            TeamController.SelectedTeamMembers.Add(TeamMemberName);
            Debug.Log(TeamMemberName);
        }
        else if (!added)
        {
            TeamController.SelectedTeamMembers.Remove(TeamMemberName);
        }
        else
        {
            var toggle = GetComponent<Toggle>();
            toggle.isOn = false;
        }
    }
}
