using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint_Platform : MonoBehaviour {

    public GameObject GrapplePlatform;
    public float moveSpeed = 1;

    public Vector3 startPoint;
    public Vector3 endPoint;
    public float endpointdifference;
    public bool DownOrUp;

    public bool hasreachedendpoint;


    //Two alternatives, either add a start/end gameobject or make the platform move + or - 10 units its start position.


	// Use this for initialization
	void Start () {


        startPoint = (GrapplePlatform.transform.position);

        if (endpointdifference == 0f)
        {
            if (DownOrUp == true)
            {
                endPoint = new Vector3(GrapplePlatform.transform.position.x, GrapplePlatform.transform.position.y + 8, 0);
            }
            else if (DownOrUp == false)
            {
                endPoint = new Vector3(GrapplePlatform.transform.position.x, GrapplePlatform.transform.position.y - 8, 0);
            }
        }
        else if (endpointdifference > 0f)
        {
            Debug.Log(gameObject.name);
            if (DownOrUp == true)
            {
                endPoint = new Vector3(GrapplePlatform.transform.position.x, GrapplePlatform.transform.position.y + endpointdifference, 0);
                Debug.Log("true: " + gameObject.name);
            }
            else if (DownOrUp == false)
            {
                endPoint = new Vector3(GrapplePlatform.transform.position.x, GrapplePlatform.transform.position.y - endpointdifference, 0);
                Debug.Log("false: " + gameObject.name);
            }

        }


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (GrapplePlatform.transform.position == endPoint)
        {
            hasreachedendpoint = true;
        } else if (GrapplePlatform.transform.position == startPoint)
        {
            hasreachedendpoint = false;
        }

        if (GrapplePlatform.transform.position != endPoint && hasreachedendpoint == false )
        {
            GrapplePlatform.transform.position = Vector3.MoveTowards(GrapplePlatform.transform.position, endPoint, Time.deltaTime * moveSpeed);
            GrapplePlatform.GetComponent<RopeController>().area.center = GrapplePlatform.transform.position; //Move bounds along with platform
        } else if (GrapplePlatform.transform.position != startPoint)
        {
            GrapplePlatform.transform.position = Vector3.MoveTowards(GrapplePlatform.transform.position, startPoint, Time.deltaTime * moveSpeed);
        }

	}
}
