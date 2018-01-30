using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiClick : MonoBehaviour {
    public delegate void del();
    public del uievent;
    public GameObject GameMgr;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            racestart();
        }
        if (GvrController.HomeButtonDown)
        {
            if(uievent != null)
            {
                uievent();
            }
        }
	}
    public void raceUienter()
    {
        uievent = racestart;
    }
    public void raceUiexit()
    {
        uievent = null;
    }public void endUienter()
    {
        uievent = raceend;
    }
    public void endUiexit()
    {
        uievent = null;
    }
    public void racestart()
    {
        GameMgr.GetComponent<makeRing>().racestart();
    }
    public void raceend()
    {
        GameMgr.GetComponent<makeRing>().raceend();
    }
}
