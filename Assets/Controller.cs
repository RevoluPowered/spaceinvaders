using UnityEngine;

public class Controller : MonoBehaviour {

	private float acceleration = 5.0f;
	private float speed = 100.0f;
	private bool left;
	private bool right;
	private bool forward;
	void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
	}

	private void PollControls()
	{
		right = Input.GetKey(KeyCode.A);
		left = Input.GetKey(KeyCode.D);
		forward = Input.GetKey(KeyCode.W);
	}

	private Rigidbody2D rigid;

	void Update() { PollControls(); }
	
	// Update is called once per frame
	void FixedUpdate () {
		rigid.AddForce( Vector3.down * (rigid.mass * 0.5f));

		transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(0,0,left ? -1.0f*speed : right ? 1.0f*speed : 0.0f),Time.deltaTime);
		//Camera.current.ScreenToWorldPoint(Screen.width,0);
		Vector2 force = new Vector2(0,forward ? 1.0f : 0.01f);
		force = force * 10.0f;
		rigid.AddForce(transform.rotation * force);
		
	}
}
