using UnityEngine;
using System.Collections;

public class PlayerAction
{
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
	private string player;
	private string command;
	public bool end;
	private string heal;
	private string HealTarget;

	public void start(string com, string name)
	{
		end = false;
		player = name;
		command = com;
		num_people = comm.get_stuffInCombat ();
		turnList = comm.get_TurnOrder ();
		loadInformation ();
		if(player.CompareTo("Luna") == 0)
		{
			if(Luna.isDefending())
				Luna.ToggleDefend();
		}
		else if(player.CompareTo("Olaf") == 0)
		{
			if(Olaf.isDefending())
				Olaf.ToggleDefend();
		}
		else
		{
			if(Rylai.isDefending())
				Rylai.ToggleDefend();
		}

		if(command.CompareTo("attack") == 0)
		{
			Attack();
		}
		if(command.CompareTo("defend") == 0)
		{
			if(player.CompareTo("Luna") == 0)
				Luna.ToggleDefend();
			else if (player.CompareTo("Olaf") == 0)
				Olaf.ToggleDefend();
			else
				Rylai.ToggleDefend();

			end = true;
			comm.set_EndPlayerAction(end);
		}
		if(command.CompareTo("Item") == 0)
		{
			heal = comm.get_Heal();
			HealTarget = comm.get_HealTarget();
			HealCharacter();
		}
		if(command.CompareTo("Magic") == 0)
		{
			if(comm.get_HealTarget().CompareTo("") != 0)
			{
				Debug.Log (comm.get_Heal());
				heal = comm.get_Heal();
				HealTarget = comm.get_HealTarget();
				HealCharacter ();
			}
			if(comm.get_attacked().CompareTo("") != 0)
			{
				MagicAttack();
			}
		}
	}
	public void loadInformation()
	{
			if(comm.get_attacked().CompareTo("Goblin") == 0)
			{
				goblin1 = comm.getGob1();
			}
		else if(comm.get_attacked().CompareTo("Troll") == 0)
			{
				troll1 = comm.getTroll1();
			}
		else if(comm.get_attacked().CompareTo("Spider") == 0)
			{
				spider1 = comm.getSpider1();
			}
		else if(comm.get_attacked().CompareTo("Tyrant") == 0)
			{
				tyrant = comm.get_Tyrant();
			}
	}
	public void Attack()
	{
		string attacked = comm.get_attacked();
		if(player.CompareTo("Luna") == 0)
		{
			Luna_Attacks();
		}
		else if(player.CompareTo("Olaf") == 0)
		{
			Olaf_Attacks();
		}
		else
		{
			Rylai_Attacks();
		}
	}

