using UnityEngine;
[ExecuteInEditMode]
public class EditorGrid : MonoBehaviour
{

    public float cell_size = 1f; // = larghezza/altezza delle celle
    private float x, y, z;

    // Use this for initialization
    void Start()
    {
        x = 0f;
        y = 0f;
        z = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        x = Mathf.Round(transform.position.x / cell_size) * cell_size;
        y = Mathf.Round(transform.position.y / cell_size) * cell_size;
        z = transform.position.z;
        transform.position = new Vector3(x, y, z);

        transform.localScale = new Vector3(1.0f, 1.0f);
    }
}
