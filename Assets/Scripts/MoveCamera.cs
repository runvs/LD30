using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.position = new Vector3(
                this.transform.position.x + 0.1f,
                this.transform.position.y,
                this.transform.position.z
            );
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.position = new Vector3(
                this.transform.position.x - 0.1f,
                this.transform.position.y,
                this.transform.position.z
            );
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y + 0.1f,
                this.transform.position.z
            );
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            this.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y - 0.1f,
                this.transform.position.z
            );
        }
    }
}
