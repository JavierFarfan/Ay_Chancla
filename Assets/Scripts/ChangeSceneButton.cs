using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    public static ChangeSceneButton Instance;

    
    public void ChangeScene(string sceneName)
    {
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.sfxSource.Stop();
        SceneManager.LoadScene(sceneName);

        /*if (sceneName == "S1L1")
         {            
             AudioManager.Instance.PlayMusic("Stage1");
             AudioManager.Instance.PlaySfx("JuanitoStart");
             AudioManager.Instance.PlaySfx("MariaStart");

         }
         else if (sceneName == "Home")
         {
             AudioManager.Instance.PlayMusic("tittle");
         }*/

        switch (sceneName)
        {
            case "Home":
                AudioManager.Instance.PlayMusic("tittle");
                
                break;
            case "S1L1":
                AudioManager.Instance.PlayMusic("Stage1");
                AudioManager.Instance.PlaySfx("JuanitoStart");
                AudioManager.Instance.PlaySfx("MariaStart");
                break;

            case "S1L2":
                AudioManager.Instance.PlayMusic("Stage1");
                AudioManager.Instance.PlaySfx("JuanitoStart");
                AudioManager.Instance.PlaySfx("MariaStart");
                break;
            case "S1L3":
                AudioManager.Instance.PlayMusic("Stage1");
                AudioManager.Instance.PlaySfx("JuanitoStart");
                AudioManager.Instance.PlaySfx("MariaStart");
                break;
            case "S1L4":
                AudioManager.Instance.PlayMusic("Stage1");
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
