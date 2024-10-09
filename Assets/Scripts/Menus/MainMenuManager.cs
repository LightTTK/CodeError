using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Animator amin;
    public float transitionTime = 1f;
    
        public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
       SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadingLevel(int level)
    {
        amin.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
 }
