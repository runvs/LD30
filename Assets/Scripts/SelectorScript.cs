using UnityEngine;

public class SelectorScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Debug.Log("You clicked me!");
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().AddSelection(gameObject.GetComponent<UnitScript>().Name);
        GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().InputTimer += 0.15f;
    }

    void OnMouseEnter()
    {
        GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().SetSelect();
    }

    void OnMouseExit()
    {
        GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().SetNormal();
    }
}
