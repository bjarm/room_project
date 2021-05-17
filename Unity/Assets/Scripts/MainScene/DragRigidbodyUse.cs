using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GrabObjectClass
{
	public bool m_FreezeRotation;
	public float m_PickupRange = 30f;
	public float m_ThrowStrength = 50f;
	public float m_distance = 10f;
	public float m_maxDistanceGrab = 40f;
}

[System.Serializable]
public class ItemGrabClass
{
	public bool m_FreezeRotation;
	public float m_ItemPickupRange = 20f;
	public float m_ItemThrow = 45f;
	public float m_ItemDistance = 10f;
	public float m_ItemMaxGrab = 25f;
}

[System.Serializable]
public class DoorGrabClass
{
	public float m_DoorPickupRange = 30f;
	public float m_DoorThrow = 10f;
	public float m_DoorDistance = 10f;
	public float m_DoorMaxGrab = 40f;
}

[System.Serializable]
public class TagsClass
{
	public string m_InteractTag = "Interact";
	public string m_InteractItemsTag = "InteractItem";
	public string m_DoorsTag = "Door";
	public string m_HandleTag = "Handle";
	public string m_RefrDoorTag = "RefrDoor";
}

public class DragRigidbodyUse : MonoBehaviour
{
	// sound settings
	[Header ("Sound settings")]
	[SerializeField] private AudioClip door;
	[SerializeField] private AudioClip refrDoor;
	[SerializeField] private AudioClip item;
	[SerializeField] private AudioClip handle;
	[SerializeField] private AudioClip itemDrop;
	[SerializeField] private float _doorVolume;
	[SerializeField] private float _itemVolume;
	[SerializeField] private float _handleVolume;
	[SerializeField] private float _dropVolume;
	[SerializeField] private float _dropDelay;
	// sound settings
	[Header ("Grab settings")]
	public GameObject playerCam;

	public string GrabButton = "Fire1";
	public string ThrowButton = "Fire2";
	public GrabObjectClass ObjectGrab = new GrabObjectClass();
	public ItemGrabClass ItemGrab = new ItemGrabClass();
	public DoorGrabClass DoorGrab = new DoorGrabClass();
	public TagsClass Tags = new TagsClass();
	[Header ("Dialogue controller")]
	public GameObject objText;

	private float PickupRange = 30f;
	private float ThrowStrength = 50f;
	private float distance = 10f;
	private float maxDistanceGrab = 40f;

	private Ray playerAim;
	private GameObject objectHeld;
	private bool isObjectHeld;
	private bool tryPickupObject;
	private GameObject obj;

	void Start()
	{
		isObjectHeld = false;
		tryPickupObject = false;
		objectHeld = null;
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			if (!isObjectHeld)
			{
				tryPickObject();
				tryPickupObject = true;
			}
			else
			{
				holdObject();
			}
		}
		else if (isObjectHeld)
		{
			DropObject();
		}

