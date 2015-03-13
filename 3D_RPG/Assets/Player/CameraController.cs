using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    [SerializeField]
	private float distance;
    [SerializeField]
	private float distUp;
    [SerializeField]
	private float smooth;

	private Transform follow;
	private Vector3 targetPosition;

    void Start()
    {
    	//follow = GameObject.FindWithTag("Player").transform;
        follow = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
		//Set new position
		targetPosition = follow.position + follow.up * distUp - follow.forward * distance;
        //Check for Wall Collisions
        Vector3 fromObj = follow.position + new Vector3(0f, distUp, 0f);
        WallCollision(fromObj, ref targetPosition);
        //Smooth transition to new position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
		//Look at target
		transform.LookAt(follow);
    }

    private void WallCollision(Vector3 fromObject, ref Vector3 toTarget)
    {
        RaycastHit wallHit = new RaycastHit();
        if(Physics.Linecast(fromObject, toTarget, out wallHit))
        {
            toTarget = new Vector3(wallHit.point.x -1f, toTarget.y + 1f, wallHit.point.z);
        }
    }
}