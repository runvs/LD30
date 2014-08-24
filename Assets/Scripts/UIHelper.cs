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


        foreach (var s in GameController.SelectedTeamMembers)
        {
            GameObject guy = Instantiate(Guy, position, new Quaternion()) as GameObject;
            guy.GetComponent<UnitScript>().Name = s;
            guy.GetComponent<HealthController>().GetVariables(s);
        }

        Application.LoadLevel(missionName);

        

        GameController.IsAtBase = false;
    }
}
