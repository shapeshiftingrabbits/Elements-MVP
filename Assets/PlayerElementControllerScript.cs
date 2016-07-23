using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Renderer))]
public class PlayerElementControllerScript : MonoBehaviour {

	public enum Element
	{
		None,
		Water,
		Fire
	}

	public Element currentElement = Element.None;
	private Renderer playerRenderer;

	// Use this for initialization
	void Start () {
		playerRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire Element"))
			currentElement = Element.Fire;
		else if (Input.GetButton ("Water Element"))
			currentElement = Element.Water;
		else
			currentElement = Element.None;

		playerRenderer.material.color = elementColor();
	}

	Color elementColor () {
		if (currentElement == Element.Water)
			return Color.blue;
		else if (currentElement == Element.Fire)
			return Color.red;
		else
			return Color.grey;
	}
}
