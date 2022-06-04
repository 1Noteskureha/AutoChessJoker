using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : SingletonMonoBehaviour<AudioPlayer>
{
    private AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(AudioClip ac)
    {
        AS.PlayOneShot(ac);
    }
}
