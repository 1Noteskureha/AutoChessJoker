using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{       
    [SerializeField]
    private Slider MasterSlider;
    [SerializeField]
    private Slider BGMSlider;
    [SerializeField]
    private Slider SESlider;

    // Start is called before the first frame update
    void Start()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("Volume_Master");
        BGMSlider.value = PlayerPrefs.GetFloat("Volume_BGM");
        SESlider.value = PlayerPrefs.GetFloat("Volume_SE");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Apply()
    {   
        AudioPlayer.Instance.SetMasterVolume(MasterSlider.value);
        AudioPlayer.Instance.SetBGMVolume(BGMSlider.value);
        AudioPlayer.Instance.SetSEVolume(SESlider.value);
        this.gameObject.SetActive(false);

    }

    public void NoApply()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("Volume_Master");
        BGMSlider.value = PlayerPrefs.GetFloat("Volume_BGM");
        SESlider.value = PlayerPrefs.GetFloat("Volume_SE");
        this.gameObject.SetActive(false);

    }
}
