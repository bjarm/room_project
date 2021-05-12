using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextPrinter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator TextCoroutine(string text)
    {
        foreach (char c in text)
        {
            transform.GetComponent<Text>().text += c;
            yield return new WaitForFixedUpdate();
        }
    }
}
