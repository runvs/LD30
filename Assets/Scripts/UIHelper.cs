using UnityEngine;

public class UIHelper : MonoBehaviour
{
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
}
