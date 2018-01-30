using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Diagnostics;//stopwatch를 활용하기 위해 지정해줘야 한다. 만약 debug를 사용하려면 using debug = UnityEngine.Debug;를 써주어야한다.



public class makeRing : MonoBehaviour {
    public Transform start;
    public Transform end;
    public GameObject Ring;
    public Transform startPoint;
    public Transform Player;
    public Stopwatch sw;
    public float racePoint;
    public Text PointText;
    public Text Timetext;



    // Use this for initialization
    void Start () {
        racePoint = 0;//레이스 점수 시작시 0
        sw = new Stopwatch();//스톱워치는 할당을 해주엉 한다.
       
    }
	
	// Update is called once per frame
	void Update () {
        PointText.text = racePoint.ToString();//레이스 포인트와 ui포인트 일치를 위해
        Timetext.text = string.Format("{0:D2}", (sw.Elapsed.Minutes)) + ":" + string.Format("{0:D2}", (sw.Elapsed.Seconds));//string.Format("인덱스:진수 자리수",값)을 활용하여 00:00 string값 만들기

    }
    public void racestart()
    {
        float dis = Vector3.Distance(start.transform.position, end.transform.position);
        Vector3 disVec = -1 * (start.position - end.position);//시작에서 끝까지의 벡터를 구함
        for (int i = 0; i < dis; i = i + 20)//스타트 위치에서 떨어진 거리의 일정 거리마다 링만들기 위한 반복문
        {

            GameObject ga = Instantiate(Ring);//링 프리펩을 만든후

            ga.transform.position = start.position + disVec.normalized * i;//링의 위치를 시작위치에서 시작에서 끝까지 구한 방향벡터에 일정거리i 마다 만들기
            float yrange = 2f;//랜덤방향으로 y를내리기위한 벼누
            float ydown = Random.Range(-yrange, yrange);
            ga.transform.localPosition += new Vector3(0, ydown);//현재 위치에서 랜덤범위로 y축을 내림
            ga.transform.parent = startPoint;//행성이 돌아가기 때문에 같이 돌기위해 부모설정
        }
        sw.Start();//스탑워치 시작
    }
    public void raceend()//레이스가 끝날시 실행할 함수
    {
        sw.Stop();//스탑워치를 멈춘다
        start.gameObject.SetActive(false);//링을 다끈다.
    }
    public void upPoint()
    {
        racePoint += 100;//링과 만날시 포인트 상승
    }
}
