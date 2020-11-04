using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public Animator TrampolineAnimator;
    public GameObject Player;
    public GameObject TrampolineObj;
    public GameObject SoundFX;

    public float jumpSpeed = 200f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            TrampolineAnimator.Play("Trampoline_Anim");
            Player.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
            //TrampolineObj.GetComponent<AudioSource>().Play();
            SoundFX.GetComponent<SoundFX>().TrampolineAudio.Play();
            

        }
    }

}
