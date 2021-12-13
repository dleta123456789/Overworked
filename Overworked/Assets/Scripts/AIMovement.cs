using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    //public Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private GameObject player;
    [SerializeField] private Vector3 velo;
    [Header("Path Route")]
    [SerializeField] private List<GameObject> movementPath = new List<GameObject>();
    //[SerializeField] private GameObject exit;
    public GameObject exit;

    [Header("Life Check")]
    [SerializeField] private bool orderstatus=false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        GetPaths();
        //StartCoroutine(Path());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("agent Velocity= " + agent.velocity);
        velo = agent.velocity;
        if (velo == Vector3.zero)
        {
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            animator.SetFloat("Speed", 3.7f);
        }
    }
    IEnumerator Path()
    {
        float time=Time.time;
        yield return new WaitForSeconds(1.0f);
        while (movementPath[0].GetComponent<OnLine>().GetValue() == true)
        {
            yield return null;
        }
        SetTarget(movementPath[0].transform);
        yield return new WaitForSeconds(5.0f);
        while (movementPath[1].GetComponent<OnLine>().GetValue() == true)
        {
            yield return null;
        }
        agent.isStopped = false;
        SetTarget(movementPath[1].transform);
        yield return new WaitForSeconds(5.0f);
        while (movementPath[2].GetComponent<OnLine>().GetValue() == true)
        {
            yield return null;
        }
        SetTarget(movementPath[2].transform);
        yield return new WaitForSeconds(20.0f);
        if(orderstatus == false)
        {
            player.GetComponent<Player>().ReduceLife();
        }
        //player.GetComponent<Player>().order = new Order();
        SetTarget(exit.transform);
    }
    public void SetTarget(Transform linePos)
    {
        agent.SetDestination(linePos.position);
    }

    public void GetPaths()
    {
        List<GameObject> temp;
        temp = GameManager.Instance.GetNodes();
        for(int i = 0; i < temp.Count - 1; ++i)
        {
            movementPath[i]=temp[i];
        }
        exit = temp[temp.Count-1];
    }
    public void StartPath()
    {
        StartCoroutine(Path());
    }
    public void OrderCompleted()
    {
        orderstatus = true;
    }
}
