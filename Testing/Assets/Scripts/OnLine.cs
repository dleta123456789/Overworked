using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLine : MonoBehaviour
{
    [SerializeField] private bool occupied = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTrue()
    {
        occupied = true;
    }
    public void SetFalse()
    {
        occupied = false;
    }
    public bool GetValue()
    {
        return occupied;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            occupied = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            occupied = false;
        }
    }
}
