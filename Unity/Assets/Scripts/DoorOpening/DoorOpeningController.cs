using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorOpeningController : MonoBehaviour
{
    [Header ("Audio CLip")]
    [SerializeField] private AudioClip clip;
    [SerializeField] private int scene;
    [SerializeField] private int timer = 0;
    [SerializeField] private AudioClip forest;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject image;
    
    [Header ("Dialogue controller")]
	public GameObject objText;
    public Text text;

    private Animator anim;

    void Awake()
    {
        anim = image.GetComponent<Animator>();
        text.fontStyle = FontStyle.Bold;
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
        yield return new WaitForSeconds(clip.length/8);
        objText.GetComponent<TextPrinter>().playDialogue(5);
        yield return new WaitForSeconds(clip.length * 7/8);
        anim.SetTrigger("startActivity");
        objText.GetComponent<TextPrinter>().playDialogue(6);
        _camera.GetComponent<AudioSource>().PlayOneShot(forest);
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(scene);
    }
    // sound settings
}

