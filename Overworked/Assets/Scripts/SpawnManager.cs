using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    [Header("Spawning Rate")]
    public float timer;
    public float repeatTimer;
    private ObjectPooler objectPooler;
    //public static SpawnManager Instance;
    //private void Awake()
    //{
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    // end of new code
    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}
    // Start is called before the first frame update

    void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>().GetComponent<ObjectPooler>();
        Invoke("CallPool", 1.0f);
        Invoke("CallPool", 8.0f);
        Invoke("CallPool", 16.0f);

    }
    // Update is called once per frame
    public void CallPool()
    {
        objectPooler.SpawnFromPool("NPC1", spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
