using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Transform))]
public class IceMeltScript : MonoBehaviour {

	private float startingResistance = 1.0f;
	public float currentResistance = 1.0f;
	private float meltAmout = 0.1f;
	private float meltTick = 0.25f;
	private float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
		currentResistance = startingResistance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Melt(float deltaTime) {
		elapsedTime += deltaTime;

		if (elapsedTime >= meltTick) {
			currentResistance -= meltAmout;
			elapsedTime = 0f;

			gameObject.transform.localScale = gameObject.transform.localScale * currentResistance;
		}
	}
}
