using UnityEngine;

public class UIHelper : MonoBehaviour
{
    public GameObject Guy;
    public void ShowUiForRoom(string roomType)
    {
        var canvases = GameObject.FindGameObjectsWithTag("Canvases");

        foreach (var canvas in canvases)
        {
            if (canvas.name == roomType + "Canvas")
            {
                var canvasComponent = canvas.GetComponent<Canvas>();
                canvasComponent.enabled = true;
            }
            else if (canvas.name != "WorldSpaceCanvas")
            {
                var canvasComponent = canvas.GetComponent<Canvas>();
                canvasComponent.enabled = false;
            }
        }
    }

    public void StartMission(string missionName)
    {

        // TODO Get Position from Script or move Level so it starts at 0,0,0
        Vector3 position = new Vector3(0, 0, 0);

        GameObject guy0 = Instantiate(Guy, position, new Quaternion()) as GameObject;
        GameObject guy1 = Instantiate(Guy, position, new Quaternion()) as GameObject;
        GameObject guy2 = Instantiate(Guy, position, new Quaternion()) as GameObject;

        //Debug.Log(GameController.SelectedTeamMembers[0]);
        //Debug.Log(GameController.SelectedTeamMembers[1]);
        //Debug.Log(GameController.SelectedTeamMembers[2]);

        guy0.GetComponent<UnitScript>().Name = GameController.SelectedTeamMembers[0];
        guy1.GetComponent<UnitScript>().Name = GameController.SelectedTeamMembers[1];
        guy2.GetComponent<UnitScript>().Name = GameController.SelectedTeamMembers[2];

        guy0.GetComponent<HealthController>().GetVariables(GameController.SelectedTeamMembers[0]);
        guy1.GetComponent<HealthController>().GetVariables(GameController.SelectedTeamMembers[1]);
        guy2.GetComponent<HealthController>().GetVariables(GameController.SelectedTeamMembers[2]);


        Application.LoadLevel(missionName);

        GameController.IsAtBase = false;
    }
}
