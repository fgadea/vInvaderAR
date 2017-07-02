using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class instanciator2 : MonoBehaviour {
	//public Material materialDefault;
	public GameObject objAInstanciar;
	public Transform posDeInstanciamiento;
	public float esperaInicial = 1f;
	public float esperaEntreSpawn = 3f;
	public GameObject parent;
	public TextMesh dialDePuntos;
	public puntosScript puntosScript;
	private int timesInstanciated = 0;
	private int numInvaders = 10;

	private GameObject creation;

	void Awake(){
	}
	// Use this for initialization
	void Start () {
		StartCoroutine ("routine");
	}
	
	// Update is called once per frame
	void Update () {
	}
	IEnumerator routine(){
		yield return new WaitForSeconds (esperaEntreSpawn);
		if (timesInstanciated < numInvaders){
			creation = Instantiate (objAInstanciar, posDeInstanciamiento.position, posDeInstanciamiento.rotation);
			creation.transform.SetParent (parent.transform);
			timesInstanciated++;
		}else{
			if(GameObject.FindGameObjectsWithTag("Shotable").Length <=0){
				numInvaders += numInvaders / 2;
				timesInstanciated = 0;
				rotateArround.velocity += 0.01f;
			}
		}
		yield return StartCoroutine (routine ());

	}
	public TextMesh points(){
		return dialDePuntos;
	}

	public puntosScript getPuntosScript()
	{
		return puntosScript;
	}
	public void setColorInvader(Color color){
	}
}
