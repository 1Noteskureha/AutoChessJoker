using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : SingletonMonoBehaviour<AudioPlayer>
{   
    [SerializeField]
    private AudioSource BGM;
    [SerializeField]
    private AudioSource SE;

    private float masterVolume;
    private float BGMVolume;
    private float SEVolume;
    // Start is called before the first frame update
    void Start()
    {
        masterVolume = PlayerPrefs.GetFloat("Volume_Master");
        BGMVolume = PlayerPrefs.GetFloat("Volume_BGM");
        SEVolume = PlayerPrefs.GetFloat("Volume_SE");

        SetMasterVolume(masterVolume);
        SetBGMVolume(BGMVolume);
        SetSEVolume(SEVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BGMPlay(AudioClip ac)
    {
        BGM.Play();
    }

    public void SEPlay(AudioClip ac)
    {
        SE.PlayOneShot(ac);
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        PlayerPrefs.SetFloat("Volume_Master",masterVolume);
        SetBGMVolume(BGMVolume);
        SetSEVolume(SEVolume);
    }

    public void SetBGMVolume(float volume)
    {
        BGMVolume = volume;
        PlayerPrefs.SetFloat("Volume_BGM", BGMVolume);
        BGM.volume = masterVolume * BGMVolume;
    }

    public void SetSEVolume(float volume)
    {
        SEVolume = volume;
        PlayerPrefs.SetFloat("Volume_SE", SEVolume);
        SE.volume = masterVolume * SEVolume;
    }
}
