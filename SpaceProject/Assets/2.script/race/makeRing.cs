using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

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
        racePoint = 0;
        sw = new Stopwatch();
        Timetext.text = string.Format("{0:D2}", (sw.Elapsed.Minutes)) + ":" + string.Format("{0:D2}", (sw.Elapsed.Seconds));
  
    }
	
	// Update is called once per frame
	void Update () {
        PointText.text = racePoint.ToString();
	}
    public void racestart()
    {
        float dis = Vector3.Distance(start.transform.position, end.transform.position);
        Vector3 disVec = -1 * (start.position - end.position);
        for (int i = 0; i < dis; i = i + 10)
        {

            GameObject ga = Instantiate(Ring);

            ga.transform.position = start.position + disVec.normalized * i;
            float yrange = 2f;
            float ydown = Random.Range(-yrange, yrange);
            ga.transform.localPosition += new Vector3(0, ydown);
            ga.transform.parent = startPoint;
        }
        sw.Start();
    }
    public void raceend()
    {
        sw.Stop();
        start.gameObject.SetActive(false);
    }
    public void upPoint()
    {
        racePoint += 100;
    }
}
