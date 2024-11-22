using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelHud;
    [SerializeField] private GameObject obstaculos;
    public HUD hud;

    public int vidas = 3;

    public HUDController hudController;

    public event Action OnPauseGame;
    public event Action OnResumeGame;


    private void Awake()
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

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
        Application.targetFrameRate = 60;
        obstaculos = GameObject.Find("Obtaculos");
    }

    public void PerderVida()
    {
        if (vidas > 1)
        {
            vidas -= 1;
            hud.DesactivarVida(vidas);
        }
        else
        {
            PerderGame();
        }
    }

    public void RecuperarVida()
    {
        hud.ActivarVida(vidas);
        vidas += 1;
    }
    

    private void Update()
    {
        /*if(vidas == 0)
        {
            
        }*/
    }
    public void PauseGame()
    {
        OnPauseGame?.Invoke();
        AudioManager.Instance.PlaySfx("sfxUISelect");
        AudioManager.Instance.musicSource.Pause();
        GameObject.Find("Maria").GetComponent<AudioSource>().Pause();
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        OnResumeGame?.Invoke();
        AudioManager.Instance.PlaySfx("sfxUISelect");
        AudioManager.Instance.musicSource.UnPause();
        GameObject.Find("Maria").GetComponent<AudioSource>().UnPause();
        Time.timeScale = 1f;
    }
    public void NextGame()
    {
        int currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentIndexScene + 1 < totalScenes)
        {
            ChangeSceneButton.Instance.ChangeScene(currentIndexScene + 1);
        }
        else
        {
            Debug.Log("Esta es la ultima escena");
        }
    }

    public void RestarGame()
    {
        RestoreLife();
        Time.timeScale = 1f;

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        ChangeSceneButton.Instance.ChangeScene(sceneIndex);

       /* if (hudController != null)
        {
            hudController.SetupButtons();
        }*/
    }
    public void RestoreLife()
    {
        vidas = 3;
        for (int i = 0; i < vidas && i < hud.vidas.Length; i++)
        {
            hud.ActivarVida(i);
        }
    }
    public void PerderGame()
    {
        GameObject.Find("Maria").GetComponent<AudioSource>().Stop();
        AudioManager.Instance.PlaySfx("JuanitoGameOver", 1.2f);
        AudioManager.Instance.PlaySfx("StingerLose");
        obstaculos = GameObject.Find("Obtaculos");

        AudioManager.Instance.musicSource.Stop();
        //SceneManager.LoadScene("LoseScene");
        Time.timeScale = 0f;
        panelHud.SetActive(false);
        panelLose.SetActive(true);
        obstaculos.SetActive(false);
        
        
    }
    public void GanarGame()
    {
        GameObject.Find("Maria").GetComponent<AudioSource>().Stop();
        AudioManager.Instance.PlaySfx("JuanitoVictory", 1.2f);
        AudioManager.Instance.PlaySfx("MariaEnd", 1.2f);
        AudioManager.Instance.PlaySfx("StingerWin");
        obstaculos = GameObject.Find("Obtaculos");
        AudioManager.Instance.musicSource.Stop();
        //SceneManager.LoadScene("WinScene");
        Time.timeScale = 0f;
        panelHud.SetActive(false);
        panelWin.SetActive(true);
        obstaculos.SetActive(false);
    }

    public void ReproducirSonidoBack()
    {
        AudioManager.Instance.PlaySfx("sfxUIBack");
    }
    public void ReproducirSonidoSelect()
    {
        AudioManager.Instance.PlaySfx("sfxUISelect");
    }
    public void ReproducirSonidoChancletazo()
    {
        AudioManager.Instance.PlaySfx("sfxUIChancletazo", 1.5f);
    }

}
