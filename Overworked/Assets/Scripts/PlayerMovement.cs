using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody playerRb;
    private NavMeshAgent playerAgent;

    private float horizontalInput;
    private float verticalInput;


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
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
        Rotation();
    }
    void Update()
    {

        //Movement();
        //Rotation();
        //MouseClickMovement();

    }
    void Movement()
    {
        if (Input.GetKey(forward) && Input.GetKey(KeyCode.LeftShift))
        {
            playerRb.AddForce(transform.forward * movementSpeed*2);
            playerAnim.SetFloat("Speed", movementSpeed);
        }
        else if (Input.GetKey(forward))
        {
            playerRb.AddForce(transform.forward * movementSpeed);
            playerAnim.SetFloat("Speed", movementSpeed);
        }
        else if (Input.GetKeyDown(backward))
        {
            //playerRb.AddForce(-transform.forward * movementSpeed);
            //playerAnim.SetFloat("Speed", movementSpeed);

            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z);
            transform.rotation = Quaternion.Euler(rot);

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
        
    }
    void MouseClickMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 100))
            {
                playerAgent.destination = hit.point;
            }
        }
        if (playerAgent.velocity == Vector3.zero)
        {
            playerAnim.SetFloat("Speed", 0f);
        }
        else
        {
            playerAnim.SetFloat("Speed", 3.7f);
        }
    }
}
