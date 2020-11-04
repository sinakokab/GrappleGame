using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour {

    public GameObject PressurePadObj;
    public Material PressurePadUnlockedMat;

    public bool PressurePadHit = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PressurePadHit = true;

            Renderer rend = PressurePadObj.GetComponent<Renderer>();
            rend.material = PressurePadUnlockedMat;

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
