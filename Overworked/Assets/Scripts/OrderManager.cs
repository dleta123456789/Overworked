using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OrderManager : MonoBehaviour
{
    public Order order;

    [Header("Orders")]
    [SerializeField] private bool orderGiven;
    [SerializeField] List<GameObject> BookSection = new List<GameObject>();
    public GameObject currentBookOrder;
    //To be used once we can see that player gets the quest
    //public GameObject BookLocation;

    [Header ("Characters in Area?")]
    [SerializeField] private bool playerPresent;
    [SerializeField] private bool npcPresent;
    private GameObject player;
    private GameObject npc;

    [Header("UI")]
    [SerializeField] GameUI gameUI;
    // Start is called before the first frame update
    void Start()
    {
        gameUI = FindObjectOfType<GameUI>().GetComponent<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger on Counter works");
            playerPresent = true;
            player = other.gameObject;
        }
        if (other.CompareTag("NPC"))
        {
            npcPresent = true;
            npc = other.gameObject;
        }
        if (playerPresent == true && npcPresent == true)
        {
            if(player.GetComponent<Player>().order.CurrentState() == false)
            {
                order.InCompleteOrder();
                player.GetComponent<Player>().order = order;
                player.GetComponent<Player>().order.npc = npc;
                GetBookSection();
                currentBookOrder.SetActive(true);
                player.GetComponent<Player>().order.SetOrderActive();
                gameUI.GetOrderInfo(player.GetComponent<Player>().order);
                gameUI.ChangeDetails();

            }
            else if(player.GetComponent<Player>().order.CurrentState() == true && player.GetComponent<Player>().order.OrderState() == true)
            {
                Debug.Log("Order Complete");
                SoundManager.Instance.PlayCashReg();
                player.GetComponent<Player>().AddMoney(player.GetComponent<Player>().order.bookPrice);
                player.GetComponent<Player>().order = new Order();
                gameUI.GetOrderInfo(new Order());
                gameUI.ChangeDetails();
                gameUI.UpdateMoneyVal(player.GetComponent<Player>().GetMoneyAmount());
                //currentBookOrder.SetActive(false);
                npc.GetComponent<AIMovement>().SetTarget(npc.GetComponent<AIMovement>().exit.transform);
                npc.GetComponent<AIMovement>().OrderCompleted();
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
            player.GetComponent<Player>().order = new Order();
            gameUI.GetOrderInfo(new Order());
            gameUI.ChangeDetails();
        }
        
    }
    void GetBookSection()
    {
        //Debug.Log("Book section count= "+BookSection.Count);
        currentBookOrder = BookSection[Random.Range(0,BookSection.Count)];
    }
}