	public void Luna_Attacks()
	{
		//Animations
		Animator anim = GameObject.Find("BattleLuna").GetComponent<Animator>();
		anim.SetTrigger("Attack");

		Debug.Log ("Luna attacked "+comm.get_attacked()+" in his bitch ass");
		//Calculations
		if(comm.get_attacked().CompareTo("Goblin") == 0)
		{
			int dodge = goblin1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Luna.get_dex() + Player_hit;
			damage = (int)((Luna.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Luna Hit Goblin for " +damage);
				goblin1.isHit(damage);
				Debug.Log ("Goblin is at "+goblin1.current_HP+" of "+goblin1.get_totalHP());
			}
			else
			{
				Debug.Log("Luna missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Troll") == 0)
		{
			int dodge = troll1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Luna.get_dex() + Player_hit;
			damage = (int)((Luna.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Luna Hit Troll for " +damage);
				troll1.isHit(damage);
				Debug.Log ("Troll is at "+troll1.current_HP+" of "+troll1.get_totalHP());
			}
			else
			{
				Debug.Log("Luna missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Spider") == 0)
		{
			int dodge = spider1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Luna.get_dex() + Player_hit;
			damage = (int)((Luna.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Luna Hit Spider for " +damage);
				spider1.isHit(damage);
				Debug.Log ("Spider is at "+spider1.current_HP+" of "+spider1.get_totalHP());
			}
			else
			{
				Debug.Log("Luna missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Tyrant") == 0)
		{
			int dodge = tyrant.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Luna.get_dex() + Player_hit;
			damage = (int)((Luna.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Luna Hit Tyrant for " +damage);
				tyrant.isHit(damage);
				Debug.Log ("Tyrant is at "+tyrant.current_HP+" of "+tyrant.get_totalHP());
			}
			else
			{
				Debug.Log("Luna missed");
			}
		}
		end = true;
		comm.set_EndPlayerAction(end);
	}
	public void Olaf_Attacks()
	{
		//Animations
		Animator anim = GameObject.Find("BattleOlaf").GetComponent<Animator>();
		anim.SetTrigger("Attack");

		Debug.Log ("Olaf attacked "+comm.get_attacked()+" in his bitch ass");
		if(comm.get_attacked().CompareTo("Goblin") == 0)
		{
			int dodge = goblin1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Olaf.get_str() + Player_hit;
			damage = (int)((Olaf.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Olaf Hit Goblin for " +damage);
				goblin1.isHit(damage);
				Debug.Log ("Goblin is at "+goblin1.current_HP+" of "+goblin1.get_totalHP());
			}
			else
			{
				Debug.Log("Olaf missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Troll") == 0)
		{
			int dodge = troll1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Olaf.get_str() + Player_hit;
			damage = (int)((Olaf.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Olaf Hit Troll for " +damage);
				troll1.isHit(damage);
				Debug.Log ("Troll is at "+troll1.current_HP+" of "+troll1.get_totalHP());
			}
			else
			{
				Debug.Log("Olaf missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Spider") == 0)
		{
			int dodge = spider1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Olaf.get_str() + Player_hit;
			damage = (int)((Olaf.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Olaf Hit Spider for " +damage);
				spider1.isHit(damage);
				Debug.Log ("Spider is at "+spider1.current_HP+" of "+spider1.get_totalHP());
			}
			else
			{
				Debug.Log("Olaf missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Tyrant") == 0)
		{
			int dodge = tyrant.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Olaf.get_str() + Player_hit;
			damage = (int)((Olaf.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Olaf Hit Tyrant for " +damage);
				tyrant.isHit(damage);
				Debug.Log ("Tyrant is at "+tyrant.current_HP+" of "+tyrant.get_totalHP());
			}
			else
			{
				Debug.Log("Olaf missed");
			}
		}
		end = true;
		comm.set_EndPlayerAction(end);
	}
	public void Rylai_Attacks()
	{
		//Animations
		Animator anim = GameObject.Find("BattleRylai").GetComponent<Animator>();
		anim.SetTrigger("Attack");

		Debug.Log ("Rylai attacked "+comm.get_attacked()+" in his bitch ass");
		if(comm.get_attacked().CompareTo("Goblin") == 0)
		{
			int dodge = goblin1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Rylai.get_dex() + Player_hit;
			damage = (int)((Rylai.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Rylai Hit Goblin for " +damage);
				goblin1.isHit(damage);
				Debug.Log ("Goblin is at "+goblin1.current_HP+" of "+goblin1.get_totalHP());
			}
			else
			{
				Debug.Log("Rylai missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Troll") == 0)
		{
			int dodge = troll1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Rylai.get_dex() + Player_hit;
			damage = (int)((Rylai.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Rylai Hit Troll for " +damage);
				troll1.isHit(damage);
				Debug.Log ("Troll is at "+troll1.current_HP+" of "+troll1.get_totalHP());
			}
			else
			{
				Debug.Log("Rylai missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Spider") == 0)
		{
			int dodge = spider1.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Rylai.get_dex() + Player_hit;
			damage = (int)((Rylai.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Rylai Hit Spider for " +damage);
				spider1.isHit(damage);
				Debug.Log ("Spider is at "+spider1.current_HP+" of "+spider1.get_totalHP());
			}
			else
			{
				Debug.Log("Rylai missed");
			}
		}
		else if(comm.get_attacked().CompareTo("Tyrant") == 0)
		{
			int dodge = tyrant.get_dex();
			int damage, hit;
			int Player_hit = (int) Random.Range(0f, 101f);
			hit = Rylai.get_dex() + Player_hit;
			damage = (int)((Rylai.get_str() * Random.Range (0.75f,1f)));
			if(hit > dodge)
			{
				Debug.Log("Rylai Hit Tyrant for " +damage);
				tyrant.isHit(damage);
				Debug.Log ("Tyrant is at "+tyrant.current_HP+" of "+tyrant.get_totalHP());
			}
			else
			{
				Debug.Log("Rylai missed");
			}
		}
		end = true;
		comm.set_EndPlayerAction(end);
	}
	public void HealCharacter()
	{
		if(heal.CompareTo("Potion") == 0)
		{
			if(HealTarget.CompareTo("Olaf") == 0)
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Olaf.heal(20);
					Olaf.usePotion();
				}
				else if(player.CompareTo("Luna") == 0)
				{
					Olaf.heal(20);
					Luna.usePotion();
				}
				else
				{
					Olaf.heal(20);
					Rylai.usePotion();
				}

			}
			else if(HealTarget.CompareTo("Luna") == 0)
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Luna.heal(20);
					Olaf.usePotion();
				}
				else if(player.CompareTo("Luna") == 0)
				{
					Luna.heal(20);
					Luna.usePotion();
				}
				else
				{
					Luna.heal(20);
					Rylai.usePotion();
				}
			}
			else
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Rylai.heal(20);
					Olaf.usePotion();
				}
				else if(player.CompareTo("Luna") == 0)
				{
					Rylai.heal(20);
					Luna.usePotion();
				}
				else
				{
					Olaf.heal(20);
					Rylai.usePotion();
				}
			}
		}
		else if (heal.CompareTo("Elixir") == 0)
		{
			if(HealTarget.CompareTo("Olaf") == 0)
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Olaf.healMP(20);
					Olaf.useElixirs();
				}
				else if(player.CompareTo("Luna") == 0)
				{
					Olaf.healMP(20);
					Luna.useElixirs();
				}
				else
				{
					Olaf.healMP(20);
					Rylai.useElixirs();
				}
			}
			else if(HealTarget.CompareTo("Luna") == 0)
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Luna.healMP(20);
					Olaf.useElixirs();
				}
				else if(player.CompareTo("Luna") == 0)
				{
					Luna.healMP(20);
					Luna.useElixirs();
				}
				else
				{
					Luna.healMP(20);
					Rylai.useElixirs();
				}
			}
			else
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Rylai.healMP(20);
					Olaf.useElixirs();
				}
				else if(player.CompareTo("Luna") == 0)
				{
					Rylai.healMP(20);
					Luna.useElixirs();
				}
				else
				{
					Rylai.healMP(20);
					Rylai.useElixirs();
				}
			}
		}
		else
		{
			if(HealTarget.CompareTo("Olaf") == 0)
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Olaf.heal(Olaf.get_intel());
					Olaf.useMP(5);
				}
				else
				{
					Olaf.heal(Rylai.get_intel());
					Rylai.useMP(5);
				}
			}
			else if(HealTarget.CompareTo("Luna") == 0)
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Luna.heal(Olaf.get_intel());
					Olaf.useMP(5);
				}
				else
				{
					Luna.heal(Rylai.get_intel());
					Rylai.useMP(5);
				}
			}
			else
			{
				if(player.CompareTo ("Olaf") == 0)
				{
					Rylai.heal(Olaf.get_intel());
					Olaf.useMP(5);
				}
				else
				{
					Rylai.heal(Rylai.get_intel());
					Rylai.useMP(5);
				}
			}
		}
		end = true;
		comm.set_EndPlayerAction(end);
	}
	public void MagicAttack()
	{
		Debug.Log ("Rylai attacked "+comm.get_attacked()+" with "+comm.get_MagicAttack());
		if(comm.get_attacked().CompareTo("Goblin") == 0)
		{
			if(comm.get_MagicAttack().CompareTo("Fire") == 0)
			{
				int damage;
				damage = Rylai.get_intel();
				Debug.Log("Rylai Hit Goblin for " +damage);
				goblin1.isHit(damage);
				Debug.Log ("Goblin is at "+goblin1.current_HP+" of "+goblin1.get_totalHP());
			}
			else if(comm.get_MagicAttack().CompareTo("Thunder") == 0)
			{
				int damage;
				damage = (int)(Rylai.get_intel() * 0.5f);
				Debug.Log("Rylai Hit Goblin for " +damage);
				goblin1.isHit(damage);
				Debug.Log ("Goblin is at "+goblin1.current_HP+" of "+goblin1.get_totalHP());
			}
			else
			{
				int damage;
				damage = (int)(Rylai.get_intel() * 0.75f);
				Debug.Log("Rylai Hit Goblin for " +damage);
				goblin1.isHit(damage);
				Debug.Log ("Goblin is at "+goblin1.current_HP+" of "+goblin1.get_totalHP());
			}
		}
		else if(comm.get_attacked().CompareTo("Troll") == 0)
		{
			if(comm.get_MagicAttack().CompareTo("Fire") == 0)
			{
				int damage;
				damage = (int)(Rylai.get_intel() * 0.75f);
				Debug.Log("Rylai Hit Troll for " +damage);
				troll1.isHit(damage);
				Debug.Log ("Troll is at "+troll1.current_HP+" of "+troll1.get_totalHP());
			}
			else if(comm.get_MagicAttack().CompareTo("Thunder") == 0)
			{
				int damage;
				damage = Rylai.get_intel();
				Debug.Log("Rylai Hit Troll for " +damage);
				troll1.isHit(damage);
				Debug.Log ("Troll is at "+troll1.current_HP+" of "+troll1.get_totalHP());
			}
			else
			{
				int damage;
				damage = (int)(Rylai.get_intel() * 0.5f);
				Debug.Log("Rylai Hit Troll for " +damage);
				troll1.isHit(damage);
				Debug.Log ("Troll is at "+troll1.current_HP+" of "+troll1.get_totalHP());
			}
		}
		else if(comm.get_attacked().CompareTo("Spider") == 0)
		{
			if(comm.get_MagicAttack().CompareTo("Fire") == 0)
			{
				int damage;
				damage = (int)(Rylai.get_intel());
				Debug.Log("Rylai Hit Spider for " +damage);
				spider1.isHit(damage);
				Debug.Log ("Spider is at "+spider1.current_HP+" of "+spider1.get_totalHP());
			}
			else if(comm.get_MagicAttack().CompareTo("Thunder") == 0)
			{
				int damage;
				damage = (int)(Rylai.get_intel() * 0.75f);
				Debug.Log("Rylai Hit Spider for " +damage);
				spider1.isHit(damage);
				Debug.Log ("Spider is at "+spider1.current_HP+" of "+spider1.get_totalHP());
			}
			else
			{
				int damage;
				damage = (int)(Rylai.get_intel() * 0.75f);
				Debug.Log("Rylai Hit Spider for " +damage);
				spider1.isHit(damage);
				Debug.Log ("Spider is at "+spider1.current_HP+" of "+spider1.get_totalHP());
			}
		}
		else if(comm.get_attacked().CompareTo("Tyrant") == 0)
		{
			if(comm.get_MagicAttack().CompareTo("Fire") == 0)
			{
				int damage;
				damage = (int)(Rylai.get_intel() * 0.5);
				Debug.Log("Rylai Hit Tyrant for " +damage);
				tyrant.isHit(damage);
				Debug.Log ("Tyrant is at "+tyrant.current_HP+" of "+tyrant.get_totalHP());
			}
			else if(comm.get_MagicAttack().CompareTo("Thunder") == 0)
			{
				int damage;
				damage = (int)(Rylai.get_intel());
				Debug.Log("Rylai Hit Tyrant for " +damage);
				tyrant.isHit(damage);
				Debug.Log ("Tyrant is at "+tyrant.current_HP+" of "+tyrant.get_totalHP());
			}
			else
			{
				int damage;
				damage = (int)(Rylai.get_intel() * 0.5f);
				Debug.Log("Rylai Hit Tyrant for " +damage);
				tyrant.isHit(damage);
				Debug.Log ("Tyrant is at "+tyrant.current_HP+" of "+tyrant.get_totalHP());
			}
		}
		Rylai.useMP (7);
		end = true;
		comm.set_EndPlayerAction(end);
	}
}
