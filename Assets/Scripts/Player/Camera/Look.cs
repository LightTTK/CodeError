using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    [SerializeField] InputActionProperty lookInput;
    public Transform spineBone;
    public Transform camRoot;

    [SerializeField] Transform camera;

    [SerializeField] float lookSpeed = 150;

    public Vector2 camLimits;

    //Pause Menu
    public PauseMenu PauseMenu;
    public bool isPaused;
    public GameObject pauseMenu;

    Vector2 look;

    float rotateX;
    float rotateY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        lookInput.action.Enable();

        lookInput.action.performed += ctx =>
        {
            look = ctx.ReadValue<Vector2>();
        };
        lookInput.action.canceled += ctx =>
        {
            look = Vector2.zero;
        };

        //Pause
        pauseMenu.SetActive(false);

    }
    void Update()
    {
        rotateX -= look.y * Time.deltaTime * lookSpeed;
        rotateX = Mathf.Clamp(rotateX, camLimits.x, camLimits.y);
        camera.Rotate(camera.transform.right * rotateX);

        rotateY = look.x * Time.deltaTime * lookSpeed;

        // camera.Rotate(camera.transform.right * rotateX); 
        camera.localRotation = Quaternion.Euler(rotateX, 0, 0); // x, y, z, w = > x, y, z  
        transform.Rotate(transform.up * rotateY);

        //Pause  
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }

        // camRoot.position = new Vector3(camRoot.position.x, camRoot.position.y, spineBone.position.z);
        // camRoot.rotation = Quaternion.Euler(spineBone.eulerAngles.x, camRoot.eulerAngles.y, camRoot.eulerAngles.z);
    }

    //Pause Menu

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

}
