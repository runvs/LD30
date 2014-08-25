using UnityEngine;

public class AltarAction : MonoBehaviour
{


    public bool Finished;
    public bool InUse;

    public EnemySpawner[] Spawners;

    public float AltarTime;

    // Use this for initialization
    void Start()
    {
        Finished = false;
        InUse = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (!Finished && !InUse)
        {
            Debug.Log("You clicked Altar!");
            GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().SetAltar(this.gameObject);
            GameObject.FindGameObjectWithTag("UnitSelector").GetComponent<UnitSelector>().InputTimer += 0.15f;
            StartSpawners();
        }

    }

    private void StartSpawners()
    {
        foreach (var s in Spawners)
        {
            s.enabled = true;
        }
        InUse = true;
    }

    internal void SetFinished()
    {
        Debug.Log("Altar is finished.");
        GameController gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        gc.ResetGame(true);

        Finished = true;
    }
}
