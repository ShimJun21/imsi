using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float movespeed = 4f;
    public float damf;
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
    private void OnTriggerEnter(Collider other)
    {
        Planet target = other.transform.GetComponent<Planet>();
        if (target != null)
        {
            target.damage(damf);
        }
    }
}
