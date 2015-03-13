using UnityEngine;
using System.Collections;

public class Tyrant_Stats {

	private int str = 30; //Strength
	private int dex = 34; //Dexterity
	private int con = 34; //Constitution
	private int intel = 20; //Intelligence
	private int speed = 27; //Speed
	private int HP = 600; //Max HP
	public int current_HP = 600; //Current HP
	public  bool Dead = false;
	public bool Dance = false;

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
	public void isDance()
	{
		if(Dance)
			Dance = false;
		else
			Dance = true;
	}
	public bool get_Dance()
	{
		return Dance;
	}
}
