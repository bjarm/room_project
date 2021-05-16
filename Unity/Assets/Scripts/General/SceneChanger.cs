using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    private Animator anim;
    public int levelToLoad;

    public Slider slider;
    public GameObject loadingScreen;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }

    public void OnFadeComplete()
    {   
        //SceneManager.LoadScene(levelToLoad);
        StartCoroutine(loadingScreenOnFade());
    }
    IEnumerator loadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return true;
        }
    }
}
