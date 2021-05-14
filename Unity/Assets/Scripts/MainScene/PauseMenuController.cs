using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Character;
    public bool isPaused = false;
    public float timer;

    //sound settings
    [Header("Components")]
    [SerializeField] private Slider slider;
    
    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string sliderTag;

    [Header("Parameters")]
    [SerializeField] private float volume;
    //sound settings
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused){
            isPaused = true;
            Menu.SetActive(true);
            //sound settings
            if (PlayerPrefs.HasKey(this.saveVolumeKey))
            {
                this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
                this.GetComponent<AudioSource>().volume = this.volume;

                GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
                if(sliderObj != null)
                {
                    this.slider = sliderObj.GetComponent<Slider>();
                    this.slider.value = this.volume;
                    this.GetComponent<AudioSource>().volume = this.volume;
                }
            }
            //sound settings

            transform.gameObject.GetComponent<Crosshair>().m_ShowCursor = true;
            transform.gameObject.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.StopRotation;
            Character.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.StopRotation;
            }
            else
            {
                ResumeGame();
            }
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
        System.Threading.Thread.Sleep(1000);
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        System.Threading.Thread.Sleep(1000);
        Application.Quit();
    }

}

