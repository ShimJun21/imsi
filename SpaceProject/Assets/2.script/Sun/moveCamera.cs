using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour {

    public float moveSpeed;
    private Transform tr;


    // Use this for initialization
    void Start () {

        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        tr.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);

        //this.transform.rotation = Quaternion.LookRotation(lookDirection.);
        //this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        
	}
}
