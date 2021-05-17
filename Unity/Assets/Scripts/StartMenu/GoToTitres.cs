using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoToTitres : MonoBehaviour
{
    [SerializeField] private GameObject levelChanger;

    public void sceneSwitch()
    {
        levelChanger.GetComponent<SceneChanger>().levelToLoad = 4;
    }

}
