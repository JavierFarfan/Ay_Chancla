using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorNiveles : MonoBehaviour
{
    public static ControladorNiveles Instance;
    public Button[] buttonsLevels;
    private int unlockLevels;
    public Button[] buttonsStage;
    private int unlockStage;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantén el objeto al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }



    void Start()
    {
        unlockLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        unlockStage = PlayerPrefs.GetInt("UnlockedStage", 0);
        ReloadButtonLevel();
        ReloadButtonStage();
    }

    public void IncreaseLevel( int levelUnlocked)
    {
        if (levelUnlocked > unlockLevels)
        {
            unlockLevels = levelUnlocked;
         
            PlayerPrefs.SetInt("UnlockedLevels", unlockLevels);
            PlayerPrefs.Save();
            ReloadButtonLevel();        

        }        
    }

    public void IncreaseStage( int stageUnlocked)
    {
        if(stageUnlocked > unlockStage)
        {
            unlockStage = stageUnlocked;
            PlayerPrefs.SetInt("UnlockedStages", unlockStage);
            PlayerPrefs.Save();
            ReloadButtonStage();
        }
    }

    public void ReloadButtonLevel()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        for (int i = 0; i < buttonsLevels.Length; i++)
        {
            buttonsLevels[i].interactable = i < unlockedLevels;
        }
        Debug.Log(unlockedLevels + "levels ");

    }
    public void ReloadButtonStage()
    {
        int unlockedStages = PlayerPrefs.GetInt("UnlockedStages", 1);
        for (int i = 0; i < buttonsStage.Length; i++)
        {
            buttonsStage[i].interactable = i < unlockedStages;
        }
        Debug.Log(unlockedStages + "Stages ");
    }
}
