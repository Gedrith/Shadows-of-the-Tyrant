using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Texture background;
	public GUISkin Main_Menu;
	public GenerateCharacters gen;

	void Start()
	{
		gen = new GenerateCharacters ();
	}

	void OnGUI()
	{
		GUI.skin = Main_Menu;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);
		GUI.Label (new Rect (Screen.width * 0.25f, Screen.height * 0.25f, Screen.width * 0.5f, Screen.height * 0.25f), "Shadows of the Tyrant");
		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f), "New Game")) 
		{
			Application.LoadLevel ("Floor 1");
		}
	}

}
