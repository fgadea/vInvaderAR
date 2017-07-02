using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class moverCamara : MonoBehaviour {
	public float frequency;
	public GameObject cam;
	public SpriteRenderer instruccions;
	public GameObject goSprite;
	public Image background;
	public GameObject goBackgroud;
	public GameObject instanciator;
	private Ray ray;
	private RaycastHit hit;
	private bool ar = false;
	private float timer = 0;
	private bool oneTime = true;
	void Start () {
		background.DOFade (0.5f, 0);
	
	// Update is called once per frame
	}
	void Update () {
		timer += Time.deltaTime;
		if(Input.touchCount > 0 && timer > frequency){
			if(oneTime){
				goSprite.SetActive (false);
				goBackgroud.SetActive (false);
				instanciator.SetActive (true);
				oneTime = false;
			}
			timer = 0;
			ray = GetComponent<Camera> ().ScreenPointToRay (new Vector3(Input.GetTouch (0).position.x,Input.GetTouch (0).position.y,10f));
			if (Physics.Raycast (ray, out hit)) {
				//if(timer > frequency){
					if (hit.collider.CompareTag ("arBtn")) {
						ar = !ar;
						cam.SetActive (ar);
						GetComponent<camScript> ().enabled = !GetComponent<camScript> ().enabled;
					}

				//}
			}
		}

	}
}
