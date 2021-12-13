using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Order order;
    [SerializeField] private int moneyEarned;
    [SerializeField] private int playerLives;

    private GameManager gameManager;
    void Start()
    {
        moneyEarned = 0;
        playerLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMoney(int val)
    {
        moneyEarned += val;
    }
    public int GetMoneyAmount()
    {
        return moneyEarned;
    }
    public void ReduceLife()
    {
        --playerLives;
        if (playerLives <= 0)
        {
            gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            gameManager.EndLevel();
        }
    }
}