		if (Input.GetKey(KeyCode.Mouse1) && isObjectHeld)
		{
			isObjectHeld = false;
			objectHeld.GetComponent<Rigidbody>().useGravity = true;
			ThrowObject();
		}
	}

	private void tryPickObject()
	{
		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

		if (Physics.Raycast(playerAim, out hit, PickupRange))
		{
			objectHeld = hit.collider.gameObject;
			if (hit.collider.tag == Tags.m_InteractTag && tryPickupObject)
			{
				isObjectHeld = true;
				objectHeld.GetComponent<Rigidbody>().useGravity = false;
				//sound settings
				objectHeld.AddComponent<AudioSource>();
				objectHeld.GetComponent<AudioSource>().volume = _itemVolume;
				objectHeld.GetComponent<AudioSource>().PlayOneShot(item);
				objectHeld.AddComponent<CollisionSound>();
				objectHeld.GetComponent<CollisionSound>().delay = _dropDelay;
				objectHeld.GetComponent<CollisionSound>().itemDrop = itemDrop;
				objectHeld.GetComponent<AudioSource>().volume = _dropVolume;
				//sound settings
				if (ObjectGrab.m_FreezeRotation)
				{
					objectHeld.GetComponent<Rigidbody>().freezeRotation = true;
				}
				if (ObjectGrab.m_FreezeRotation == false)
				{
					objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
				}

				PickupRange = ObjectGrab.m_PickupRange;
				ThrowStrength = ObjectGrab.m_ThrowStrength;
				distance = ObjectGrab.m_distance;
				maxDistanceGrab = ObjectGrab.m_maxDistanceGrab;
			}
			if (hit.collider.tag == Tags.m_InteractItemsTag && tryPickupObject)
			{
				isObjectHeld = true;
				objectHeld.GetComponent<Rigidbody>().useGravity = true;
				if (ItemGrab.m_FreezeRotation)
				{
					objectHeld.GetComponent<Rigidbody>().freezeRotation = true;
				}
				if (ItemGrab.m_FreezeRotation == false)
				{
					objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
				}

				PickupRange = ItemGrab.m_ItemPickupRange;
				ThrowStrength = ItemGrab.m_ItemThrow;
				distance = ItemGrab.m_ItemDistance;
				maxDistanceGrab = ItemGrab.m_ItemMaxGrab;
			}
			if (hit.collider.tag == Tags.m_DoorsTag && tryPickupObject)
			{

				isObjectHeld = true;
				objectHeld.GetComponent<Rigidbody>().useGravity = true;
				objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
				// sound settings
				objectHeld.AddComponent<AudioSource>();
				objectHeld.GetComponent<AudioSource>().volume = _doorVolume;
				objectHeld.GetComponent<AudioSource>().PlayOneShot(door);
				//soudn settings
				PickupRange = DoorGrab.m_DoorPickupRange;
				ThrowStrength = DoorGrab.m_DoorThrow;
				distance = DoorGrab.m_DoorDistance;
				maxDistanceGrab = DoorGrab.m_DoorMaxGrab;
			}
			if (hit.collider.tag == Tags.m_RefrDoorTag && tryPickupObject)
			{

				isObjectHeld = true;
				objectHeld.GetComponent<Rigidbody>().useGravity = true;
				objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
				// sound settings
				objectHeld.AddComponent<AudioSource>();
				objectHeld.GetComponent<AudioSource>().volume = _doorVolume;
				objectHeld.GetComponent<AudioSource>().PlayOneShot(refrDoor);
				//soudn settings
				PickupRange = DoorGrab.m_DoorPickupRange;
				ThrowStrength = DoorGrab.m_DoorThrow;
				distance = DoorGrab.m_DoorDistance;
				maxDistanceGrab = DoorGrab.m_DoorMaxGrab;
			}
			if (hit.collider.tag == Tags.m_HandleTag && tryPickupObject)
			{
				// sound settings
				isObjectHeld = true;
				obj = GameObject.Find("Room");
				if(!obj.GetComponent<KeyController>().isKeyTaken)
				{
				objText.GetComponent<TextPrinter>().playDialogue(2);
				objectHeld.GetComponent<AudioSource>().volume = _handleVolume;
				objectHeld.GetComponent<AudioSource>().PlayOneShot(handle);
				}
				// sound settings
			}
		}
	}

	private void holdObject()
	{
		Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

		Vector3 nextPos = playerCam.transform.position + playerAim.direction * distance;
		Vector3 currPos = objectHeld.transform.position;

		objectHeld.GetComponent<Rigidbody>().velocity = (nextPos - currPos) * 10;

		if (Vector3.Distance(objectHeld.transform.position, playerCam.transform.position) > maxDistanceGrab)
		{
			DropObject();
		}
	}

	private void DropObject()
	{
		isObjectHeld = false;
		tryPickupObject = false;
		objectHeld.GetComponent<Rigidbody>().useGravity = true;
		objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
		objectHeld.GetComponent<Rigidbody>().AddForce(transform.up * (-10) * objectHeld.GetComponent<Rigidbody>().mass, ForceMode.Impulse);
		objectHeld = null;
	}

	private void ThrowObject()
	{
		objectHeld.GetComponent<Rigidbody>().AddForce(playerCam.transform.forward * ThrowStrength);
		objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
		objectHeld = null;
	}
}
