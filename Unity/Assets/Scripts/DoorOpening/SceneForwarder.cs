using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneForwarder : MonoBehaviour
{
    [Header ("Audio CLip")]
    [SerializeField] private AudioClip clip;
    [SerializeField] private int scene;
    [SerializeField] private int timer = 0;
    void Awake()
    {
        GameObject obj = GameObject.FindWithTag("BG_MUSIC_CREATED");
        if (obj != null)
        {
            Destroy(obj.gameObject);
        }
        ChangeScene();
    }
        // sound settings
    public void ChangeScene()
    {
        StartCoroutine(playSound());
    }

    IEnumerator playSound()
    {
        if (timer == 0) 
        {
            yield return new WaitForSeconds(clip.length);
        }
        else
        {
            yield return new WaitForSeconds(timer);
        }
        SceneManager.LoadScene(scene);
    }
    // sound settings
}
