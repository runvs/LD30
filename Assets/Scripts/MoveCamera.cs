using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    TutorialScript tut;

    // Use this for initialization
    void Start()
    {
    }

    // This is needed for the Tutorial to check if the camera has been moved after the text has been displayed
    public void TutorialMoveCamera()
    {
        if (tut)
        {
            if (tut.TutorialRunning)
            {
                if (tut.IsWaitingForCameraMove)
                {
                    tut.HasMovedCamera = true;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!tut && Application.loadedLevelName == "AncientTemple")
        {
            tut = GameObject.FindGameObjectWithTag("TutorialScript").GetComponent<TutorialScript>();
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.position = new Vector3(
                this.transform.position.x + 0.1f,
                this.transform.position.y,
                this.transform.position.z
            );
            TutorialMoveCamera();
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.position = new Vector3(
                this.transform.position.x - 0.1f,
                this.transform.position.y,
                this.transform.position.z
            );
            TutorialMoveCamera();
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y + 0.1f,
                this.transform.position.z
            );
            TutorialMoveCamera();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y - 0.1f,
                this.transform.position.z
            );
            TutorialMoveCamera();
        }
    }
}
