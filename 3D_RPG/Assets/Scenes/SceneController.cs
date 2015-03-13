using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public static GameObject mapScene;
	public static GameObject battleScene;
	public static TBCStateMachine stateMachine;

	// Use this for initialization
	void Start()
	{
		stateMachine = GameObject.Find("BattleCam").GetComponent<TBCStateMachine>();
		GameObject.Find("BattleCam").GetComponent<AudioSource>().Stop();
		mapScene = GameObject.Find("MapScene");
		battleScene = GameObject.Find("BattleScene");
		battleScene.SetActive(false);
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}