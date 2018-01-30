

using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class TurretCon : MonoBehaviour {
    public Transform turretz;
    public Transform turrety;
    public GameObject Bulletpre;
    public Transform shotpoint;
    public float damf = 10f;
    public float range = 100f;
    public Light shotLi;
    // Use this for initialization
    Camera ca;

	void Start () {
        ca = Camera.main;
        StartCoroutine(shotdelay());
    }
	
	// Update is called once per frame
	void Update () {
        
        turrety.transform.localRotation = Quaternion.Euler(new Vector3(0, ca.transform.localRotation.eulerAngles.y, 0));

         turretz.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, ca.transform.localRotation.eulerAngles.x));
       

        //if (GvrController.HomeButtonDown||Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject bull=Instantiate(Bulletpre, shotpoint);
        //    bull.transform.parent = null;
        //    bull.GetComponent<bullet>().damf = this.damf;
        //    bull.GetComponent<bullet>().bulletshot(shotpoint.forward);
        //    Destroy(bull, 3f);
        //    ///////////////raycast 활용
            
        //}




    }
    IEnumerator shotdelay()
    {
        while (true) {
        if (GvrController.HomeButtonDown || Input.GetKeyDown(KeyCode.Space))
        {
                shotLi.enabled = true;
                // RayShoot();

                GameObject bull = Instantiate(Bulletpre, shotpoint);
                bull.transform.parent = null;
                bull.GetComponent<bullet>().damf = this.damf;
                bull.GetComponent<bullet>().bulletshot(shotpoint.forward);
                Destroy(bull, 3f);
                yield return new WaitForSeconds(0.5f);
                shotLi.enabled=false;
        }
        yield return null;
        }

    }
    void RayShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(shotpoint.position, shotpoint.transform.forward, out hit, range))
        {
            Planet target = hit.transform.GetComponent<Planet>();
            if (target != null)
            {
                
                target.damage(damf);

            }
        }
    }


}
