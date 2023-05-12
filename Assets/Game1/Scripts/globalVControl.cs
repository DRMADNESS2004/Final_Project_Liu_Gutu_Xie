using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalVControl : MonoBehaviour
{
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioListener component of the main camera
        AudioListener audioListener = Camera.main.GetComponent<AudioListener>();

        // Set the initial value of the volume slider to the current global volume
        volumeSlider.value = AudioListener.volume;

        // Add an event listener to the volume slider
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
    }

    private void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
