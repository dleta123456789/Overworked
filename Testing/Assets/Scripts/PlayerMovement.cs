using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnim;

    private float horizontalInput;
    private float verticalInput;

    private Rigidbody playerRb;

    [Header("Movement")]
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    [Header("Inputs")]
    [SerializeField] KeyCode forward;
    [SerializeField] KeyCode backward;
    [SerializeField] KeyCode left;
    [SerializeField] KeyCode right;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Rotation();


    }
    void Movement()
    {
        if (Input.GetKey(forward))
        {
            playerRb.AddForce(transform.forward * movementSpeed);
            playerAnim.SetFloat("Speed", movementSpeed);
        }
        else if (Input.GetKey(backward))
        {
            playerRb.AddForce(-transform.forward * movementSpeed);
            playerAnim.SetFloat("Speed", movementSpeed);
        }
        else
        {
            playerAnim.SetFloat("Speed", 0);
        }
    }
    void Rotation()
    {
        if (Input.GetKey(left))
        {
            transform.Rotate(-transform.up * rotationSpeed);
        }
        else if (Input.GetKey(right))
        {
            transform.Rotate(transform.up * rotationSpeed);
        }
        //else
        //{
        //    transform.Rotate(Vector3.zero);
        //}
    }
}
