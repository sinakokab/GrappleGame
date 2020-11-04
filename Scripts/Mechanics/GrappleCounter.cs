using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrappleCounter : MonoBehaviour {

    //public GameObject RopeController;
    public Text GrappleCounterText;
    public float NumberOfGrapples;
    public GameObject Player;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //RopeController = GameObject.FindGameObjectWithTag("GrapplePoint");
        GrappleCounterText.text = ("GRAPPLES: " + NumberOfGrapples);//GameObject.FindGameObjectWithTag("GrapplePoint").GetComponent<RopeController>().NumberOfGrapples);

        if (Player == null)
        {
            gameObject.SetActive(false);
        }


    }
}
