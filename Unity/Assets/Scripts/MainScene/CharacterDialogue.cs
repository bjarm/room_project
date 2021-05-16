using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialogue : MonoBehaviour
{
    [Header("Personage replics sounds")]
    [SerializeField] public AudioClip[] voice;
    [Header("Personage replics text")]
    [SerializeField] public Text awakeText;
    [SerializeField] public GameObject awakeTextFone;
    private AudioClip clip; 
    private GameObject obj;

    private string text;

    void Start()
    {
        text = "Ох, голова раскалывается...";
        //awakeTextFone.SetActive(true);
        awakeText.text = text;
        StartCoroutine(TextCoroutine(text));
    }

    void Update()
    {
    }

    IEnumerator TextCoroutine(string text)
    {
        awakeText.text = "mda";
        foreach (char c in text)
        {
            awakeText.text += c;
            print("whaaat");
            yield return new WaitForSeconds(2);
        }
    }

}
