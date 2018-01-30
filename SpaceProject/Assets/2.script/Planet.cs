using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    public float hp=50;
    public Item ite;
    public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(Player.position,this.transform.position) > 10)//일정거리 이상 벌어지면 소행성을 다시 배치합니다.
        {
            float[] randomnum = new float[3];
            for (int m = 0; m < randomnum.Length; m++)//x,y,z를 랜덤한 방향으로 조금식 움직입니다.
            {
                randomnum[m] = Random.Range(-5, 5);
            }


            transform.position = new Vector3(randomnum[0], randomnum[1], randomnum[2])+ Player.position;
            // this.transform.position +=  Player.position - Player.GetComponent<Rigidbody>().velocity;//
             
        }
	}
    public void damage(float amount)//행성에 데미지를 받을 함수입니다.
    {
        hp -= amount;
        if(hp <= 0)//행성의 체력이 0보다 작아지면
        {
            Debug.Log("아이템생성");
           
            ite.showitem();//행성이 가지고 있는 아이템을 활성화 합니다.
            this.gameObject.GetComponent<Renderer>().enabled = false;//행성을 보여주는 render와 collider를 끕니다.
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
 
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<Planet>() != null)//소행성 끼리의 충돌할시 구현부분
        {


        }
        if(coll.gameObject.GetComponent<SpaceShipCon>() != null)//소행성과 player충돌 구현부분
        {

        }
    }


}
