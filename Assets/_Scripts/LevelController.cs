using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    #region Singleton
    // s_Instance is used to cache the instance found in the scene so we don't have to look it up every time.
    private static LevelController s_Instance = null;


    // A static property that finds or creates an instance of the manager object and returns it.
    public static LevelController instance
    {
        get
        {
            if (s_Instance == null)
            {
                // FindObjectOfType() returns the first AManager object in the scene.
                s_Instance = FindObjectOfType(typeof(LevelController)) as LevelController;
            }

            return s_Instance;
        }
    }


    // Ensure that the instance is destroyed when the game is stopped in the editor.
    void OnApplicationQuit()
    {
        s_Instance = null;
    }

    #endregion

    
    public UILevelController _uiLevel;
    public PlayerController _player;
    public Texture2D cursor;

    void Awake()
    {
        _uiLevel = FindObjectOfType<UILevelController>();
        _player = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }



}
