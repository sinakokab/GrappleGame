using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSounds : MonoBehaviour {

    public GameObject SoundFXManager;
    public GameObject SubParticleEmitter;
    public bool PlayOnce = false;

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
        if (SubParticleEmitter.active == true && PlayOnce == false)
        {
            SoundFXManager.GetComponent<SoundFX>().FireWorkAudio.Play();
            PlayOnce = true;
        }

	}
}
