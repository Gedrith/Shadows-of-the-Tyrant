using UnityEngine;
using System.Collections;

public class EnemyAction {

	private Communicator comm = new Communicator();
	private Olaf_stats Olaf = new Olaf_stats();
	private Luna_stats Luna = new Luna_stats ();
	private Rylai_stats Rylai = new Rylai_stats ();
	private int num_people;
	private Goblin_Stats goblin1;
	private Goblin_Stats goblin2;
	private Goblin_Stats goblin3;
	private Spider_Stats spider1;
	private Spider_Stats spider2;
	private Spider_Stats spider3;
	private Troll_Stats troll1;
	private Troll_Stats troll2;
	private Troll_Stats troll3;
	private Tyrant_Stats tyrant;
	private string[] turnList = new string[6];
	public bool end;
	public string enemy;
	public static int dance_count = 0;

	public void start(string name)
	{
		end = false;
		enemy = name;
		num_people = comm.get_stuffInCombat ();
		turnList = comm.get_TurnOrder ();
		loadInformation ();
	}
	public void loadInformation()
	{
		if(enemy.CompareTo("Goblin") == 0)
		{
			goblin1 = comm.getGob1();
			if(!goblin1.isDead())
			{
				Attack();
			}
		}
		else if(enemy.CompareTo("Troll") == 0)
		{
			troll1 = comm.getTroll1();
			if(!troll1.isDead())
			{
				Attack();
			}
		}
		else if(enemy.CompareTo("Spider") == 0)
		{
			spider1 = comm.getSpider1();
			if(!spider1.isDead())
			{
				Attack();
			}
		}
		else if(enemy.CompareTo("Tyrant") == 0)
		{
			tyrant = comm.get_Tyrant();
			if(!tyrant.isDead())
			{
				Attack();
			}
		}
	}
	public void Attack()
	{
		int j = (int) Random.Range(1f, 13f); // determines which player gets attacked random number from 1 to 12
		if(enemy.CompareTo("Spider") == 0)
		{
			//Animations
			Animation anim = GameObject.FindGameObjectWithTag("Spider").GetComponent<Animation>();
			anim.PlayQueued("Attack", QueueMode.PlayNow);
			anim.PlayQueued("Idle", QueueMode.CompleteOthers);

			if(j<=4) // attacks Olaf
			{
				int dodge = Olaf.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = spider1.get_str() + enemy_hit;
				damage = (int)(spider1.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Olaf is hit");
					if(Olaf.isDefending())
						Olaf.isHit (damage/2);
					else
						Olaf.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Olaf");
				}
			}
			else if(j<=8) // attacks Luna
			{
				int dodge = Luna.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = spider1.get_str() + enemy_hit;
				damage = (int)(spider1.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Luna is hit");
					if(Luna.isDefending())
						Luna.isHit (damage/2);
					else
						Luna.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Luna");
				}
			}
			else if(j<13) // attacks Rylai
			{
				int dodge = Rylai.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = spider1.get_str() + enemy_hit;
				damage = (int)(spider1.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Rylai is hit");
					if(Rylai.isDefending())
						Rylai.isHit (damage/2);
					else
						Rylai.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Rylai");
				}
			}
		}
		else if(enemy.CompareTo("Troll") == 0)
		{
			//Animations
			Animation anim = GameObject.FindGameObjectWithTag("Troll").GetComponent<Animation>();
			anim.PlayQueued("Attack_01", QueueMode.PlayNow);
			anim.PlayQueued("Idle_01", QueueMode.CompleteOthers);

			if(j<=4) // attacks Olaf
			{
				int dodge = Olaf.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = (int)(troll1.get_str() * Random.Range (0.75f,1f));
				damage = troll1.get_str();
				if(hit > dodge)
				{
					Debug.Log("Olaf is hit");
					if(Olaf.isDefending())
						Olaf.isHit (damage/2);
					else
						Olaf.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Olaf");
				}
			}
			else if(j<=8) // attacks Luna
			{
				int dodge = Luna.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = troll1.get_str() + enemy_hit;
				damage = (int)(troll1.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Luna is hit");
					if(Luna.isDefending())
						Luna.isHit (damage/2);
					else
						Luna.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Luna");
				}
			}
			else if(j<13) // attacks Rylai
			{
				int dodge = Rylai.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = troll1.get_str() + enemy_hit;
				damage = (int)(troll1.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Rylai is hit");
					if(Rylai.isDefending())
						Rylai.isHit (damage/2);
					else
						Rylai.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Rylai");
				}
			}
		}
		else if(enemy.CompareTo("Goblin")== 0)
		{
			//Animations
			Animation anim = GameObject.FindGameObjectWithTag("Goblin").GetComponent<Animation>();
			anim.PlayQueued("attack2", QueueMode.PlayNow);
			anim.PlayQueued("combat_idle", QueueMode.CompleteOthers);

			if(j<=4) // attacks Olaf
			{
				int dodge = Olaf.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = goblin1.get_str() + enemy_hit;
				damage = (int)(goblin1.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Olaf is hit");
					if(Olaf.isDefending())
						Olaf.isHit (damage/2);
					else
						Olaf.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Olaf");
				}
			}
			else if(j<=8) // attacks Luna
			{
				int dodge = Luna.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = goblin1.get_str() + enemy_hit;
				damage = (int)(goblin1.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Luna is hit");
					if(Luna.isDefending())
						Luna.isHit (damage/2);
					else
						Luna.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Luna");
				}
			}
			else if(j<13) // attacks Rylai
			{
				int dodge = Rylai.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = goblin1.get_str() + enemy_hit;
				damage = (int)(goblin1.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Rylai is hit");
					if(Rylai.isDefending())
						Rylai.isHit (damage/2);
					else
						Rylai.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Rylai");
				}
			}
		}
		else
		{
			
			//Animations
			Animation anim = GameObject.FindGameObjectWithTag("Tyrant").GetComponent<Animation>();
			anim.PlayQueued("attack01", QueueMode.PlayNow);
			anim.PlayQueued("idle", QueueMode.CompleteOthers);

			if(j<=4) // attacks Olaf
			{
				int dodge = Olaf.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = tyrant.get_str() + enemy_hit;
				damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Player is hit");
					if(Olaf.isDefending())
						Olaf.isHit (damage/2);
					else
						Olaf.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Olaf");
				}
			}
			else if(j<=8) // attacks Luna
			{
				int dodge = Luna.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = tyrant.get_str() + enemy_hit;
				damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Player is hit");
					if(Luna.isDefending())
						Luna.isHit (damage/2);
					else
						Luna.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Luna");
				}
			}
			else if(j<13) // attacks Rylai
			{
				int dodge = Rylai.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = tyrant.get_str() + enemy_hit;
				damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f));
				if(hit > dodge)
				{
					Debug.Log("Player is hit");
					if(Rylai.isDefending())
						Rylai.isHit (damage/2);
					else
						Rylai.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Rylai");
				}
			}
		}
	}
	void TyrantAttacks()
	{
		int j = (int) Random.Range(1f, 13f);
		int k = (int)Random.Range (1f, 11f);
		if(dance_count == 2)
		{
			dance_count = 0;
			tyrant.isDance();
		}
		if(k<5)//Normal Attack
		{
			if(j<=4) // attacks Olaf
			{
				int dodge = Olaf.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = tyrant.get_str() + enemy_hit;
				if(tyrant.get_Dance())
				{
					damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f)) + 12;
				}
				else
				{
					damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f));
				}
				if(hit > dodge)
				{
					Debug.Log("Player is hit");
					if(Olaf.isDefending())
						Olaf.isHit (damage/2);
					else
						Olaf.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Olaf");
				}
			}
			else if(j<=8) // attacks Luna
			{
				int dodge = Luna.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = tyrant.get_str() + enemy_hit;
				if(tyrant.get_Dance())
				{
					damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f)) + 12;
				}
				else
				{
					damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f));
				}
				if(hit > dodge)
				{
					Debug.Log("Player is hit");
					if(Luna.isDefending())
						Luna.isHit (damage/2);
					else
						Luna.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Luna");
				}
			}
			else if(j<13) // attacks Rylai
			{
				int dodge = Rylai.get_dex();
				int damage, hit;
				int enemy_hit = (int) Random.Range(0f, 101f);
				hit = tyrant.get_str() + enemy_hit;
				if(tyrant.get_Dance())
				{
					damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f)) + 12;
				}
				else
				{
					damage = (int)(tyrant.get_str() * Random.Range (0.75f,1f));
				}
				if(hit > dodge)
				{
					Debug.Log("Player is hit");
					if(Rylai.isDefending())
						Rylai.isHit (damage/2);
					else
						Rylai.isHit(damage);
				}
				else
				{
					Debug.Log("Enemy Missed Rylai");
				}
			}
		}
		else if(k<=8)//Ram attack
		{
			if(tyrant.get_Dance())
			{
				int damage = (int)(tyrant.get_str () * Random.Range (0.9f,1f)) + 12;
				Olaf.isHit(damage);
				Luna.isHit(damage);
				Rylai.isHit(damage);
			}
			else
			{
				int damage = (int)(tyrant.get_str () * Random.Range (0.9f,1f));
				Olaf.isHit(damage);
				Luna.isHit(damage);
				Rylai.isHit(damage);
			}
		}
		else//DANCE!!!!!!
		{
			tyrant.isDance();
		}
		if(tyrant.get_Dance())
		{
			dance_count++;
		}
	}

}
