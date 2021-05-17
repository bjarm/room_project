using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrinter : MonoBehaviour
{
    [Header("Personage replics sounds")]
    [SerializeField] public AudioClip[] voice;
    [Header("Personage replics text")]
    public GameObject cam;
    public GameObject dPanel;
    public GameObject dText;
    public GameObject canv;
    private Animator anim;
    private AudioClip clip; 
    private GameObject obj;
    private Text tt;

    private string textStart = "Ох, голова раскалывается...";
    private string text1 = "Что это за комната? Мне нужно выбраться отсюда.";
    private string text2 = "Похоже, что мне нужно найти ключ...";
    private string text3 = "Теперь я смогу открыть эту дверь";
    private string text4 = "Кто бы это мог быть?";
    private string text5 = "<<Звук открытия двери.....................>>";
    private string text6 = "Что это!? Где я оказался?.......";

    private bool stop = false;

    private int _caseSwitch;
    void Start()
    {
        anim = canv.GetComponent<Animator>();
        tt = dText.GetComponent<Text>();
    }
    
    public void playDialogue(int caseSwitch)
    {
        _caseSwitch = caseSwitch;
        if(!stop)
        {
            switch (caseSwitch)
            {
                case 0:
                    StartCoroutine(TextCoroutine(textStart));
                break;
                case 1:
                    StartCoroutine(TextCoroutine(text1));
                    break;
                case 2:
                    StartCoroutine(TextCoroutine(text2));
                    break;
                case 3:
                    StartCoroutine(TextCoroutine(text3));
                    break;
                case 4:
                    StartCoroutine(TextCoroutine(text4));
                    break;
                case 5:
                    StartCoroutine(TextCoroutine(text5));
                    break;
                case 6:
                    StartCoroutine(TextCoroutine(text6));
                    break;                    
                default:
                    break;
            }
                }
    }

    IEnumerator TextCoroutine(string text)
    {
        stop = true;
        tt.text = "";
        anim.SetTrigger("panelShow");
        yield return new WaitForSeconds(1f);
        switch (_caseSwitch)
        {
            case 0:
                cam.GetComponent<AudioSource>().PlayOneShot(voice[0]);
            break;
            case 1:
                cam.GetComponent<AudioSource>().PlayOneShot(voice[1]);
                break;
            case 2:
                cam.GetComponent<AudioSource>().PlayOneShot(voice[2]);
                break;
            case 3:
                cam.GetComponent<AudioSource>().PlayOneShot(voice[3]);
                break;
            case 4:
                cam.GetComponent<AudioSource>().PlayOneShot(voice[4]);
                break;
            case 6:
                cam.GetComponent<AudioSource>().PlayOneShot(voice[5]);
                break;                    
            default:
                break;
        }
        foreach (char c in text)
        {
            tt.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("panelHide");
        anim.SetTrigger("actionEnd");
        stop = false;
    }

}
