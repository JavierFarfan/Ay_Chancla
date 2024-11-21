using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//using UnityEditor.SearchService;

public class ChangeSceneButton : MonoBehaviour
{
    public static ChangeSceneButton Instance;

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

    public void ChangeScene(int sceneIndex)
    {
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.sfxSource.Stop();
        SceneManager.LoadScene(sceneIndex);

        switch (sceneIndex)
        {
            case 0:
                AudioManager.Instance.PlayMusic("tittle");
                ControladorNiveles.Instance.ReloadButtonLevel();
                ControladorNiveles.Instance.ReloadButtonStage(); 
                
                break;
            case 1:
            case 2:
            case 3:
            case 4:
                AudioManager.Instance.PlayMusic("Stage1");
                AudioManager.Instance.PlaySfx("JuanitoStart");
                AudioManager.Instance.PlaySfx("MariaStart");
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                AudioManager.Instance.PlayMusic("Stage2");
                AudioManager.Instance.PlaySfx("JuanitoStart");
                AudioManager.Instance.PlaySfx("MariaStart");
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                AudioManager.Instance.PlayMusic("Stage3");
                AudioManager.Instance.PlaySfx("JuanitoStart");
                AudioManager.Instance.PlaySfx("MariaStart");
                break;



        }        
    }



    public void Exit()
    {
        Application.Quit();
    } 
}
