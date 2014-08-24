using UnityEngine;
using System.Collections;

public class AltarAction : MonoBehaviour {


    public bool Finished;
    public EnemySpawner[] Spawners;

    public float AltarTime;

    // Use this for initialization
    void Start () 
    {
        Finished = false;
    }
    
    // Update is called once per frame
    void Update () 
    {
    
    }

    void OnMouseDown()
    {
        if (!Finished)
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
    }

    internal void SetFinished()
    {
        Debug.Log("Altar is finished.");
        foreach (GameObject u in GameObject.FindGameObjectsWithTag("Units"))
        {
            Destroy(u);
        }
        Application.LoadLevel("Headquarters");
        Finished = true;
    }
}
