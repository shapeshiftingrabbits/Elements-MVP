using UnityEngine;
using System.Collections;

public class ElementStateController : MonoBehaviour {

	public enum State {
		Water,
		Normal
	}

	public State currentState;

	// Use this for initialization
	void Start () {
		SetState(State.Normal);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SetState(State newState){
		currentState = newState;
		UpdateState ();
	}

	void UpdateState(){
		Renderer renderer = GetComponent<Renderer> ();
		if (currentState.Equals (State.Normal)) {
			renderer.material.color = Color.green;
		} else {
			renderer.material.color = Color.blue;
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag (PICKUP_TAG)) {
			other.gameObject.SetActive(false);
			count++;

			setCountText ();
		}
	}

}
