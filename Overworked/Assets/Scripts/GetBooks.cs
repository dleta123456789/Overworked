using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBooks : MonoBehaviour
{
    private GameObject player;
    private GameObject OrderManager;
    // Start is called before the first frame update
    void Start()
    {
        OrderManager = GameObject.FindGameObjectWithTag("OrderManager");
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().order.CurrentState() == false)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger on Book section works");

        if (other.CompareTag("Player"))
        {

            player = other.gameObject;
            if (player.GetComponent<Player>().order.CurrentState() == true)
            {
                player.GetComponent<Player>().order.CompleteOrder();
                OrderManager.GetComponent<OrderManager>().currentBookOrder.SetActive(false);
            }      
        }
    }
}
