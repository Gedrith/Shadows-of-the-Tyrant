using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	private Inventory inventory = new Inventory();
	public string door = "Door";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		int[] temp = new int[10];
		temp = inventory.get_invenCount ();
		if(temp[2] == 1)
		{
			Destroy(GameObject.Find(door));
			inventory.useItem("Key");
		}
	}
}
