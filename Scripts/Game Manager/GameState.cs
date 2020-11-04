using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    public GameObject Player;
    public ParticleSystem ParticleSystem;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        ParticleSystem = Player.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Player != null)
        {
            if (Player.GetComponent<InitialMovement>().GameEND == true)
            {
                //Destroy(Player);
                Player.GetComponent<MeshRenderer>().enabled = false;
                Debug.Log("Game END");
                ParticleSystem.Play();
            }
        }
		
	}
}
