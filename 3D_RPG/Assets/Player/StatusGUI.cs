using UnityEngine;
using System.Collections;

public class StatusGUI : MonoBehaviour {
	
	public GUISkin BattleSkin;
	private Olaf_stats Olaf;
	private Luna_stats Luna;
	private Rylai_stats Rylai;
	private Inventory inventory;
	private string[] inventoryList = new string[10];
	private int[] inventoryCount = new int[10];

	private bool statusflag = false;
	private bool menuflag = true;
	private bool invenFlag = false;
	private bool AboutFlag = false;
	private bool openflag = false;

	public GameObject player = new GameObject();

	void Start()
	{
		Olaf = new Olaf_stats ();
		Luna = new Luna_stats ();
		Rylai = new Rylai_stats ();
		inventory = new Inventory ();
		// take this out later
		inventory.set_inventory ();
	}

	void OnGUI()
	{
		GUI.skin = BattleSkin;
		if(menuflag)
		{
			if(GUI.Button(new Rect (Screen.width * 0.90f, Screen.height * 0.10f, Screen.width * 0.07f, Screen.height * 0.07f), "Menu"))
			{
				menuflag = false;
				openflag = true;
			}
		}
		if(openflag)
		{
			if(GUI.Button (new Rect (Screen.width * 0.90f, Screen.height * 0.10f, Screen.width * 0.07f, Screen.height * 0.07f), "Status"))
			{
				openflag = false;
				statusflag = true;
			}
			if(GUI.Button (new Rect (Screen.width * 0.90f, Screen.height * 0.20f, Screen.width * 0.07f, Screen.height * 0.07f), "Inventory"))
			{
				openflag = false;
				invenFlag = true;
			}
			if(GUI.Button (new Rect (Screen.width * 0.90f, Screen.height * 0.30f, Screen.width * 0.07f, Screen.height * 0.07f), "About"))
			{
				openflag = false;
				AboutFlag = true;
			}
			if(GUI.Button (new Rect (Screen.width * 0.90f, Screen.height * 0.40f, Screen.width * 0.07f, Screen.height * 0.07f), "Close"))
			{
				openflag = false;
				menuflag = true;
			}
		}
		if(statusflag)
		{
			GUI.Box (new Rect(new Rect (Screen.width *0.85f, Screen.height * 0.10f, Screen.width, Screen.height)), "");
			if(GUI.Button (new Rect (Screen.width * 0.90f, Screen.height * 0.10f, Screen.width * 0.07f, Screen.height * 0.07f), "Close"))
			{
				openflag = true;
				statusflag = false;
			}
			GUI.Label (new Rect(Screen.width * 0.90f, Screen.height * 0.20f, Screen.width * 0.10f, Screen.height * 0.07f), "Olaf's HP: "+Olaf.get_currentHP()+ " / " +Olaf.get_totalHP());
			GUI.Label (new Rect(Screen.width * 0.90f, Screen.height * 0.25f, Screen.width * 0.10f, Screen.height * 0.07f), "Luna's HP: "+Luna.get_currentHP()+ " / " +Luna.get_totalHP());
			GUI.Label (new Rect(Screen.width * 0.90f, Screen.height * 0.30f, Screen.width * 0.10f, Screen.height * 0.07f), "Rylai's HP: "+Rylai.get_currentHP()+ " / " +Rylai.get_totalHP());

			GUI.Label (new Rect(Screen.width * 0.85f, Screen.height * 0.35f, Screen.width * 0.15f, Screen.height * 0.07f), "Player Position "+player.transform.localPosition);
		}
		if(invenFlag)
		{
			GUI.Box (new Rect(new Rect (Screen.width *0.85f, Screen.height * 0.10f, Screen.width, Screen.height)), "");
			if(GUI.Button (new Rect (Screen.width * 0.90f, Screen.height * 0.10f, Screen.width * 0.07f, Screen.height * 0.07f), "Close"))
			{
				openflag = true;
				invenFlag = false;
			}
			GUI.Label (new Rect(Screen.width * 0.90f, Screen.height * 0.20f, Screen.width * 0.10f, Screen.height * 0.07f), "Inventory");
			inventoryList = inventory.get_inventory();
			inventoryCount = inventory.get_invenCount();

			for(int i = 0; i<inventory.get_totalInven();i++)
			{
				float j = 0.05f * (i+1);
				GUI.Label (new Rect(Screen.width * 0.85f, Screen.height * (0.20f + j), Screen.width * 0.10f, Screen.height * 0.07f), inventoryList[i]+ " x"+ inventoryCount[i]);
				if(inventoryCount[i] > 0)
				{
					if(GUI.Button(new Rect (Screen.width * 0.90f, Screen.height * (0.20f + j), Screen.width * 0.07f, Screen.height * 0.05f), "Drop "+ inventoryList[i]))
					{
						inventory.useItem(inventoryList[i]);
					}
				}
			}
		}
		if(AboutFlag)
		{
			GUI.Box (new Rect(new Rect (0, Screen.height* 0.65f, Screen.width, Screen.height)), "");
			if(GUI.Button (new Rect (Screen.width * 0.90f, Screen.height * 0.10f, Screen.width * 0.07f, Screen.height * 0.07f), "Close"))
			{
				openflag = true;
				AboutFlag = false;
			}
			GUI.Label (new Rect(Screen.width * 0.10f, Screen.height * 0.70f, Screen.width * 0.30f, Screen.height * 0.20f), "All assets obtained from Unity Asset Store");
		}


	}
}
