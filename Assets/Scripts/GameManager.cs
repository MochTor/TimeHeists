using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{

    public string[] levelsName;
    public enum GameMode
    {
        CTF,
        CONTROL,
        ASSAULT
    }

    List<AsyncOperation> _loadOperations;
    GameMode _currentGameMode;
    string _currentLevelName;

    public GameMode CurrrentGameMode
    {
        get { return _currentGameMode;  }
        private set { _currentGameMode = value;  }
    }

    /********* VARIABLES USED IN CTF MODE *************/
    public GameObject redFlag;
    public GameObject blueFlag;
    public Collider redTeamCollider;
    public Collider blueTeamCollider;
    /**************************************************/

    // Start is called before the first frame update
    void Start()
    {
        _loadOperations = new List<AsyncOperation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }

        _loadOperations.Add(ao);

        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        //ao.completed += OnUnloadOperationComplete;
    }

    public void StartGame()
    {
        LoadLevel(levelsName[0]);
    }

    public void SetGameMode(string levelName)
    {
        switch (levelName)
        {
            case "Vikings":
                _currentGameMode = GameMode.CTF;
                break;
        }
    }
}
