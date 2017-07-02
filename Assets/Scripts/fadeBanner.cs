using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeBanner : MonoBehaviour {
	public GameObject banner;
	// Use this for initialization
	float timer = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= 5){
			banner.SetActive (false);
		}
	}
}
