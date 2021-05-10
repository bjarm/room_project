using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject key;
    public GameObject door;
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
                    key.gameObject.SetActive(false);
                    questPanel.text = "Ключ найден. Откройте дверь";
                    Debug.Log("VZYAL KLUCH");
                }
                else if (hit.collider.gameObject == door && isKeyTaken)
                {
                    Application.Quit();
                    Debug.Log("SVOBODA");
                }
            }
        }
    }
}
