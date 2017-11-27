using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Sound_Button : MonoBehaviour {

    public SoundPlayOneshot buttonPressedSound;

    private void Start()
    {

    }
   
    public void PlaySoundButtonPushed()
    {
        buttonPressedSound.Play();
    }
}
