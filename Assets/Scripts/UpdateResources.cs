using UnityEngine;
using UnityEngine.UI;

public class UpdateResources : MonoBehaviour
{
    private Text _money;
    private Text _researchPoints;
    private GameController _gameController;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _money = transform.GetChild(0).FindChild("MoneyValue").GetComponent<Text>();
        _researchPoints = transform.GetChild(0).FindChild("ResearchPointsValue").GetComponent<Text>();
    }

    void Update()
    {
        _money.text = _gameController.Money.ToString();
        _researchPoints.text = _gameController.ResearchPoints.ToString();
    }
}
