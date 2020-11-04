using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorialscript : MonoBehaviour {

    public Text TutorialText;
    public GameObject GrappleText;
    public GameObject Player;

    public bool TutInitialChange = false;

    // Use this for initialization
    void Start () {
        //Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (Player != null)
        {
            if (TutorialText.text == "Tap to start" & Player.GetComponent<InitialMovement>().GameStart == true & TutInitialChange == false)
            {
                TutorialText.text = "Tap and hold to attach to the grapple point";
                GrappleText.SetActive(true);
                TutInitialChange = true;
            }

            if (Player.GetComponent<InitialMovement>().CheckIfAttachedCamera == true)
            {
                TutorialText.text = "Release to fire the ball. Hold to gain speed, and to aim";
            }

        }
    }
}
