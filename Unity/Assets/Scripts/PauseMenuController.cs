using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Character; // костыль для остановки поворота камеры
    public bool isPaused = false;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timer;

        if (isPaused)
        {
            timer = 0;
        }
        else
        {
            timer = 1.0f;
        }

        if (Input.GetKey(KeyCode.Escape) && !isPaused)
        {
            Menu.SetActive(true);
            transform.gameObject.GetComponent<Crosshair>().m_ShowCursor = true;
            isPaused = true;
            transform.gameObject.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.StopRotation;
            Character.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.StopRotation;
        }
        else if (Input.GetKey(KeyCode.Escape) && isPaused)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        Menu.SetActive(false);
        isPaused = false;
        transform.gameObject.GetComponent<Crosshair>().m_ShowCursor = false;
        transform.gameObject.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseY;
        Character.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseX;
    }

    public void ExitToMainMenu()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
