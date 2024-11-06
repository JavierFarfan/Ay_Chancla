using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private GameObject panelHud;
    public HUD hud;

    public int vidas = 3;

    public HUDController hudController;

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
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void PerderVida()
    {
        if (vidas > 0)
        {
            vidas -= 1;
            hud.DesactivarVida(vidas);
        }   
    }

    public void RecuperarVida()
    {
        hud.ActivarVida(vidas);
        vidas += 1;
    }
    

    private void Update()
    {
        if(vidas == 0)
        {
            PerderGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {

        Time.timeScale = 1f;
    }
    public void NextGame()
    {
        int currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentIndexScene + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentIndexScene + 1);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.sfxSource.Stop();
        //SceneManager.LoadScene("LoseScene");
        Time.timeScale = 0f;
        panelHud.SetActive(false);
        panelLose.SetActive(true);
        AudioManager.Instance.PlaySfx("JuanitoGameOver"); 
        
    }
    public void GanarGame()
    {
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.sfxSource.Stop();
        //SceneManager.LoadScene("WinScene");
        Time.timeScale = 0f;
        panelHud.SetActive(false);
        panelWin.SetActive(true);
        AudioManager.Instance.PlaySfx("JuanitoVictory");
        AudioManager.Instance.PlaySfx("MariaEnd");
    }
}
