using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioManager am;
    
    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackgroundSpaceMusic()
    {
        am.Play("Space");
    }

    public void Clicking()
    {
        am.Play("Click");
    }
}
