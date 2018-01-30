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
        gameObject.GetComponent<Rigidbody>().velocity =forwardVec* movespeed * Time.deltaTime;//총알이 터렛이 가리키는 앞방향 벡터로 movespeed만큼 나가게함
    }
    private void OnTriggerEnter(Collider other)//총알이 행성과 부딛혔을때 데미지 주기
    {
        Planet target = other.transform.GetComponent<Planet>();//트리거가 일어났을때 부딛힌 오브젝트에서 Planet 클래스를 가져온다
        if (target != null)//planet이 null이 아니면 행성임
        {
            target.damage(damf);//데미지 주는 함수 소환 데미지는 총알을 생성해줄때 정해줌
            Destroy(gameObject);//총알 삭제
        }
    }
}
