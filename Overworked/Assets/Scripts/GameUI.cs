using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
    [Header ("HUD")]
    public TMP_Dropdown dropDownOrder;
    public TextMeshProUGUI moneyText;
    public Order currentPlayerorder;
    [Header("Menus")]
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject Panel;

    public int gameState = 0; //0 for playing,1 for paused, 2 for exit

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }
    public void ChangeDetails()
    {
        //First should be Book title;
        //Debug.Log("Something here: "+currentPlayerorder.bookTitile);
        dropDownOrder.options[1].text = "Book Title: " + currentPlayerorder.bookTitile;
        dropDownOrder.options[2].text = "Book Price: " + currentPlayerorder.bookPrice;

    }
    public void GetOrderInfo(Order order)
    {
        currentPlayerorder = order;
        Debug.Log(order.bookTitile);
    }
    public void UpdateMoneyVal(int val)
    {
        moneyText.text = "Money: " + val.ToString();
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ChangeState(int val)
    {
        gameState = val;
    }
    public void ResumeGame()
    {
        ChangeState(0);
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        Panel.SetActive(false);


    }
    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeState(1);
            Time.timeScale = 0;
            Panel.SetActive(true);
            PauseMenu.SetActive(true);
        }
    }
    public void levelOVer()
    {
        ChangeState(2);
        Time.timeScale = 0;
        Panel.SetActive(true);
        GameOverMenu.SetActive(true);
    }
}
