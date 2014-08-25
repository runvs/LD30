using UnityEngine;

public class SpawnAltarOnCollider : MonoBehaviour
{

    public string Message;
    public bool HasTriggered;

    public AltarAction Altar;

    // Use this for initialization
    void Start()
    {
        HasTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Units")
        {
            if (!HasTriggered)
            {
                GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tiles_Foreground");
                foreach (var go in tiles)
                {
                    if (go.name == "tile_templealtar")
                    {
                        go.GetComponent<SpriteRenderer>().enabled = true;
                        go.GetComponent<BoxCollider2D>().enabled = true;
                        go.GetComponent<AltarAction>().enabled = true;

                        // TODO Message
                    }
                }
                HasTriggered = true;
            }
        }
    }
}
