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
	private LayerMask fireLayer;
	private LayerMask waterLayer;

	// Use this for initialization
	void Start () {
		playerRenderer = GetComponent<Renderer> ();
		fireLayer = LayerMask.NameToLayer ("Fire");
		waterLayer = LayerMask.NameToLayer ("Water");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire Element")) {
			currentElement = Element.Fire;
			Physics.IgnoreLayerCollision (gameObject.layer, fireLayer, true);
		} else if (Input.GetButton ("Water Element")) {
			currentElement = Element.Water;
			Physics.IgnoreLayerCollision (gameObject.layer, waterLayer, true);
		}
		else {
			currentElement = Element.None;
			Physics.IgnoreLayerCollision (gameObject.layer, waterLayer, false);
			Physics.IgnoreLayerCollision (gameObject.layer, waterLayer, false);
		}

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
