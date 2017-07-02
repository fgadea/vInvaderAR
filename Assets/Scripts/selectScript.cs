using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class selectScript : MonoBehaviour {
	public Image gazeReticle;
	public static bool croutine = false;
	private Ray ray;
	private RaycastHit hit;
	private GameObject lastGO;
	private Vector3 scale = Vector3.one;
	private float timer;
	private Scene scene;
	private bool noGyro;
	// Use this for initialization
	void Start () {
		if (croutine)
			StartCoroutine ("gaze");
		scene = SceneManager.GetActiveScene();
		//noGyro = GetComponent<GyroController> ().noGyro;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		ray = GetComponent<Camera> ().ScreenPointToRay (new Vector3 (GetComponent<Camera> ().pixelWidth / 2, GetComponent<Camera> ().pixelHeight / 2, 10000000f));

		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.transform.localScale == scale){
				hit.collider.gameObject.transform.DOScale (scale + new Vector3(1f,1f,0f), .1f);
				lastGO = hit.collider.gameObject;

			}
				#if UNITY_EDITOR
			if((CrossPlatformInputManager.GetButton("shoot") || (Input.GetKey(KeyCode.W) && SystemInfo.supportsGyroscope)) && timer >= 0.033f)
				#elif UNITY_ANDROID && !UNITY_EDITOR
			if((CrossPlatformInputManager.GetButton("shoot") || (Input.anyKey && SystemInfo.supportsGyroscope)) && timer >= 0.033f)
				#endif
				{
					timer = 0;
				SceneManager.LoadScene ("intro");
				SceneManager.UnloadSceneAsync (scene.name);
				}
		}else {
			if(lastGO != null) {
				if (lastGO.transform.localScale != scale ) {
					lastGO.transform.DOScale (scale, .1f);
					lastGO = null;
				}
			}
		}
		if(Input.GetKey(KeyCode.Return) && timer >= 0.033f){
			timer = 0f;
			SceneManager.LoadScene ("intro");
			SceneManager.UnloadSceneAsync (scene.name);
		}
	}

	IEnumerator gaze(){
		yield return new WaitForSeconds (0.033f);
		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.CompareTag("back"))
				gazeReticle.fillAmount += 0.01f;
		}if(!Physics.Raycast(ray)){
			gazeReticle.fillAmount = 0;
		}
		if (gazeReticle.fillAmount == 1) {
			selectionObject.noGameController = true;
			SceneManager.LoadScene ("intro");
			SceneManager.UnloadSceneAsync (scene.name);
		}
		yield return StartCoroutine (gaze ());
	}
}
