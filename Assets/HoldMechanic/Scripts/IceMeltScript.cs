using UnityEngine;
using System.Collections;

public class IceMeltScript : MonoBehaviour {

	private float startingResistance = 1.0f;
	public float currentResistance;

	// Use this for initialization
	void Start () {
		currentResistance = startingResistance;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = transform.localScale * currentResistance;
	}

	void Melt() {
		currentResistance -= 0.1f;
	}
}
