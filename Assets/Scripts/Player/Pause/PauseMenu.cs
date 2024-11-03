using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    [SerializeField] PlayerGuns playerGuns;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool isPaused;

    // Start is called before the first frame update
    void Start () {
        pauseMenu.SetActive (false);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            if (isPaused) {
                isPaused = false;
                ResumeGame ();
            } else {
                isPaused = true;
                PauseGame ();
            }
        }

        if (isPaused) {
        }
    }

    public void PauseGame () {
        pauseMenu.SetActive (true);
        Time.timeScale = 0f;
        playerGuns.ToggleAllGunsShootable (false);
        // isPaused = true;
        //PlayerInput input = new PlayerInput();
        //input.Disable();
    }

    public void ResumeGame () {
        pauseMenu.SetActive (false);
        Time.timeScale = 1f;
        playerGuns.ToggleAllGunsShootable (true);
        // isPaused = false;
        //PlayerInput input = new PlayerInput();
        //input.Enable();
    }
    public void GoToMainMenu () {
        Time.timeScale = 1f;
        SceneManager.LoadScene (0);
    }
    public void QuitGame () {
        Application.Quit ();
    }
    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}