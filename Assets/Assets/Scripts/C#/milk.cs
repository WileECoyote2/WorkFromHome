using UnityEngine;
using System.Collections;

public class milk : MonoBehaviour {

	public Vector2 initialVelocity = Vector2.zero;

	private int bounces = 1;
	private Rigidbody2D body2d;

	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}

	void Start () {

		Destroy (gameObject, .7f);

		var velocity = initialVelocity;

		var startVelX = velocity.x * transform.localScale.x;

		body2d.velocity = new Vector2 (startVelX, initialVelocity.y);

	}

	void OnCollisionEnter2D (Collision2D target) {
		if (bounces <= 0)
			Destroy (gameObject);
		bounces--;

		if (target.gameObject.tag == "Deadly") {
			Destroy (gameObject, .1f);
		}
	}
}
