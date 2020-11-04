using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Lock : MonoBehaviour {


    public List<GameObject> PressurePadList;

    public GameObject[] PressurePads;
    public GameObject PressureLock;
    public GameObject Player;

    //public  PressureLockUnlockedMat;
    public Animator PressureLockUnlocking;

    public bool PressureLockUnlocked = false;

	// Use this for initialization
	void Start () {

        //List<GameObject> PressurePadList = new List<PressurePadList>;
        PressurePads = GameObject.FindGameObjectsWithTag("Pressure_Pad");

        Debug.Log(PressurePadList);


    }
	
	// Update is called once per frame
	void Update () {
		if (Player != null && PressureLockUnlocked == false)
        {
            CheckPressurePads();
        }
	}

    void CheckPressurePads ()
    {
        float NumberOfPressurePads = 0f;
        float NumberOfPressurePadsHit = 0f;

        foreach (GameObject PressurePad in PressurePads)
        {
            NumberOfPressurePads += 1;
            if (PressurePad.GetComponent<PressurePad>().PressurePadHit == true)
            {
                //Debug.Log("Pressure Pad " + NumberOfPressurePads + " was hit");
                NumberOfPressurePadsHit += 1;

            }
        }

        if (NumberOfPressurePads == NumberOfPressurePadsHit)
        {
            //Debug.Log("All Pressure Pads were hit.");
            PressureLockUnlocked = true;
            PressureLock.GetComponent<PolygonCollider2D>().enabled = false; //Change colour from red(locked) to green (unlocked)

            PressureLockUnlocking.SetBool("AllPadsHit", true);

            //Renderer rend = PressureLock.GetComponent<Renderer>();
            //rend.material = PressureLockUnlockedMat;
            //rend.material.shader = Shader.Find("_Color");
            //rend.material.SetColor("_Color", new Color(255/255f, 0f, 0f, 255/255f));
            //PressureLock.GetComponent<Renderer>().material.SetColor("Green", Color.green);//.material.color = Color.green;
        }
    }

}
