using UnityEngine;
using UnityEngine.UI;

public class DebriefingController : MonoBehaviour
{
    GameController _gameController;
    Text _totalExpenses;
    Text _fixedCosts;
    Text _electricity;
    Text _water;
    Text _rent;
    Text _teamCosts;
    Text _deadTeamMembers;
    Text _totalIncome;
    Text _foundArtefacts;
    Text _killedEnemies;
    Text _total;
    Text _researchPoints;
    Text _debriefingText;


    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        #region Assign all the game objects

        var gameObjects = GameObject.FindGameObjectsWithTag("BriefingTextValue");
        foreach (var go in gameObjects)
        {
            switch (go.name)
            {
                case "TotalExpensesValue":
                    _totalExpenses = go.GetComponent<Text>();
                    break;
                case "FixedCostsValue":
                    _fixedCosts = go.GetComponent<Text>();
                    break;
                case "ElectricityValue":
                    _electricity = go.GetComponent<Text>();
                    break;
                case "WaterValue":
                    _water = go.GetComponent<Text>();
                    break;
                case "RentValue":
                    _rent = go.GetComponent<Text>();
                    break;
                case "TeamCostsValue":
                    _teamCosts = go.GetComponent<Text>();
                    break;
                case "DeadTeamMembersValue":
                    _deadTeamMembers = go.GetComponent<Text>();
                    break;
                case "TotalIncomeValue":
                    _totalIncome = go.GetComponent<Text>();
                    break;
                case "FoundArtefactsValue":
                    _foundArtefacts = go.GetComponent<Text>();
                    break;
                case "KilledEnemiesValue":
                    _killedEnemies = go.GetComponent<Text>();
                    break;
                case "TotalValue":
                    _total = go.GetComponent<Text>();
                    break;
                case "ResearchPointsValue":
                    _researchPoints = go.GetComponent<Text>();
                    break;
                case "DebriefingText":
                    _debriefingText = go.GetComponent<Text>();
                    break;
            }
        }

        #endregion
    }

    public void SetValues()
    {
        _totalExpenses.text = _gameController.TotalExpenses.ToString();
        _fixedCosts.text = _gameController.FixedCosts.ToString();
        _electricity.text = _gameController.Electricity.ToString();
        _water.text = _gameController.Water.ToString();
        _rent.text = _gameController.Rent.ToString();
        _teamCosts.text = _gameController.TeamCosts.ToString();
        _deadTeamMembers.text = _gameController.DeadTeamMembers.ToString();
        _totalIncome.text = _gameController.TotalIncome.ToString();
        _foundArtefacts.text = _gameController.FoundArtefacts.ToString();
        _killedEnemies.text = _gameController.KilledEnemies.ToString();
        _total.text = _gameController.TotalValue.ToString();
        _researchPoints.text = _gameController.GainedResearchPoints.ToString();
        _debriefingText.text = _gameController.DebriefingText;
    }
}
