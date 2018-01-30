using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 전체 적인 게임 매니저를 위한 클래스 입니다.
/// </summary>
public class Gmr : MonoBehaviour {
    public Transform player;

    public Transform[] planeTr;//행성들을 넣을 배열입니다. hierarchy에서 추가해줍니다.
    public int planety;//행성 y줄을 정해줄 겁니다.
	// Use this for initialization
	void Start () {
        makePlant();//소행성을 만들 함수입니다.

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void makePlant()
    {
        int count = 0;
        for (int i = 0; i < planety; i++)//y줄만큼 for를 돌립니다.
        {
          
            for(int j = 0; j < (int)(Mathf.Sqrt(planeTr.Length / planety))+1; j++) { // 총 행성의 수를 y줄의 개수 만큼 나누어 루트를 해 n을 구해서  n*n의 배열의 행성 배열을 만듭니다.
                for(int k=0;k< (int)(Mathf.Sqrt(planeTr.Length / planety)); k++)
                {
                    if(count >= planeTr.Length)//만약 몇의 개수보다 많이 실행하면 아무것도 안합니다.
                    {
                        break;
                    }
                    planeTr[count].position = new Vector3(j*3, i*3, k*3) + player.position+new Vector3(0,-3);//player의 위치에 3*3*3정도 사이를 두고 생성합니다.
                    float[] randomnum = new float[3];
                    for (int m = 0; m < randomnum.Length; m++)//x,y,z를 랜덤한 방향으로 조금식 움직입니다.
                    {
                        randomnum[m] = Random.Range(-2, 2);
                    }


                    planeTr[count].position += new Vector3(randomnum[0], randomnum[1], randomnum[2]);
                    count++;
                    
                }
       
            }

          
        }

    }
}
