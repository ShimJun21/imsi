using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCon : MonoBehaviour {
    public Transform Controller;
   
   
    public float de;
	// Use this for initialization
	void Start () {
		
	}
    public Quaternion controllerv;
    //public Vector3 controllerv;
    public Vector3 imsi;
    // Update is called once per frame
    void Update () {
        if (GvrController.AppButton)
        {
            if (gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = this.transform.forward * 5f;
            }
            }

            this.gameObject.transform.rotation = Quaternion.Euler(GvrController.Orientation.eulerAngles);
        imsi =new Vector3(GvrController.Orientation.eulerAngles.x-180, GvrController.Orientation.eulerAngles.y-180, GvrController.Orientation.eulerAngles.z-180);
        imsi = imsi / 180;


    }
}
