using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 아이템에 관한 스크립트들(소행성 부수면 나오는 아이템)
/// 아이템 오브젝트에 추가해줍시다.
/// </summary>
public class Item : MonoBehaviour {
    public float upAmount;//아이템 업그레이드 양
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void showitem()
    {
        gameObject.SetActive(true);//아이템 활성화 부분
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//플레이어와 부딛혔을경우 무기 업그레이드 해줍니다.
        {
            Debug.Log("up");
            other.GetComponent<SpaceShipCon>().turretUpgrade(upAmount);
        }
    }
}
