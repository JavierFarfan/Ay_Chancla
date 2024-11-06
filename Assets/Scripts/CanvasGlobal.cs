using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGlobal : MonoBehaviour
{
    public static CanvasGlobal Instance;

    public GameObject menuInicial, hud;
    public GameObject[] allPanels;
    public GameManager gameManagerLife;

    public GameObject settingObjects;
    public GameObject pauseObjects;

    //public GameObject bottonHome;
    //public GameObject bottonRestart;
    //public GameObject bottonResume;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DisableAllPanels();
        gameManagerLife.vidas = 3;
        if (scene.name == "Home")
        {            

            menuInicial.SetActive(true);
            settingObjects.SetActive(true);

        }
        else if (scene.name.StartsWith("S"))
        {
            gameManagerLife.RestoreLife();
            Time.timeScale = 1f;
            hud.SetActive(true);
            pauseObjects.SetActive(true);
              
        }

    }
    private void DisableAllPanels()
    {
        SetPanelActive(allPanels, false);
        menuInicial.SetActive(false);
        hud.SetActive(false);
        pauseObjects.SetActive(false);
        settingObjects.SetActive(false);   

    }

    private void SetPanelActive(GameObject[] panels, bool isActive)
    {
        foreach (var panel in panels)
        {
            panel.SetActive(isActive);
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
