using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip itemDrop;
    public float delay;

    private bool stop = false;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision) 
    {
       // debug 
       // foreach (ContactPoint contact in collision.contacts) {
       //     Debug.DrawRay(contact.point, contact.normal, Color.white);
       // }
        if ((collision.relativeVelocity.magnitude > 5)&&!stop)
        {   
            if(itemDrop!=null)
            {
            _audio.PlayOneShot(itemDrop);
            StartCoroutine(DelayCoroutine());
            }
        }
    }

        IEnumerator DelayCoroutine()
    {
        stop = true;
        yield return new WaitForSeconds(delay);
        stop = false;
    }

}
