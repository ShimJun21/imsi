using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//레이캐스트로 총알을발사해줄 법위
/// <summary>
/// 레이캐스트 실험을 위해 만든 스크립트 실제 프로젝트에서 안쓰입니다.
/// 
/// </summary>
public class shotbullet : MonoBehaviour {
    public float damf = 10f;//총알 데미지
    public float range = 100f;//레이캐스트 발사 범위
    public Transform shotpoint;//레이캐스트 발사 위치
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(shotpoint.position, shotpoint.transform.forward, out hit, range))//(발사위치,발사방향,부딛힌 객체저장위치,범위)
        {
            Planet target = hit.transform.GetComponent<Planet>();//레이출캐스트 부딛힌 객체에서 행성 클래스를 검
            if (target != null)//행성이라면데미지를 줌
            {
                target.damage(damf);
            }
        }
    }
}
