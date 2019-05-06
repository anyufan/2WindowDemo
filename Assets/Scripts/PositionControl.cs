using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControl : MonoBehaviour {
    public static List<GameObject> windowList = new List<GameObject>();
    public static GameObject[] windowArray;
    public static GameObject currentWindow;
	// Use this for initialization
	void Start () {
        windowArray = GameObject.FindGameObjectsWithTag("Player");


        for (int i = 0; i < windowArray.Length; i++)
        {
            Debug.Log(windowArray[i].name); 
            //windowArray[i].transform.Find("Col_1").GetComponent<AbsorbCol_1>().enabled = false;
            //windowArray[i].transform.Find("Col_2").GetComponent<AbsorbCol_2>().enabled = false;
            //windowArray[i].transform.Find("Col_3").GetComponent<AbsorbCol_3>().enabled = false;
            //windowArray[i].transform.Find("Col_4").GetComponent<AbsorbCol_4>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
