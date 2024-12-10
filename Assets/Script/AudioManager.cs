using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Souce")]
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SESource;

    [Header ("Audio Clip")]
    public AudioClip background;
    public AudioClip creamHit;
    public AudioClip candleHit;
    public AudioClip enemyDeath;
    public AudioClip skill2_SE;
    public AudioClip normalHit;
    // Start is called before the first frame update
    void Start()
    {
        BGMSource.clip = background;
        BGMSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySE(AudioClip clip )
    {
        SESource.PlayOneShot(clip);
    }
    public void StopBGM()
    {
        BGMSource.Stop();
    }
}
