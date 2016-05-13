using UnityEngine;
using System.Collections;

public class shootingDrO : movementDrO {

	public float shootDelay = .5f;
	public GameObject projectilePrefab;
	public Vector2 firePosition = Vector2.zero;
	public float debugRadius = 1f;

	private Color debugColor = Color.yellow;
	private float timeElapsed = 0;
	
	void Update () {

		if (projectilePrefab != null) {

			var canFire = Input.GetButton ("Fire1");

			if (canFire && timeElapsed > shootDelay) {
				CreateProjectile (CalculateFirePosition ());
				timeElapsed = 0;
			}

			timeElapsed += Time.deltaTime;
		}

	}

	Vector2 CalculateFirePosition () {
		var pos = firePosition;
		pos.x *= direction;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		return pos;
	}

	public void CreateProjectile (Vector2 pos) {
		var clone = Instantiate (projectilePrefab, pos, Quaternion.identity) as GameObject;
		clone.transform.localScale = new Vector2 (5, 5);
	}

	void OnDrawGizmos () {
		Gizmos.color = debugColor;

		var pos = firePosition;
		if (facingRight == true)
			pos.x = 8f;
		else if (facingLeft == true)
			pos.x = -8f;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		Gizmos.DrawWireSphere (pos, debugRadius);
	}
}
