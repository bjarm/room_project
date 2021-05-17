using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNext : MonoBehaviour
{
    [SerializeField] private GameObject sceneChanger;
    [SerializeField] private int timer;

    void Start()
    {
        StartCoroutine(changeScene());
    }
    IEnumerator changeScene()
        {
            yield return new WaitForSeconds(timer);
            sceneChanger.GetComponent<SceneChanger>().FadeToLevel();
        }
}
