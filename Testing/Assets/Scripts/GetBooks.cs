using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBooks : MonoBehaviour
{
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
            player = other.gameObject;
            if (player.GetComponent<Player>().order.CurrentState() == true)
            {
                player.GetComponent<Player>().order.CompleteOrder();
            }      
        }
    }
}
