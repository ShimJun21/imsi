using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotbullet : MonoBehaviour {
    public float damf = 10f;
    public float range = 100f;
    public Transform shotpoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(shotpoint.position, shotpoint.transform.forward, out hit, range))
        {
            Planet target = hit.transform.GetComponent<Planet>();
            if (target != null)
            {
                target.damage(damf);
            }
        }
    }
}
