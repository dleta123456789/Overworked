using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public Order order;

    [Header("Orders")]
    [SerializeField] private bool orderGiven;
    //To be used once we can see that player gets the quest
    //public GameObject BookLocation;

    [Header ("Characters in Area?")]
    [SerializeField] private bool playerPresent;
    [SerializeField] private bool npcPresent;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = true;
            player = other.gameObject;
        }
        if (other.CompareTag("NPC"))
        {
            npcPresent = true;
        }
        if (playerPresent == true && npcPresent == true)
        {
            if(player.GetComponent<Player>().order.CurrentState() == false)
            {
                player.GetComponent<Player>().order = order;
                player.GetComponent<Player>().order.SetOrderActive();
            }
            else if(player.GetComponent<Player>().order.CurrentState() == true && player.GetComponent<Player>().order.OrderState() == true)
            {
                Debug.Log("Order Complete");
                player.GetComponent<Player>().order = new Order();
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = false;
        }
        if (other.CompareTag("NPC"))
        {
            npcPresent = false;
        }
        
    }
}
