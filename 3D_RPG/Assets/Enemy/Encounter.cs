using UnityEngine;
using System.Collections;

public class Encounter : MonoBehaviour {

	public string mob;
	public string mob2;
	public string mob3;

	private TBCStateMachine stateMachine;
	private string[] pack;

	void OnTriggerEnter (Collider other)
	{
		//Change Map Scene
		Destroy (GameObject.Find(mob));
		SceneController.mapScene.SetActive(false);

		//Update/Switch to Battle Scene
		pack = new string[] {mob, mob2, mob3};
		Debug.Log(pack[0] + pack[1] + pack[2]);
		if(pack.Length == 1)
		{
			SceneController.stateMachine.enemy1 = pack[0];
		}
		else if(pack.Length == 2)
		{
			SceneController.stateMachine.enemy1 = pack[0];
			SceneController.stateMachine.enemy2 = pack[1];
		}
		else if(pack.Length == 3)
		{
			SceneController.stateMachine.enemy1 = pack[0];
			SceneController.stateMachine.enemy2 = pack[1];
			SceneController.stateMachine.enemy3 = pack[2];
		}
		SceneController.stateMachine.StartNewBattle();
		SceneController.battleScene.SetActive(true);
		GameObject.Find("BattleCam").GetComponent<AudioSource>().Play();
	}
}