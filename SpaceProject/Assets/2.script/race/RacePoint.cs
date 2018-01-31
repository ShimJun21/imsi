using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RacePoint : MonoBehaviour {
    /// <summary>
    /// 링들이 trigger와 닿았을때 점수 상승을 위해 Ring프리펩에 스크립트를 추가해야합니다.
    /// </summary>
    public makeRing Gmr;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
      
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//player와 닿을시 점수 상승과 링을 삭제
        {
            Gmr.upPoint();
            Destroy(this);
        }
    }
}
