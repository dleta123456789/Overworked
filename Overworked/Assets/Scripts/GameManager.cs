using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> pathNodes= new List<GameObject>();
    public static GameManager Instance;
    private GameUI gameUI;
    public bool GameOver;
    private void Awake()
    {
        if (Instance != null)
        {
            Instance.FindPaths();
            Time.timeScale = 1;
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        FindPaths();
        Time.timeScale = 1;
        //Instance.FindPaths();
        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        FindPaths();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<GameObject> GetNodes()
    {
        return pathNodes;
    }
    public void EndLevel()
    {
        gameUI = FindObjectOfType<GameUI>().GetComponent<GameUI>();
        gameUI.levelOVer();
    }
    public void FindPaths()
    {
        var temp = GameObject.FindGameObjectWithTag("OrderLine");
        int childCount = temp.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            pathNodes[i] = temp.transform.GetChild(i).gameObject;
        }
        Debug.Log("Find Paths is running");
    }
}
