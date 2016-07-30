using UnityEngine;
using System.Collections;

public class IceMeltScript : MonoBehaviour {

	private float startingResistance = 1.0f;
	public float currentResistance = 1.0f;
	private float meltAmout = 0.1f;
	private float meltTick = 0.25f;
	private float elapsedTime = 0f;
	private Transform originalTransform;

	// Use this for initialization
	void Start () {
		currentResistance = startingResistance;
		originalTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Melt(float deltaTime) {
		elapsedTime += deltaTime;

		if (elapsedTime >= meltTick) {
			currentResistance -= meltAmout;
			elapsedTime = 0f;

			Transform newTransform = originalTransform;
			newTransform.localScale = newTransform.localScale * currentResistance;
		}
	}
}
