using UnityEngine;
using UnityEngine.UI;

public class UpdateResources : MonoBehaviour
{
    private Text _money;
    private GameController _gameController;

    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        _money = transform.FindChild("MoneyValue").GetComponent<Text>();
    }

    void Update()
    {
        _money.text = _gameController.Money.ToString();
    }
}
