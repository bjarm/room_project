using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPSInput")]

public class FirstPerson : MonoBehaviour
{
    public float playerSpeed = 12.0f;
    public float jumpHeight = 10.0f;
    public const float baseSpeed = 12.0f;
    public float gravity = -9.8f;
    private bool groundedPlayer;
    private Vector3 playerVelocity;

    private CharacterController _charController;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = _charController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = transform.TransformDirection(movement);
        _charController.Move(movement * Time.deltaTime * playerSpeed);

        if (Input.GetKey("space") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        _charController.Move(playerVelocity * Time.deltaTime);

    }
}
