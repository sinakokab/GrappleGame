using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {

    public AudioClip Fan;
    public AudioClip Trampoline;
    public AudioClip PlayerCollision;
    public AudioClip PlayerJump;
    public AudioClip Fireworks;

    public AudioSource FanAudio;
    public AudioSource TrampolineAudio;
    public AudioSource PlayerCollisionAudio;
    public AudioSource PlayerJumpAudio;
    public AudioSource FireWorkAudio;

    // Use this for initialization
    void Start () {


        FanAudio.clip = Fan;
        TrampolineAudio.clip = Trampoline;
        PlayerCollisionAudio.clip = PlayerCollision;
        PlayerJumpAudio.clip = PlayerJump;
        FireWorkAudio.clip = Fireworks;

        FanAudio.loop = false;
        TrampolineAudio.loop = false;
        PlayerCollisionAudio.loop = false;
        PlayerJumpAudio.loop = false;
        FireWorkAudio.loop = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
