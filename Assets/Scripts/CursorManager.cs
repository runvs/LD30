using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {

    public Texture2D NormalCursor;
    public Texture2D AttackCursor;
    public Texture2D SelectCursor;

    // Use this for initialization
    void Start () 
    {
        SetNormal();
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Update is called once per frame
    void Update () 
    {
    
    }

    public void SetAttack()
    {
        Cursor.SetCursor(AttackCursor, new Vector2(8, 8), CursorMode.Auto);
    }

    public void SetNormal ()
    {
        Cursor.SetCursor(NormalCursor, new Vector2(0, 0), CursorMode.Auto);
    }
    public void SetSelect ()
    {
        Cursor.SetCursor(SelectCursor, new Vector2(8, 8), CursorMode.Auto);
    }

}
