using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCloser : MonoBehaviour
{
    public void Exit()
    {
        System.Threading.Thread.Sleep(1000);
        Application.Quit();
    }
}
