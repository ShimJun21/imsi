using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    public float hp=50;
    public Item ite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void damage(float amount)
    {
        hp -= amount;
        if(hp <= 0)
        {
            Debug.Log("아이템생성");
            ite.gameObject.SetActive(true);
            ite.showitem();
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
 
        }
    }

    
}
