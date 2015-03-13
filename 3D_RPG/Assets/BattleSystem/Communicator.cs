using UnityEngine;
using System.Collections;

public class Communicator{

	//All this class does is pass information around
	public static string enemy1;
	public static string enemy2;
	public static string enemy3;
	public static string[] enemies;
	private static bool flag = false;
	public static bool attack = false;
	public static bool magic = false;
	public static bool item = false;
	public static bool defend = false;
	public static bool done = false;
	public static bool battleWon = false;
	public static bool battleLost = false;
	public static string attacked = "";
	private static int num_enemies;
	private static Goblin_Stats goblin1;
	private static Goblin_Stats goblin2;
	private static Goblin_Stats goblin3;
	private static int goblin_count = 0;
	private static Spider_Stats spider1;
	private static Spider_Stats spider2;
	private static Spider_Stats spider3;
	private static int spider_count = 0;
	private static Troll_Stats troll1;
	private static Troll_Stats troll2;
	private static Troll_Stats troll3;
	private static int troll_count = 0;
	private static Tyrant_Stats tyrant;
	private static string[] turnList;
	private static bool endPlayer = false;
	private Olaf_stats Olaf = new Olaf_stats();
	private Luna_stats Luna = new Luna_stats ();
	private Rylai_stats Rylai = new Rylai_stats ();
	private static string currentPlayer;
	private static string healTarget = "";
	private static string heal;
	private static string magicATT;

