using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour {
	public WebCamTexture mCamera = null;
	public GameObject plane;
	// Use this for initialization
	void Start () {
		plane = GameObject.FindWithTag ("cam");

		mCamera = new WebCamTexture ();
		plane.GetComponent<Renderer>().material.mainTexture = mCamera;
		mCamera.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
