using UnityEngine;
using System.Collections;

public class Olaf_stats {

	//default stats
	private static int str = 43; // Strength 
	private static int dex = 23; // Dexterity
	private static int con = 30; // Constitution
	private static int intel = 25; // Intellegence 
	private static int speed = 37; // Speed
	private static int HP = 73; // Max HP = Con + str
	public static int current_HP = 73; // Current HP
	public static int MP = 25;
	public static int current_MP = 25;
	public static bool Dead = false;
	public static bool defending = false;
	private static Inventory iven = new Inventory ();

	public static int potions;
	public static int elixirs;
	
	public void isHit(int damage)
	{
		if (HP == current_HP)
			current_HP = HP - damage;
		else
			current_HP = current_HP - damage; 
		if(current_HP <=0)
		{
			dead ();
		}
	}
	public void heal (int heal)
	{
		current_HP = current_HP + heal;
		if (current_HP > HP)
		{
			current_HP = HP;
		}
	}
	public void healMP (int heal)
	{
		current_MP = current_MP + heal;
		if (current_MP > MP)
		{
			current_MP = MP;
		}
	}
	public void useMP(int used)
	{
		if (MP == current_MP)
			current_MP = MP - used;
		else
			current_MP = current_MP - used; 
		if(current_MP<0)
			current_MP=0;
	}
	
	public int get_str()
	{
		return str;
	}
	public int get_dex()
	{
		return dex;
	}
	public int get_con()
	{
		return con;
	}
	public int get_intel()
	{
		return intel;
	}
	public int get_speed()
	{
		return speed;
	}
	public int get_totalHP()
	{
		return HP;
	}
	public int get_currentHP()
	{
		return current_HP;
	}
	public void dead()
	{
		current_HP = 0;
		Dead = true;
	}
	public bool isDead()
	{
		return Dead;
	}
	public void ToggleDefend()
	{
		defending = true;
	}
	public bool isDefending()
	{
		return defending;
	}
	public void usePotion()
	{
		iven.useItem ("Potion");
	}
	public bool EmptyPotions()
	{
		int[] temp;
		temp = iven.get_invenCount ();
		potions = temp [0];
		if(potions == 0)
			return true;
		else
			return false;
	}
	public int get_potions()
	{
		int[] temp;
		temp = iven.get_invenCount ();
		potions = temp [0];
		return potions;
	}
	public int get_elixirs()
	{
		int[] temp;
		temp = iven.get_invenCount ();
		elixirs = temp [1];
		return elixirs;
	}
	public int get_MP()
	{
		return MP;
	}
	public int get_CurrentMP()
	{
		return current_MP;
	}
	public void useElixirs()
	{
		iven.useItem ("Elixir");
	}
	public bool EmptyElixirs()
	{
		int[] temp;
		temp = iven.get_invenCount ();
		elixirs = temp [1];
		if(elixirs == 0)
			return true;
		else
			return false;
	}
}