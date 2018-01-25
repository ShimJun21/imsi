using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCon : MonoBehaviour {
    public Transform turretz;
    public Transform turrety;
    public GameObject Bulletpre;
    public Transform shotpoint;
    // Use this for initialization
    Camera ca;
	void Start () {
        ca = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

        turrety.transform.rotation = Quaternion.Euler(new Vector3(turrety.rotation.x, ca.transform.rotation.eulerAngles.y+90, turrety.rotation.z));

         turretz.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, ca.transform.rotation.eulerAngles.x));

        
        if (GvrController.HomeButtonDown)
        {
            GameObject bull=Instantiate(Bulletpre, shotpoint);
            bull.transform.parent = null;
            bull.GetComponent<bullet>().bulletshot(shotpoint.forward);
            Destroy(bull, 3f);
        }


    }

}
