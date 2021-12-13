using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIMovement : MonoBehaviour
{
    //public Transform target;
    private NavMeshAgent agent;
    [Header("Path Route")]
    [SerializeField] private List<GameObject> movementPath = new List<GameObject>();
    [SerializeField] private GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetPaths();
        //StartCoroutine(Path());
    }

    // Update is called once per frame
    void Update()
    {

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
        SetTarget(movementPath[1].transform);
        yield return new WaitForSeconds(5.0f);
        while (movementPath[2].GetComponent<OnLine>().GetValue() == true)
        {
            yield return null;
        }
        SetTarget(movementPath[2].transform);
        yield return new WaitForSeconds(20.0f);
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
}
