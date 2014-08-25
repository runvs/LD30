using UnityEngine;

public class MenuScript : MonoBehaviour
{

    //float _fadeTimeTotal = 1.0f;
    //float _fadeTime;
    //bool _fading = false;

    float _introMoveTime;
    float _introMoveTimeTotal = 3.0f;

    float _introFadeTime;
    float _introFadeTimeTotal = 1.5f;

    private GameObject logo;
    private GameObject menucanvas;

    // Use this for initialization
    void Start()
    {
        _introMoveTime = _introMoveTimeTotal;
        _introFadeTime = _introFadeTimeTotal;


        var hudObjects = GameObject.FindGameObjectsWithTag("Hud");
        foreach (var hudObject in hudObjects)
        {
            // Find logo
            if (hudObject.name == "runvs_logo")
            {
                logo = hudObject;
            }
            // Get UI Canvas
            if (hudObject.name == "menucanvas")
            {
                menucanvas = hudObject;
            }
        }
        menucanvas.GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("bgm").GetComponent<MusicManager>().StartMenuMusic();

        Instantiate(CursorManager);
        GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>().SetNormal();

        Instantiate(GameController);

    }

    public GameObject Guy;
    public GameObject ShotGroup;
    public BattleSystem BattleSystem;
    public UnitProperties UnitProperties;
    public UnitSelector UnitSelector;
    public CursorManager CursorManager;
    public GameController GameController;
    public Canvas MainUICanvas;
    public GameObject EventSystem;


    public void StartGame()
    {

        Instantiate(ShotGroup);
        Instantiate(UnitProperties);
        Instantiate(BattleSystem);
        Instantiate(UnitSelector);
        Instantiate(MainUICanvas);
        Instantiate(EventSystem);



        // Spawn three Units
        Vector3 position = new Vector3(0, 0, 0);

        GameObject guy1 = Instantiate(Guy, position, new Quaternion()) as GameObject;
        guy1.GetComponent<UnitScript>().Name = "Arthur";
        guy1.GetComponent<HealthController>().GetVariables("Arthur");

        GameObject guy2 = Instantiate(Guy, position, new Quaternion()) as GameObject;
        guy2.GetComponent<UnitScript>().Name = "Newton";
        guy2.GetComponent<HealthController>().GetVariables("Newton");

        GameObject guy3 = Instantiate(Guy, position, new Quaternion()) as GameObject;
        guy3.GetComponent<UnitScript>().Name = "Jack";
        guy3.GetComponent<HealthController>().GetVariables("Jack");

        GameObject.FindGameObjectWithTag("bgm").GetComponent<MusicManager>().StartMissionMusic();
        Application.LoadLevel(GameController.NextLevelName);



    }



    // Update is called once per frame
    void Update()
    {
        float camHalfHeight = Camera.main.orthographicSize;

        if (_introMoveTime >= 0 || _introFadeTime >= 0)
        {
            if (_introMoveTime >= 0)
            {
                _introMoveTime -= Time.deltaTime;

                float yval = 2.5f * (camHalfHeight * (1.0f - (float)(PennerDoubleEquation.GetValue(PennerDoubleEquation.EquationType.Linear, _introMoveTimeTotal - _introMoveTime, 0.0f, 1.0f, _introMoveTimeTotal))));
                logo.transform.position = new Vector3(0, yval, 0);
            }
            else
            {
                if (_introFadeTime >= 0)
                {
                    _introFadeTime -= Time.deltaTime;
                    logo.transform.position = new Vector3(0, 0, 0);
                    float alphaval = (1.0f - (float)(PennerDoubleEquation.GetValue(PennerDoubleEquation.EquationType.Linear, _introFadeTimeTotal - _introFadeTime, 0.0f, 1.0f, _introFadeTimeTotal)));
                    logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alphaval);
                }

            }
        }
        else
        {
            if (_introFadeTime >= -_introFadeTimeTotal)
            {
                logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0);

                _introFadeTime -= Time.deltaTime;
                float alphaval = ((float)(PennerDoubleEquation.GetValue(PennerDoubleEquation.EquationType.Linear, -_introFadeTime, 0.0f, 1.0f, _introFadeTimeTotal)));
                //GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIText>().color = new Color(0.682f, 0.768f, 0.25f, alphaval);
            }
            else if (_introFadeTime == -1234.0f)
            {

            }
            else
            {
                menucanvas.GetComponent<Canvas>().enabled = true;
                _introFadeTime = -1234.0f;
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("toggle music mute");
                GameObject.FindGameObjectWithTag("bgm").GetComponent<AudioSource>().enabled = !GameObject.FindGameObjectWithTag("bgm").GetComponent<AudioSource>().enabled;

            }
        }
    }
}
