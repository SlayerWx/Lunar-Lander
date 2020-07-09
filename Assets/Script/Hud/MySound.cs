using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySound : MonoBehaviour
{
    AudioSource mySound;
    // Start is called before the first frame update
    static bool ready = false;
    void Start()
    {
        if (!ready)
        {
            mySound = GetComponent<AudioSource>();
            if (!mySound.isPlaying)
                mySound.Play();
            mySound.volume = 0.10f;
            DontDestroyOnLoad(transform.gameObject);
            ready = true;  
        }
        else
        {
            Destroy(transform.gameObject);
        }
    } 
    void Update()
    {
        InputSoundControl();
    }
    void InputSoundControl()
    {
        if(Input.GetKeyUp(KeyCode.U))
        {
            mySound.volume -= Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.I))
        {
            mySound.volume += Time.deltaTime;
        }
    }

}
