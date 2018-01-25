using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float movespeed = 4f;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	   	
	}
    public void bulletshot(Vector3 forwardVec)
    {
        gameObject.GetComponent<Rigidbody>().velocity =forwardVec* movespeed * Time.deltaTime;
    }
}
