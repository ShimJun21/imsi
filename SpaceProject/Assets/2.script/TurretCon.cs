

using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class TurretCon : MonoBehaviour {
    /// <summary>
    /// 터렛의 움직임과 터렛의 발사체를 위한함수
    /// 터렛 오브젝트에 넣어주고
    /// 터렛의 y축과 z축을 움직일 때 자연스러운 방향이 나오게 turrety,turretz에 hierachy뷰에 서 움직일 부분을 정해줍니다.
    /// Bulletpre총알 프리펩을 지정해주어야합니다.
    /// shotpoint 터렛의 앞방향으로 빈 오브젝트를 배치후 hierarchy뷰에서 배치해줍니다.
    /// shoyLi총알이 나가는 이펙트를 라이트로 했습니다. 다른것으로 해도 됩니다.hierarchy뷰에서 라이트 오브젝트넣어줍시다.
    /// </summary>

    public Transform turretz;//터렛의 z축회전 
    public Transform turrety;//터렛의 y축
    public GameObject Bulletpre;//총알 프리펩
    public Transform shotpoint;//총알 발사 위치
    public float damf = 10f;//총알 데미지
    public float range = 100f;//레이캐스트 발사 범위
    public Light shotLi;//총알 쏘는 이펙트를 위해 라이트
    // Use this for initialization
    Camera ca;

    void Start()
    {
        ca = Camera.main;
        StartCoroutine(shotdelay());//총알 발사의 딜레이를 위해 코루틴을 활용
    }
    
	// Update is called once per frame
	void Update () {
        //플레이어의 이동에 따라 카메라의 방향이 world좌표로할시 변하기 때문에 터렛이 이상하게 움직임으로 이동과 관련없게 하기위해 local의 회전을 받아서 움직인다.
        turrety.transform.localRotation = Quaternion.Euler(new Vector3(0, ca.transform.localRotation.eulerAngles.y, 0));


         turretz.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, ca.transform.localRotation.eulerAngles.x));


        //if (GvrController.AppButtonDown||Input.GetKeyDown(KeyCode.Space)) 발사딜레이가 없다. 발사딜레이를 위해 코루틴 활용
        //{
        //    GameObject bull=Instantiate(Bulletpre, shotpoint);
        //    bull.transform.parent = null;
        //    bull.GetComponent<bullet>().damf = this.damf;
        //    bull.GetComponent<bullet>().bulletshot(shotpoint.forward);
        //    Destroy(bull, 3f);
        //    ///////////////raycast 활용
        // RayShoot();//레이캐스트 발사
        //}




    }
    IEnumerator shotdelay()//발사 딜레이를 줄 코루틴
    {
        while (true) {
        if (GvrController.AppButtonDown || Input.GetKeyDown(KeyCode.Space))//컨트롤러의 홈버튼 또는 space를 누를경우(space는 테스트를위해)
        {
                shotLi.enabled = true;//효과를 주기위해 라이트를 넣었다.
                RayShoot();//레이캐스트 발사
                CreateBull();//총알생성
   
                yield return new WaitForSeconds(0.5f);//0.5초후에 라이트를 끄기위해
                shotLi.enabled=false;
        }
        yield return null;
        }

    }
    void CreateBull()
    {
        GameObject bull = Instantiate(Bulletpre, shotpoint);//우선 총알 프리팹을 이용하여 총알을 생성한다.
        bull.transform.parent = null;//총알의 부모를 null로 해주어 플레이어 움직임에서 벗어나게 해준다.
        bull.GetComponent<bullet>().damf = this.damf;//총알의 데미지를 설정해준다.
        bull.GetComponent<bullet>().bulletshot(shotpoint.forward);//총알을 움직이게 한다.
        Destroy(bull, 3f);//총알을 3초이후에 없앤다.
    }
    void RayShoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(shotpoint.position, shotpoint.transform.forward, out hit, range))//(발사위치,발사방향,부딛힌 객체저장위치,범위)
        {
            Planet target = hit.transform.GetComponent<Planet>();////레이출캐스트 부딛힌 객체에서 행성 클래스를 검출
            if (target != null)//행성이라면데미지를 줌
            {
                
                target.damage(damf);

            }
        }
    }


}
