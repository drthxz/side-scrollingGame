using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour {

	public float count;
	public float Totalcount;
	// Use this for initialization
	void Start () {
		Totalcount=transform.childCount-1;
	}
	
	// Update is called once per frame
	void Update () {
		count=transform.childCount;
		
	}
}
