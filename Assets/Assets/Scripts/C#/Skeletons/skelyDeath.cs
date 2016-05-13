using UnityEngine;
using System.Collections;

public class skelyDeath : MonoBehaviour {

	public float health;

	void  OnCollisionEnter2D ( Collision2D coll  ){

		if (coll.gameObject.tag == "milk") {
			health--;
			if (health <= 0)
				Destroy (gameObject);
		}
	}
}