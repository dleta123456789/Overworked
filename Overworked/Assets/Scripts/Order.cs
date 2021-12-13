using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{
    [SerializeField]private bool isActive;
    [SerializeField]private bool orderComplete;

    public GameObject npc;
    public string bookTitile;
    public int  bookPrice;

    public void SetOrderActive()
    {
        isActive = true;
    }
    public void SetOrderInActive()
    {
        isActive = false;
    }
    public bool CurrentState()
    {
        return isActive;
    }
    public void CompleteOrder()
    {
        orderComplete = true;
    }
    public void InCompleteOrder()
    {
        orderComplete = false;
    }
    public bool OrderState()
    {
        return orderComplete;
    }
}
