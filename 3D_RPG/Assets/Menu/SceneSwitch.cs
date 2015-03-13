using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

	public string myLevel;
	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log (other);
		Application.LoadLevel (myLevel);
	}
}
