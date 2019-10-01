using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DifficultySaver : MonoBehaviour {

    public int difficulty = 1;
    public bool returnedToMenu = false;

    public static DifficultySaver Instance;

    #region Singleton DifficultySaver
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Game Difficulty Control Functions
    public void setDifficultyEasy()
    {
        difficulty = 0;
    }

    public void setDifficultyMedium()
    {
        difficulty = 1;
    }

    public void setDifficultyHard()
    {
        difficulty = 2;
    }
    #endregion
}
