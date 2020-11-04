using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour {

    public GameObject Player;
    public GameObject FanPath;
    public GameObject SoundFXManager;
    public float windMoveSpeed = 1000f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Object entered trigger");
    }
    void OnTriggerStay2D(Collider2D other)
    { 

        //Debug.Log("Object is in trigger");
        
        if (other.name == "Player")
        {
            Player.GetComponent<Rigidbody2D>().AddForce(transform.up * windMoveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            //Debug.Log("WIND");
            SoundFXManager.GetComponent<SoundFX>().FanAudio.Play();
        }
        

    }
    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Object left the trigger");
    }

}
