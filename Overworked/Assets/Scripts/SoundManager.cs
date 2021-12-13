using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource audioSource;
    [Header("Audio Clips")]
    [SerializeField] AudioClip bellSound;
    [SerializeField] AudioClip cashReg;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBell()
    {
        audioSource.PlayOneShot(bellSound, 1f);
    }
    public void PlayCashReg()
    {
        audioSource.PlayOneShot(cashReg, 1f);
    }
}
