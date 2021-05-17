using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAwake : MonoBehaviour
{
    [Header ("Text printer")]
    public GameObject obj;
    void Start()
    {
        obj.GetComponent<TextPrinter>().playDialogue(0);
        StartCoroutine(TextCoroutine());
    }
        IEnumerator TextCoroutine()
    {
        yield return new WaitForSeconds(6f);
        obj.GetComponent<TextPrinter>().playDialogue(1);
    }
}