	public void set_Gob(Goblin_Stats g1, Goblin_Stats g2, Goblin_Stats g3, int goblin)
	{
		goblin1 = g1;
		goblin2 = g2;
		goblin3 = g3;
		goblin_count = goblin;
	}
	public void set_Spid(Spider_Stats s1, Spider_Stats s2, Spider_Stats s3, int spider)
	{
		spider1 = s1;
		spider2 = s2;
		spider3 = s3;
		spider_count = spider;
	}
	public void set_Troll(Troll_Stats t1, Troll_Stats t2, Troll_Stats t3, int troll)
	{
		troll1 = t1;
		troll2 = t2;
		troll3 = t3;
		troll_count = troll;
	}
	public Goblin_Stats getGob1()
	{
		return goblin1;
	}
	public Goblin_Stats getGob2()
	{
		return goblin2;
	}
	public Goblin_Stats getGob3()
	{
		return goblin3;
	}
	public Spider_Stats getSpider1()
	{
		return spider1;
	}
	public Spider_Stats getSpider2()
	{
		return spider2;
	}
	public Spider_Stats getSpider3()
	{
		return spider3;
	}
	public Troll_Stats getTroll1()
	{
		return troll1;
	}
	public Troll_Stats getTroll2()
	{
		return troll2;
	}
	public Troll_Stats getTroll3()
	{
		return troll3;
	}
	public int get_GoblinCount()
	{
		return goblin_count;
	}
	public int get_SpiderCount()
	{
		return spider_count;
	}
	public int get_TrollCount()
	{
		return troll_count;
	}
	public void set_TurnOrder(string[] temp)
	{
		turnList = temp;
	}
	public string[] get_TurnOrder()
	{
		return turnList;
	}
	public void set_Tyrant(Tyrant_Stats tyr)
	{
		tyrant = tyr;
	}
	public Tyrant_Stats get_Tyrant()
	{
		return tyrant;
	}
	public void set_enemy(string en1, string en2, string en3)
	{
		enemy1 = en1;
		enemy2 = en2;
		enemy3 = en3;
	}
	public string get_enemy1()
	{
		return enemy1;
	}
	public string get_enemy2()
	{
		return enemy2;
	}
	public string get_enemy3()
	{
		return enemy3;
	}
	public void toggleFlag()
	{
		if(flag)
		{
			flag = false;
		}
		else
		{
			flag = true;
		}
	}
	public bool getFlag()
	{
		return flag;
	}
	public void defendFlag()
	{
		if(defend)
		{
			defend = false;
		}
		else
		{
			defend = true;
		}
	}
	public void attackFlag()
	{
		if(attack)
		{
			attack = false;
		}
		else
		{
			attack = true;
		}
	}
	public void magicFlag()
	{
		if(magic)
		{
			magic = false;
		}
		else
		{
			magic = true;
		}
	}
	public void itemFlag()
	{
		if(item)
		{
			item = false;
		}
		else
		{
			item = true;
		}
	}
	public bool get_attack()
	{
		return attack;
	}
	public bool get_magic()
	{
		return magic;
	}
	public bool get_item()
	{
		return item;
	}
	public bool get_defend()
	{
		return defend;
	}
	public string get_attacked()
	{
		return attacked;
	}
	public void set_attacked(string att)
	{
		attacked = att;
	}
	public void stuffInCombat(int num)
	{
		num_enemies = num;
	}
	public int get_stuffInCombat()
	{
		return num_enemies;
	}
	public void set_EndPlayerAction(bool player)
	{
		endPlayer = player;
	}
	public bool get_EndPlayerAction()
	{
		return endPlayer;
	}
	public bool get_PartyDead()
	{
		if(Olaf.isDead() && Luna.isDead() && Rylai.isDead())
			return true;
		else
			return false;
	}
	public bool get_EnemyDead()
	{
		if( tyrant != null)
		{
			return tyrant.isDead();
		}
		int count=0;
		bool en1 = false, en2 = false, en3 = false;
		for(int i = 0; i<num_enemies -3; i++)
		{
			if(enemies[i].CompareTo("Goblin") == 0)
			{
				if(count == 0)
				{
					en1 = goblin1.isDead();
					count++;
				}	
				else if(count == 1)
				{
					en2 = goblin1.isDead();
					count++;
				}
				else
				{
					en3 = goblin1.isDead();
				}
			}
			else if(enemies[i].CompareTo("Spider") ==0)
			{
				if(count == 0)
				{
					en1 = spider1.isDead();
					count++;
				}	
				else if(count == 1)
				{
					en2 = spider1.isDead();
					count++;
				}
				else
				{
					en3 = spider1.isDead();
				}
			}
			else if(enemies[i].CompareTo("Troll") ==0)
			{
				if(count == 0)
				{
					en1 = troll1.isDead();
					count++;
				}	
				else if(count == 1)
				{
					en2 = troll1.isDead();
					count++;
				}
				else
				{
					en3 = troll1.isDead();
				}
			}
		}
		if(count == 1)
		{
			return en1;
		}
		else if(count == 2)
		{
			if( en1 && en2)
				return true;
			else
				return false;
		}
		else
		{
			if( en1 && en2 && en3)
				return true;
			else 
				return false;
		}
	}
	public void set_Enemies(string[] temp)
	{
		enemies = temp;
	}
	public void set_CurrentPlayer(string temp)
	{
		currentPlayer = temp;
	}
	public string get_CurrentPlayer()
	{
		return currentPlayer;
	}
	public void set_HealTarget(string temp)
	{
		healTarget = temp;
	}
	public string get_HealTarget()
	{
		return healTarget;
	}
	public void set_Heal(string temp)
	{
		heal = temp;
	}
	public string get_Heal()
	{
		return heal;
	}
	public void set_MagicAttack(string temp)
	{
		magicATT = temp;
	}
	public string get_MagicAttack()
	{
		return magicATT;
	}
	public void ResetComm()
	{
		enemy1 = "";
		enemy2 = "";
		enemy3 = "";
		enemies = null;
		flag = false;
		attack = false;
		magic = false;
		item = false;
		defend = false;
		attacked = "";
		num_enemies = 0;
		goblin1 = null;
		goblin2 = null;
		goblin3 = null;
		goblin_count = 0;
		spider1 = null;
		spider2 = null;
		spider3 = null;
		spider_count = 0;
		troll1 = null;
		troll2 = null;
		troll3 = null;
		troll_count = 0;
		tyrant = null;
		turnList = null;
		endPlayer = false;
		currentPlayer ="";
		healTarget = "";
		heal ="";
		magicATT="";
	}

	public bool get_done()
	{
		return done;
	}
	public void set_done(bool arg)
	{
		done = arg;
	}
	public bool get_battleWon()
	{
		return battleWon;
	}
	public void set_battleWon(bool arg)
	{
		battleWon = arg;
	}
	public bool get_battleLost()
	{
		return battleLost;
	}
	public void set_battleLost(bool arg)
	{
		battleLost = arg;
	}
}