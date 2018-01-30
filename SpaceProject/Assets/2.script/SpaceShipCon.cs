using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCon : MonoBehaviour {

    public float TurretUp;

    // Use this for initialization
    void Start () {
        
    }
    public Vector3 controllermove;
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
         
         }
        if (GvrController.IsTouching)
        {
            spaceSpeed();
        }
        ControllerMove();



    }
    public void spaceSpeed()
    {

        if (GvrController.TouchPos.x > 0.1 && GvrController.TouchPos.x < 0.45)
        {
            gameObject.GetComponent<Rigidbody>().velocity += transform.forward*Time.deltaTime;
        }
        else if (GvrController.TouchPos.x > 0.55 && GvrController.TouchPos.x < 0.9)
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.z >=0) { 
                gameObject.GetComponent<Rigidbody>().velocity -= transform.forward * Time.deltaTime;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

        }
        else
        {

        }
      
    }
    public void turretUpgrade(float amount)
    {
        TurretUp += amount;
        if (TurretUp > 30 && TurretUp < 50)
        {
            Debug.Log("버전2");
        }
        else if (TurretUp > 50 && TurretUp < 80)
        {
            Debug.Log("버전3");
        }

    }
    void ControllerMove()
    {
        controllermove = GvrController.Orientation.eulerAngles;

        if (controllermove.x > 270 && controllermove.x < 360)
        {
            Debug.Log("22");
            float xup = (360 - controllermove.x) / 90f;
            this.transform.Rotate(Vector3.right * 10 * -xup * Time.deltaTime);
        }
        else if (controllermove.x > 0 && controllermove.x < 90)
        {
            float xup = controllermove.x / 90f;
            this.transform.Rotate(Vector3.right * 10 * xup * Time.deltaTime);
        }
        if (controllermove.y > 270 && controllermove.y < 360)
        {
            float yup = (360 - controllermove.y) / 90f;
            this.transform.Rotate(Vector3.up * 10 * -yup * Time.deltaTime);
        }
        else if (controllermove.y > 0 && controllermove.y < 90)
        {
            float yup = controllermove.y / 90f;
            this.transform.Rotate(Vector3.up * 10 * yup * Time.deltaTime);
        }
        if (controllermove.z > 270 && controllermove.z < 360)
        {
            float zup = (360 - controllermove.z) / 90f;
            this.transform.Rotate(Vector3.forward * 10 * -zup * Time.deltaTime);
        }
        else if (controllermove.z > 0 && controllermove.z < 90)
        {
            float zup = controllermove.z / 90f;
            this.transform.Rotate(Vector3.forward * 10 * zup * Time.deltaTime);
        }
    }

}

//  this.gameObject.transform.rotation = Quaternion.Euler(GvrController.Orientation.eulerAngles);
//imsi =new Vector3(GvrController.Orientation.eulerAngles.x-180, GvrController.Orientation.eulerAngles.y-180, GvrController.Orientation.eulerAngles.z-180);
// imsi = imsi / 180;
