using UnityEngine;
using System.Collections;

public class BattleGUI : MonoBehaviour{

	public Texture background;
	public GUISkin BattleSkin;
	private Olaf_stats Olaf;
	private Luna_stats Luna;
	private Rylai_stats Rylai;
	private bool targets = false;
	private bool magicList = false;
	private bool ItemList = false;
	private bool AllyTarget = false;
	private bool useItem = false;
	private bool useMagic = false;
	private bool attacking = false;
	private string heal;
	private string magicAtt;

	Communicator comm = new Communicator ();
	// Use this for initialization
	void Start()
	{
		Olaf = new Olaf_stats ();
		Luna = new Luna_stats ();
		Rylai = new Rylai_stats ();
	}


	void OnGUI()
	{
		GUI.skin = BattleSkin;
		GUI.DrawTexture (new Rect (0, Screen.height* 0.65f, Screen.width, Screen.height), background);
		//Set up buttons for Attack, Magic, Item, and Defend
		if (comm.getFlag()) 
		{
			GUI.Label (new Rect(0 + Screen.width * 0.35f, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_CurrentPlayer()+"'s Turn");
			if (GUI.Button (new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Attack")) 
			{
				comm.attackFlag();
				targets = true;
				comm.toggleFlag();
				attacking = true;

			}
			if (GUI.Button (new Rect (0, Screen.height * 0.69f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), "Magic")) 
			{
				Debug.Log("Magic");
				comm.magicFlag();
				comm.toggleFlag();
				magicList = true;
			}
			if (GUI.Button (new Rect (0, Screen.height * 0.71f + Screen.height * 0.14f, Screen.width * 0.25f, Screen.height * 0.07f), "Item")) 
			{
				Debug.Log("Item");
				comm.itemFlag();
				comm.toggleFlag();
				ItemList = true;
			}
			if (GUI.Button (new Rect (0, Screen.height * 0.73f + Screen.height * 0.21f, Screen.width * 0.25f, Screen.height * 0.07f), "Defend")) 
			{
				comm.defendFlag();
				comm.toggleFlag();
			}
		}
		else if(targets)
		{
			if (comm.get_enemy1().CompareTo("") != 0)
			{
				if(comm.get_enemy1().CompareTo("Goblin") == 0)
				{
					if(!comm.getGob1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy1())) 
						{
							comm.set_attacked(comm.get_enemy1());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
				else if(comm.get_enemy1().CompareTo("Troll") == 0)
				{
					if(!comm.getTroll1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy1())) 
						{
							comm.set_attacked(comm.get_enemy1());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
				else if(comm.get_enemy1().CompareTo("Spider") == 0)
				{
					if(!comm.getSpider1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy1())) 
						{
							comm.set_attacked(comm.get_enemy1());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
				else
				{
					if(!comm.get_Tyrant().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy1())) 
						{
							comm.set_attacked(comm.get_enemy1());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
			}
			if (comm.get_enemy2().CompareTo("") != 0)
			{
				if(comm.get_enemy2().CompareTo("Goblin") == 0)
				{
					if(!comm.getGob1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.69f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy2())) 
						{
							comm.set_attacked(comm.get_enemy2());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
				else if(comm.get_enemy2().CompareTo("Troll") == 0)
				{
					if(!comm.getTroll1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.69f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy2())) 
						{
							comm.set_attacked(comm.get_enemy2());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
				else
				{
					if(!comm.getSpider1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.69f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy2())) 
						{
							comm.set_attacked(comm.get_enemy2());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
			}
			if (comm.get_enemy3().CompareTo("") != 0)
			{
				if(comm.get_enemy3().CompareTo("Goblin") == 0)
				{
					if(!comm.getGob1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.71f + Screen.height * 0.14f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy3())) 
						{
							comm.set_attacked(comm.get_enemy3());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
				else if(comm.get_enemy3().CompareTo("Troll") == 0)
				{
					if(!comm.getTroll1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.71f + Screen.height * 0.14f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy3())) 
						{
							comm.set_attacked(comm.get_enemy3());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
				else
				{
					if(!comm.getSpider1().isDead())
					{
						if (GUI.Button (new Rect (0, Screen.height * 0.71f + Screen.height * 0.14f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy3())) 
						{
							comm.set_attacked(comm.get_enemy3());
							targets = false;
							if(useMagic)
								comm.set_MagicAttack(magicAtt);
						}
					}
				}
			}
			if(GUI.Button(new Rect (0 + Screen.width * 0.25f, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Back"))
			{
				targets = false;
				if(attacking)
				{
					comm.toggleFlag();
					comm.attackFlag();
				}
				if(useMagic)
					magicList = true;
			}
		}
		else if(magicList)
		{
			if(comm.get_CurrentPlayer().CompareTo("Luna") == 0)
			{
				GUI.Label (new Rect (0, Screen.height * 0.67f, Screen.height * 0.25f, Screen.height * 0.07f), "I can't even");
			}
			else if(comm.get_CurrentPlayer().CompareTo("Olaf") == 0)
			{
				if(Olaf.get_CurrentMP() != 0)
				{
					if (GUI.Button( new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Cure"))
					{
						Debug.Log ("Cure");
						heal = "Cure";
						magicList = false;
						AllyTarget = true;
						useMagic = true;
					}
				}
			}
			else
			{
				if(Rylai.get_CurrentMP() != 0)
				{
					if (GUI.Button( new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Cure"))
					{
						Debug.Log ("Cure");
						heal = "Cure";
						magicList = false;
						AllyTarget = true;
						useMagic = true;
					}
					if (GUI.Button( new Rect (0, Screen.height * 0.67f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), "Fire"))
					{
						Debug.Log ("Fire");
						magicAtt = "Fire";
						magicList = false;
						targets = true;
						useMagic = true;
					}
					if (GUI.Button( new Rect (0, Screen.height * 0.67f + Screen.height * 0.14f, Screen.width * 0.25f, Screen.height * 0.07f), "Thunder"))
					{
						Debug.Log ("Thunder");
						magicAtt = "Thunder";
						magicList = false;
						targets = true;
						useMagic = true;
					}
					if (GUI.Button( new Rect (0, Screen.height * 0.67f + Screen.height * 0.21f, Screen.width * 0.25f, Screen.height * 0.07f), "Ice Spear"))
					{
						Debug.Log ("Ice Spear");
						magicAtt = "Ice Spear";
						magicList = false;
						targets = true;
						useMagic = true;
					}
				}
			}
			if(GUI.Button(new Rect (0 + Screen.width * 0.25f, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Back"))
			{
				comm.magicFlag();
				magicList = false;
				comm.toggleFlag();
			}
		}
		else if(ItemList)
		{
			if(comm.get_CurrentPlayer().CompareTo("Olaf") == 0)
			{
				if(!Olaf.EmptyPotions())
				{
					if(GUI.Button( new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Potion X"+Olaf.get_potions()))
					{
						Debug.Log ("Use Potion");
						heal = "Potion";
						ItemList = false;
						AllyTarget = true;
						useItem = true;
					}
				}
				if(!Olaf.EmptyElixirs())
				{
					if(GUI.Button( new Rect (0, Screen.height * 0.67f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), "Elixir X"+Olaf.get_elixirs()))
					{
						Debug.Log ("Use Elixir");
						heal = "Elixir";
						ItemList = false;
						AllyTarget = true;
						useItem = true;
					}
				}
			}
			else if(comm.get_CurrentPlayer().CompareTo("Luna") == 0)
			{
				if(!Luna.EmptyPotions())
				{
					if(GUI.Button( new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Potion X"+Luna.get_potions()))
					{
						Debug.Log ("Use Potion");
						heal = "Potion";
						ItemList = false;
						AllyTarget = true;
						useItem = true;
					}
				}
				if(!Luna.EmptyElixirs())
				{
					if(GUI.Button( new Rect (0, Screen.height * 0.67f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), "Elixir X"+Luna.get_elixirs()))
					{
						Debug.Log ("Use Elixir");
						heal = "Elixir";
						ItemList = false;
						AllyTarget = true;
						useItem = true;
					}
				}
			}
			else
			{
				if(!Rylai.EmptyPotions())
				{
					if(GUI.Button( new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Potion X"+Rylai.get_potions()))
					{
						Debug.Log ("Use Potion");
						heal = "Potion";
						ItemList = false;
						AllyTarget = true;
						useItem = true;
					}
				}
				if(!Rylai.EmptyElixirs())
				{
					if(GUI.Button( new Rect (0, Screen.height * 0.67f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), "Elixir X"+Rylai.get_elixirs()))
					{
						Debug.Log ("Use Elixir");
						heal = "Elixir";
						ItemList = false;
						AllyTarget = true;
						useItem = true;
					}
				}
			}

			if(GUI.Button(new Rect (0 + Screen.width * 0.25f, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Back"))
			{
				comm.itemFlag();
				ItemList = false;
				comm.toggleFlag();
			}
		}
		else if(AllyTarget)
		{
			if(GUI.Button( new Rect (0, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Olaf"))
			{
				Debug.Log ("Olaf");
				comm.set_HealTarget("Olaf");
				comm.set_Heal(heal);
			}
			if(GUI.Button( new Rect (0, Screen.height * 0.67f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), "Luna"))
			{
				Debug.Log ("Luna");
				comm.set_HealTarget("Luna");
				comm.set_Heal(heal);
			}
			if(GUI.Button( new Rect (0, Screen.height * 0.67f + Screen.height * 0.14f, Screen.width * 0.25f, Screen.height * 0.07f), "Rylai"))
			{
				Debug.Log ("Rylai");
				comm.set_HealTarget("Rylai");
				comm.set_Heal(heal);
			}
			if(GUI.Button(new Rect (0 + Screen.width * 0.25f, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Back"))
			{
				AllyTarget = false;
				if(useItem)
					ItemList = true;
				if(useMagic)
					magicList = true;
			}
		}
		else
		{
			if (comm.get_enemy1().CompareTo("") != 0) 
			{
				GUI.Label (new Rect (Screen.width * 0.15f, Screen.height * 0.67f, Screen.height * 0.25f, Screen.height * 0.07f), comm.get_enemy1());
			}
			if (comm.get_enemy2().CompareTo("") != 0) 
			{
				GUI.Label (new Rect (Screen.width * 0.15f, Screen.height * 0.67f + Screen.height * 0.07f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy2());
			}
			if (comm.get_enemy3().CompareTo("") != 0) 
			{
				GUI.Label (new Rect (Screen.width * 0.15f, Screen.height * 0.67f + Screen.height * 0.14f, Screen.width * 0.25f, Screen.height * 0.07f), comm.get_enemy3());
			}
		}
		
		// Display Character HP
		
		// Olaf
		GUI.Label (new Rect (Screen.width * 0.60f, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), "Olaf "); 
		GUI.Label (new Rect (Screen.width * 0.65f, Screen.height * 0.67f, Screen.width * 0.25f, Screen.height * 0.07f), " HP: " +Olaf.get_currentHP()+ " / " +Olaf.get_totalHP() );
		GUI.Label (new Rect (Screen.width * 0.65f, Screen.height * 0.70f, Screen.width * 0.25f, Screen.height * 0.07f), " MP: " +Olaf.get_CurrentMP()+ " / " +Olaf.get_MP() );
		
		// Luna
		GUI.Label (new Rect (Screen.width * 0.60f, Screen.height * 0.69f + Screen.height *0.07f, Screen.width * 0.25f, Screen.height * 0.07f), "Luna ");
		GUI.Label (new Rect (Screen.width * 0.65f, Screen.height * 0.69f + Screen.height *0.07f, Screen.width * 0.25f, Screen.height * 0.07f), " HP: " +Luna.get_currentHP()+ " / " +Luna.get_totalHP() );
		GUI.Label (new Rect (Screen.width * 0.65f, Screen.height * 0.72f + Screen.height *0.07f, Screen.width * 0.25f, Screen.height * 0.07f), " MP: " +Luna.get_CurrentMP()+ " / " +Luna.get_MP() );
		
		// Rylai
		GUI.Label (new Rect (Screen.width * 0.60f, Screen.height * 0.71f + Screen.height *0.14f, Screen.width * 0.25f, Screen.height * 0.07f), "Rylai ");
		GUI.Label (new Rect (Screen.width * 0.65f, Screen.height * 0.71f + Screen.height *0.14f, Screen.width * 0.25f, Screen.height * 0.07f), " HP: " +Rylai.get_currentHP()+ " / " +Rylai.get_totalHP() );
		GUI.Label (new Rect (Screen.width * 0.65f, Screen.height * 0.74f + Screen.height *0.14f, Screen.width * 0.25f, Screen.height * 0.07f), " MP: " +Rylai.get_CurrentMP()+ " / " +Rylai.get_MP() );


		if(comm.get_battleWon())		
		{
			if(GUI.Button(new Rect(Screen.width*0.50f,Screen.height*0.50f,Screen.width*0.25f,Screen.height*0.07f), "Continue!"))
			{
				comm.set_done(true);
			}
		}
		if(comm.get_battleLost())
		{
			if(GUI.Button(new Rect(Screen.width*0.50f,Screen.height*0.50f,Screen.width*0.25f,Screen.height*0.07f), "You have lost!"))
			{
				comm.set_done(true);
			}
		}
	}
}
