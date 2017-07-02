using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class trans : MonoBehaviour {
	public Image transicion;
	float time;
	bool a = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(a)time += Time.deltaTime;
		transicion.DOFade (0f, 5f).OnComplete(setA);
		if (time > 3)
			next ();
	}
	void next(){
		SceneManager.UnloadSceneAsync ("advertiment");
		SceneManager.LoadScene ("intro");
	}
	void setA(){ a = true;}
}
