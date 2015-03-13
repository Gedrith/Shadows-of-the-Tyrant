using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	// Use this for initialization
	public string door;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Rock")
		{
			Destroy(GameObject.Find(door));
		}
	}
}
