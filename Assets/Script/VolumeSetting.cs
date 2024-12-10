using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SESlider;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs .HasKey ("BGMVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBGMVolume();
            SetSEVolume();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBGMVolume()
    {
        float volume = BGMSlider.value;
        myMixer.SetFloat("BGM", Mathf.Log10 (volume )*20);
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }
    public void SetSEVolume()
    {
        float volume = SESlider.value;
        myMixer.SetFloat("SE", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SEVolume", volume);
    }
    private void LoadVolume()
    {
        BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        SESlider.value = PlayerPrefs.GetFloat("SEVolume");

        SetBGMVolume();
        SetSEVolume();
    }
}
