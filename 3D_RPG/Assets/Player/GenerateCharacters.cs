using UnityEngine;
using System.Collections;

public class GenerateCharacters{
	
	public Olaf_stats Olaf;
	public Luna_stats Luna;
	public Rylai_stats Rylai;
	public Inventory inventory;
	void Start () 
	{
		Olaf = new Olaf_stats ();
		Luna = new Luna_stats ();
		Rylai = new Rylai_stats ();
		inventory = new Inventory ();
		inventory.set_inventory ();
	}
	public Olaf_stats get_Olaf()
	{
		return Olaf;
	}
	public Luna_stats get_Luna()
	{
		return Luna;
	}
	public Rylai_stats get_Rylai()
	{
		return Rylai;
	}
}
