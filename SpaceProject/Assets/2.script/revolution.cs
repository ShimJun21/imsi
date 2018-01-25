using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolution : MonoBehaviour {

    public float revolutionSpeed;

    public GameObject TargetObj;
	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(TargetObj.transform.position, Vector3.up, revolutionSpeed * Time.deltaTime);
    }
}
