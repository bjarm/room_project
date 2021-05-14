using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    // sound settings
	[Header ("Sound settings")]
	[SerializeField] private AudioClip keyCl;
    [SerializeField] private AudioClip knock;
    [SerializeField] private AudioClip misterySound;
    [SerializeField] private float _msVolume;
	[SerializeField] private float _keyVolume;
    [SerializeField] private float _knockVolume;
    [SerializeField] private float knockTimer;
    private bool stop;
    private bool knockStart = false;
	// sound settings
    [Header ("Key controller settings")]
    public GameObject playerCam;
    public GameObject key;
    public GameObject door;
    public GameObject room;
    public Text questPanel;

    public bool isKeyTaken = false;

    private float PickupRange = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(playerAim, out hit, PickupRange))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (hit.collider.gameObject == key && !isKeyTaken)
                {
                    isKeyTaken = true;
				    playerCam.GetComponent<AudioSource>().volume = _keyVolume;
				    playerCam.GetComponent<AudioSource>().PlayOneShot(keyCl);
                    key.gameObject.SetActive(false);
                    questPanel.text = "Ключ найден. Откройте дверь.";
                    Debug.Log("VZYAL KLUCH");
                    room.GetComponent<AudioSource>().volume = _msVolume;
                    room.GetComponent<AudioSource>().PlayOneShot(misterySound);
                    knockStart = true;

                }
                else if (hit.collider.gameObject == door && isKeyTaken)
                {
                    SceneManager.LoadScene(2);
                    Debug.Log("SVOBODA");
                }
            }
        }
        if (knockStart) PlayKnock();
    }
    // sound settings
    public void PlayKnock()
    {
        if (!stop)
        StartCoroutine(playSound());
    }

    IEnumerator playSound()
    {
        stop = true;
        yield return new WaitForSeconds(Random.Range(knockTimer, 25));
        door.GetComponent<AudioSource>().volume = Random.Range(_knockVolume, 1);
        door.GetComponent<AudioSource>().PlayOneShot(knock);
        stop = false;
    }
    // sound settings
}
