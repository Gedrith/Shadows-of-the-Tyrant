using UnityEngine;
using System.Collections;

public class BattleStateStart {

	public string[] turnList = new string[6];
	public int[] combatList = new int[6];
	public string[] comList = new string[6];
	private int num_enemies;
	private Goblin_Stats goblin1;
	private Goblin_Stats goblin2;
	private Goblin_Stats goblin3;
	private int goblin_count = 0;
	private Spider_Stats spider1;
	private Spider_Stats spider2;
	private Spider_Stats spider3;
	private int spider_count = 0;
	private Troll_Stats troll1;
	private Troll_Stats troll2;
	private Troll_Stats troll3;
	private int troll_count = 0;
	private Tyrant_Stats tyrant;

	private Avatar avatarGoblin;
	private Avatar avatarSpider;
	private Avatar avatarTroll;
	private Avatar avatarTyrant;

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void PrepareBattle(string[] enemy)
	{
		int y = 0;
		goblin_count = 0;
		spider_count = 0;
		troll_count = 0;
		for (int i=0; i<3; i++) 
		{
			if(enemy[i] == null)
			{
				//does nothing
			}
			else if(enemy[i].CompareTo("Goblin") == 0)
			{
				//check if goblin
				if(goblin_count == 0)
				{
					goblin1 = new Goblin_Stats();
					combatList[i] = goblin1.get_speed();
					comList[i] = "Goblin";
					goblin_count++;
					y++;
				}
				else if(goblin_count == 1)
				{
					goblin2 = new Goblin_Stats();
					combatList[i] = goblin2.get_speed();
					comList[i] = "Goblin 2";
					goblin_count++;
					y++;
				}
				else
				{
					goblin3 = new Goblin_Stats();
					combatList[i] = goblin3.get_speed();
					comList[i] = "Goblin 3";
					y++;
				}
			}
			else if(enemy[i].CompareTo("Spider") == 0)
			{
				//check if spider
				if(spider_count == 0)
				{
					spider1 = new Spider_Stats();
					combatList[i] = spider1.get_speed();
					comList[i] = "Spider";
					spider_count++;
					y++;
				}
				else if(spider_count == 1)
				{
					spider2 = new Spider_Stats();
					combatList[i] = spider2.get_speed();
					comList[i] = "Spider 2";
					spider_count++;
					y++;
				}
				else
				{
					spider3 = new Spider_Stats();
					combatList[i] = spider3.get_speed();
					comList[i] = "Spider 3";
					y++;
				}
			}
			else if(enemy[i].CompareTo("Troll") == 0)
			{
				//check if troll
				if(troll_count == 0)
				{
					troll1 = new Troll_Stats();
					int x = troll1.get_speed();
					combatList[i] = troll1.get_speed();
					comList[i] = "Troll";
					troll_count++;
					y++;
				}
				else if(troll_count == 1)
				{
					troll2 = new Troll_Stats();
					combatList[i] = troll2.get_speed();
					comList[i] = "Troll 2";
					troll_count++;
					y++;
				}
				else
				{
					troll3 = new Troll_Stats();
					combatList[i] = troll3.get_speed();
					comList[i] = "Troll 3";
					y++;
				}
			}
			else if( enemy[i].CompareTo ("Tyrant")== 0)
			{
				tyrant = new Tyrant_Stats();
				combatList[i] = tyrant.get_speed();
				comList[i] = "Tyrant";
				y++;
				break;
			}
		}
		num_enemies = y - 1;
		//Create Enemies
		CreateNewEnemy();
		//Generate Turn List
		GenerateTurnList();
	}

private void CreateNewEnemy()
	{
		//Create Enemy
		avatarGoblin = Resources.Load<Avatar>("Goblin");
		avatarSpider = Resources.Load<Avatar>("Spider");
		avatarTroll = Resources.Load<Avatar>("Troll");
		avatarTyrant = Resources.Load<Avatar>("Tyrant");

		GameObject[] enemies = new GameObject[3];
		GameObject[] instance = new GameObject[3];

		//Load in the boss to his special spot
		if(comList[0].CompareTo("Tyrant") == 0)
		{
			enemies[2] = GameObject.Find("Enemy2");
			instance[0] = (GameObject)GameObject.Instantiate(Resources.Load("Tyrant", typeof(GameObject)));
			instance[0].transform.position = enemies[2].transform.position;
			instance[0].transform.parent = enemies[2].transform;
			return;
		}
	
		//Loop through all enemies loading them in from enemy spot 1 to 3
		for(int i = 0; i <= num_enemies; i++)
		{
			int j = i + 1;
			enemies[i] = GameObject.Find("Enemy"+j);
			string[] newName = comList[i].Split(' ');
			
			instance[i] = (GameObject)GameObject.Instantiate(Resources.Load(newName[0], typeof(GameObject)));
			instance[i].transform.position = enemies[i].transform.position;
			instance[i].transform.parent = enemies[i].transform;
		}
	}

	private void GenerateTurnList()
	{
		//Put all characters in list
		//Sort descending
		Olaf_stats Olaf = new Olaf_stats ();
		Luna_stats Luna = new Luna_stats ();
		Rylai_stats Rylai = new Rylai_stats ();
		combatList [num_enemies+1] = Olaf.get_speed();
		comList[num_enemies+1] = "Olaf";
		combatList [num_enemies + 2] = Luna.get_speed ();
		comList[num_enemies + 2] = "Luna";
		combatList [num_enemies + 3] = Rylai.get_speed ();
		comList[num_enemies + 3] = "Rylai";
		num_enemies = num_enemies + 3;
		for (int i = 0; i<=num_enemies; i++) 
		{
			for(int j = 1; j<num_enemies;j++)
			{
				int temp;
				string tem;
				if(combatList[i] <= combatList[j])
				{
					temp = combatList[j];
					combatList[j] = combatList[i];
					combatList[i] = temp;

					tem = comList[j];
					comList[j] = comList[i];
					comList[i] = tem;
				}
			}
		}
		for(int h = 1; h <=num_enemies/2; h++)
		{
			int temp;
			int y = num_enemies - h +1;
			temp = combatList[y];
			combatList[y] = combatList[h];
			combatList[h] = temp;
			
			string tem;
			tem = comList[y];
			comList[y] = comList[h];
			comList[h] = tem;
		}
		set_communicator ();
	}
	private void set_communicator()
	{
		Communicator comm = new Communicator ();
		comm.set_Gob (goblin1, goblin2, goblin3, goblin_count);
		comm.set_Spid (spider1, spider2, spider3, spider_count);
		comm.set_Troll (troll1, troll2, troll3, troll_count);
		comm.set_Tyrant (tyrant);
	}
}