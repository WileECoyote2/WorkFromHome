using UnityEngine;
using System.Collections;

public class movementDrO : MonoBehaviour {

	public bool standing;
	public bool canClimb;
	public Transform groundedEnd;
	public Transform climbingEnd;
	public float h = 0.0f;
	public float v = 0.0f;
	public bool facingUp = true;
	public LayerMask collisionLayer;
	public Vector2 bottomPosition = new Vector2 (-2.75f, -10f);
	public float collisionRadius = 3.5f;
	public bool facingRight = true;
	public bool facingLeft;
	public int direction;

	private Rigidbody2D body2d;
	private float Speed = 70f;
	private float jumpSpeed = 75f;

	void Awake () {
		body2d = GetComponent<Rigidbody2D> ();
	}

	void  Start () {
		
	}

	void  FixedUpdate () {
		movement ();
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		var pos = bottomPosition;
		pos.x += transform.position.x;
		pos.y += transform.position.y;

		standing = Physics2D.OverlapCircle (pos, collisionRadius, collisionLayer);
	}

	void movement () {
		if (h != 0 && !canClimb) {
			transform.Translate (h * Speed * Time.deltaTime, 0, 0);
		}

		if (h < 0 && facingRight) {
			Flip();
			facingRight = false;
			facingLeft = true;
		} else if (h > 0 && facingLeft) {
			Flip();
			facingRight = true;
			facingLeft = false;
		}

		if (v > 0) {
			if (standing == true) {
				var vel = body2d.velocity;
				body2d.velocity = new Vector2 (vel.x, jumpSpeed);
			}
		}
	}

	void  Flip () {
		if (facingRight == true) {
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			bottomPosition = new Vector2 (bottomPosition.x * -1, bottomPosition.y);
		} else if (facingLeft == true) {
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			bottomPosition = new Vector2 (bottomPosition.x, bottomPosition.y);
		}
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;

		var pos = bottomPosition;
		pos.x = transform.position.x;
		pos.y = transform.position.y;

		Gizmos.DrawWireSphere (pos, collisionRadius);
	}
}