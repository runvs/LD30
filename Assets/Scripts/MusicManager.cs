using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource MusicMenu;
    public AudioSource MusicMissions;

    // Use this for initialization
    void Start()
    {
        MusicMenu.loop = true;
        MusicMissions.loop = true;

        //MusicMenu.playOnAwake = true;
        MusicMissions.playOnAwake = true;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Music Mis: " + MusicMissions.isPlaying + "\t Music Men: " + MusicMenu.isPlaying);
    }

    public void StartMenuMusic()
    {
        MusicMenu.playOnAwake = true;
        MusicMenu.enabled = true;
        MusicMenu.Play();
        MusicMissions.Stop();
        MusicMissions.enabled = false;


    }

    public void StartMissionMusic()
    {
        MusicMissions.enabled = true;
        MusicMenu.Stop();
        MusicMissions.Play();
        MusicMenu.enabled = false;

    }
}
