using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseTogle : MonoBehaviour
{
    private Outline myOutline;
    private float OutlineRange = 30.0f;
    private RaycastHit hit;
    public  Camera playerCam;
    private void Start()
    {
        myOutline = GetComponent<Outline>();
        myOutline.enabled = false;
    }
    private void OnMouseOver()
    {   
        playerCam = Camera.main;
        Ray ray = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        if(Physics.Raycast(ray, out hit, OutlineRange)){
        myOutline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        myOutline.enabled = false;
    }
}
//void Update()
// 	{
// 		playerCam = Camera.main;
// 		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
// 		RaycastHit hit;

// 		if (Physics.Raycast(playerAim, out hit, RayLength))
// 		{
//             if (hit.collider.gameObject.tag == "Interact")
// 			{
//                 hit.collider.gameObject.outline = true;
// 			}
// 			if (hit.collider.gameObject.tag == "InteractItem")
// 			{
// 				hit.collider.gameObject.outline = true;
// 			}
// 			if (hit.collider.gameObject.tag == "Door")
// 			{
//                 hit.collider.gameObject.outline = true;
// 			}
//         }
//         else