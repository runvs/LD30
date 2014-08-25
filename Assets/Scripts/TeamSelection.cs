using UnityEngine;
using UnityEngine.UI;

public class TeamSelection : MonoBehaviour
{
    public string TeamMemberName;
    public int Tier;
    public bool IsInExercise;

    void Start()
    {
        if (!IsInExercise)
        {
            var toggle = GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(CheckTeamMembers);

            var gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

            if (Tier == 2)
            {
                if (!gc.Tier2Available)
                {
                    toggle.interactable = false;
                }
            }
            else if (Tier == 3)
            {
                if (!gc.Tier3Available)
                {
                    toggle.interactable = false;
                }
            }

            if (GameController.DeadUnits.Contains(TeamMemberName))
            {
                toggle.interactable = false;
            }
        }
        else
        {
            if (GameController.DeadUnits.Contains(TeamMemberName))
            {
                var buttons = gameObject.GetComponentsInChildren<Button>();
                foreach (var button in buttons)
                {
                    button.enabled = false;
                }
            }
        }

        var description = transform.FindChild("TeamMemberDescription").GetComponent<Text>();
        var name = transform.FindChild("TeamMemberName").GetComponent<Text>().text;
        var unitProperties = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>();
        description.text = unitProperties.GetDescription(name);
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
