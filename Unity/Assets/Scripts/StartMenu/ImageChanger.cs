using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [Header("Image list")]
    [SerializeField] private int timer;
    [SerializeField] public Sprite[] imgList;

    private Sprite img;
    private GameObject obj;
    private GameObject prevObj;
    private GameObject canv;
    private Animator anim;
    
    private bool switcher = false;
    private bool stop = false;
    private bool isFirst = true;

    private int rand;
    private int randFirst;
    private int randTemp = 6;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("MenuImage");
        prevObj = GameObject.Find("ImageChanger");
        canv = GameObject.Find("Canvas");
        anim = canv.GetComponent<Animator>();
        randFirst = Random.Range(0,6);
        img = imgList[randFirst];
        obj.GetComponent<Image>().sprite = img;
    }

    void Update()
    {
        ChangeImage();
    }
    public void ChangeImage()
    {
        if (!stop)
        StartCoroutine(loadImage());
    }

    private void GetNumber()
    {
        if (isFirst)
        {
            rand = randFirst;
            isFirst = false;
        }
        else
        {
        rand = Random.Range(0,6);
        while (rand == randTemp) GetNumber();
        }
    }

    IEnumerator loadImage()
    {
        stop = true;
        GetNumber();
        randTemp = rand;
        img = imgList[rand];
        if(!switcher)
        {
            prevObj.GetComponent<Image>().sprite = img;
            anim.SetTrigger("fadeMain");
            switcher = true;
        }
        else 
        {
            obj.GetComponent<Image>().sprite = img;
            anim.SetTrigger("fadePrev");
            switcher = false;
        }

        yield return new WaitForSeconds(timer);

        stop = false;
    }
}
