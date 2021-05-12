using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void ChangeScene(int numb)
    {
        SceneManager.LoadScene(numb);
    }

    public void Exit()
    {
        System.Threading.Thread.Sleep(1000);
        Application.Quit();
    }
}
