using UnityEngine;
using UnityEngine.UI;

public class ExerciseController : MonoBehaviour
{
    private string _name;
    private string _attribute;
    private UnitProperties _unitProperties;

    void Start()
    {
        _name = transform.parent.parent.FindChild("TeamMemberName").GetComponent<Text>().text;
        _attribute = GetComponentInChildren<Text>().text.ToLower();
        _unitProperties = GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>();

        var button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            _unitProperties.Exercise(_name, _attribute);
        });
    }

    void Update()
    {
        var gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (_unitProperties.CalculateCosts(_name, _attribute) > gc.Money)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
