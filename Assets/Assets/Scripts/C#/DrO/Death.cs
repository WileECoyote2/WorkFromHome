using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

	void  OnCollisionEnter2D ( Collision2D coll  ){

		if( coll.gameObject.tag == "Deadly")
		{
			Destroy(gameObject);
		}
	}
}