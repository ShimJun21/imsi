using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiClick : MonoBehaviour {
    //ui클릭을 위한 클래스이다.(C# delegate를 활용)
    // event trigger를 활용하여 trigger가 진입후 home버튼을 누르면 발동(ui부분에 event trigger 넣어야댐)
    //구현해야 하는 부분 tirrger enter될수 진입 ui에따라 delgete 함수 지정해주는 enter와 exit함수
    //일어날 함수 부분

    public delegate void del();
    public del uievent;
    public GameObject GameMgr;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))//레이스 시작테스트용
        {
            racestart();
        }
        if (GvrController.HomeButtonDown)//홈버튼 클릭시 uievnt 지정된게 있을경우 실행
        {
            if(uievent != null)
            {
                uievent();
            }
        }
	}
    public void raceUienter()//레이스 스타트ui진입
    {
        uievent = racestart;
    }
    public void raceUiexit()//레이스 스타트 ui 탈출
    {
        uievent = null;
    }public void endUienter()//레이스 끝 ui
    {
        uievent = raceend;
    }
    public void endUiexit()//레이스 끝 ui
    {
        uievent = null;
    }
    public void racestart()//gameMgr에 레이스 스타트 구현된 함수지정
    {
        GameMgr.GetComponent<makeRing>().racestart();
    }
    public void raceend()//gameMgr에 레이스 끝 구현된 함수지정
    {
        GameMgr.GetComponent<makeRing>().raceend();
    }
   
}
