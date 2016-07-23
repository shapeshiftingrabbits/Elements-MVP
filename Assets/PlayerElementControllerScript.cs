using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Renderer))]
public class PlayerElementControllerScript : MonoBehaviour {

	enum Elements
	{
		None = 0,
		Water = 1,
		Fire = 2
	}

	public int currentElement = 0;
	private Renderer playerRenderer;

	// Use this for initialization
	void Start () {
		playerRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire Element"))
			currentElement = 1;
		else if (Input.GetButton ("Water Element"))
			currentElement = 2;
		else
			currentElement = 0;

		playerRenderer.material.color = elementColor();
	}

	Color elementColor () {
		if (currentElement == 1)
			return Color.blue;
		else if (currentElement == 2)
			return Color.red;
		else
			return Color.grey;
	}
}
