using UnityEngine;
using UnityEngine.UI;

public class ExerciseController : MonoBehaviour
{
    private string _name;
    private string _attribute;

    void Start()
    {
        _name = transform.parent.parent.FindChild("TeamMemberName").GetComponent<Text>().text;
        _attribute = GetComponentInChildren<Text>().text.ToLower();

        var button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            GameObject.FindGameObjectWithTag("UnitProperties").GetComponent<UnitProperties>().Exercise(_name, _attribute);
        });
    }
}
