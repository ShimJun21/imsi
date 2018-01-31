using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCon : MonoBehaviour {
    /// <summary>
    /// 우주선의 움직임을 컨틀롤 해줄 함수
    /// 움직일 플레이어 오브젝트에 추가해 줍니다.
    /// </summary>
    public float TurretUp;
    public float rotate = 20;
    public int playerhp=100;
    // Use this for initialization
    void Start () {
        
    }
    public Vector3 controllermove;
    //public Vector3 controllerv;

    // Update is called once per frame
    void Update () {
      
        //if (GvrController.AppButton)//버튼이 부족하여 삭제
        //{
        //    if (gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero)
        //    {
        //        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        //    }
         
        // }
        if (GvrController.IsTouching)//우주선의 스피드를 조절하기위한 부분
        {
            spaceSpeed();
        }
        ControllerMove();//컨트롤러의 방향에 따라 회전



    }
    public void spaceSpeed()
    {

        if (GvrController.TouchPos.y > 0.1 && GvrController.TouchPos.y < 0.45)//터치패드 위부분일 경우 속도를 점점 올려준다.
        {
            gameObject.GetComponent<Rigidbody>().velocity += transform.forward*Time.deltaTime;
        }
        else if (GvrController.TouchPos.y > 0.55 && GvrController.TouchPos.y < 0.9)//터치패드 아래부분일 경우 속도를 낮춰준다
        {
                  //lerp를 사용하여 0에 가까운값 나오게 만듬
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.Lerp(gameObject.GetComponent<Rigidbody>().velocity, Vector3.zero, 5f*Time.deltaTime);
          
        }
        else
        {

        }
      
    }
    public void turretUpgrade(float amount)//터렛을 업그레이드 시키는 함수
    {
        TurretUp += amount;
        if (TurretUp > 30 && TurretUp < 50)//2버전 터렛 모델을 구하고 구현
        {
            Debug.Log("버전2");
        }
        else if (TurretUp > 50 && TurretUp < 80)//3버전 터렛 모델을 구하고 구현
        {
            Debug.Log("버전3");
        }

    }

    void ControllerMove()//컨트롤러의 회전에 따라 현재 우주선의 방향을 바꿈
    {
        controllermove = GvrController.Orientation.eulerAngles;
 
        if (controllermove.x > 270 && controllermove.x < 360)//컨트롤러의x의 방향이 위쪽방향일때
        {
           
            float xup = (360 - controllermove.x) / 90f;//0~1사이의 값을 추출해 움직인만큼 큰회전을 주기위한 변수
            this.transform.Rotate(Vector3.right * rotate * -xup * Time.deltaTime);
        }
        else if (controllermove.x > 0 && controllermove.x < 90)//컨트롤러의x의 방향이 아래방향일때
        {
            float xup = controllermove.x / 90f;
            this.transform.Rotate(Vector3.right * rotate * xup * Time.deltaTime);
        }
        if (controllermove.y > 270 && controllermove.y < 360)
        {
            float yup = (360 - controllermove.y) / 90f;
            this.transform.Rotate(Vector3.up * rotate * -yup * Time.deltaTime);
        }
        else if (controllermove.y > 0 && controllermove.y < 90)
        {
            float yup = controllermove.y / 90f;
            this.transform.Rotate(Vector3.up * rotate * yup * Time.deltaTime);
        }
        if (controllermove.z > 270 && controllermove.z < 360)
        {
            float zup = (360 - controllermove.z) / 90f;
            this.transform.Rotate(Vector3.forward * rotate * -zup * Time.deltaTime);
        }
        else if (controllermove.z > 0 && controllermove.z < 90)
        {
            float zup = controllermove.z / 90f;
            this.transform.Rotate(Vector3.forward * rotate * zup * Time.deltaTime);
        }
    }
    public void playerDamage(int damage)//player에게 damage를 줍니다.
    {
        playerhp -= damage;
    }
}

