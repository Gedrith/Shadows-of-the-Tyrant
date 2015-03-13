using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 10;
	public float runningMult = 1.5f;
	public float turningSpeed = 60;

	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);

		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		animator.SetFloat("Speed",Mathf.Abs(horizontal)+vertical);

		//Walk
		if(!Input.GetKey(KeyCode.LeftShift))
		{
			if(Mathf.Abs(horizontal) > 0 && vertical == 0)
				vertical = .01f;
			if(vertical > 0)
				transform.Translate(0, 0, vertical);
				
			if(vertical > 0.02)
				animator.CrossFade("walk", 0f);
			else if(Mathf.Abs(horizontal) > 0)
				animator.CrossFade("walk", 0f);
		}
		//Run
		else if(Input.GetKey(KeyCode.LeftShift))
		{
			//Increase speed for running
			horizontal *= runningMult;
			vertical *= runningMult;

			if(Mathf.Abs(horizontal) > 0 && vertical == 0)
				vertical = .1f;
			if(vertical > 0)
				transform.Translate(0, 0, vertical);

			if(vertical > 0.1f)
				animator.CrossFade("run", 0f);
			else if(Mathf.Abs(horizontal) > 0)
				animator.CrossFade("run", 0f);
		}
	}
}

/*   if (Input.GetKeyDown(KeyCode.Q)) animator.CrossFade("attack01", 0.2f);
        if (Input.GetKeyDown(KeyCode.W)) animator.CrossFade("attack02", 0.2f);
        if (Input.GetKeyDown(KeyCode.E)) animator.CrossFade("attack03", 0.2f);
        if (Input.GetKeyDown(KeyCode.R)) animator.CrossFade("hit", 0.2f);

        if (Input.GetKeyDown(KeyCode.A)) animator.CrossFade("death", 0.2f);
        if (Input.GetKeyDown(KeyCode.S)) animator.CrossFade("idle", 0.2f);
        if (Input.GetKeyDown(KeyCode.D)) animator.CrossFade("jump", 0.2f);
        if (Input.GetKeyDown(KeyCode.F)) animator.CrossFade("jumping", 0.2f);

        if (Input.GetKeyDown(KeyCode.Z)) animator.CrossFade("kick", 0.2f);
        if (Input.GetKeyDown(KeyCode.X)) animator.CrossFade("roll", 0.2f);
        if (Input.GetKeyDown(KeyCode.C)) animator.CrossFade("run", 0.2f);
        if (Input.GetKeyDown(KeyCode.V)) animator.CrossFade("walk", 0.2f);*/