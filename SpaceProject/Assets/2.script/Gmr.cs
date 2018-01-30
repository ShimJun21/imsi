using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gmr : MonoBehaviour {
    public Transform player;
    public Transform plan;
    public Transform[] planeTr;
    public int planety;
	// Use this for initialization
	void Start () {
        makePlant();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void makePlant()
    {
        int count = 0;
        for (int i = 0; i < planety; i++)
        {
          
            for(int j = 0; j < (int)(Mathf.Sqrt(planeTr.Length / 2)) + 1; j++) { 
                for(int k=0;k< (int)(Mathf.Sqrt(planeTr.Length / 2)) + 1; k++)
                {
                    if(count >= planeTr.Length)
                    {
                        break;
                    }
                    planeTr[count].position = new Vector3(j, i, k) + player.position+new Vector3(0,-3);
                    count++;
                    
                }
       
            }

          
        }

    }
}
