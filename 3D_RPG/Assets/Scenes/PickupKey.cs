using UnityEngine;
using System.Collections;

public class PickupKey : MonoBehaviour {

	public string item;
	private Inventory inventory = new Inventory();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		Destroy(GameObject.Find(item));
		inventory.addItem (item, 1);
	}
}
