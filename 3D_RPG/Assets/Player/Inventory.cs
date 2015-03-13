using UnityEngine;
using System.Collections;

public class Inventory{

	private static string[] inventory;
	private static int[] inventory_count;
	private static int total_inventory = 3; // used for display to know the correct number
											// of items
	public string[] get_inventory()
	{
		return inventory;
	}
	public int[] get_invenCount()
	{
		return inventory_count;
	}
	public int get_totalInven()
	{
		return total_inventory;
	}
	public void set_inventory()
	{
		inventory = new string[10];
		inventory_count = new int[10];
		inventory [0] = "Potion";
		inventory [1] = "Elixir";
		inventory [2] = "Key";

		inventory_count [0] = 10;
		inventory_count [1] = 10;
		inventory_count [2] = 0;
	}
	public void addItem(string item, int number)
	{
		for(int i=0;i<total_inventory;i++)
		{
			if(inventory[i].CompareTo(item) == 0)
				inventory_count[i] += number;
		}
	}
	public void useItem(string item)
	{
		for(int i=0;i<total_inventory;i++)
		{
			if(inventory[i].CompareTo(item) == 0)
				inventory_count[i]--;
		}
	}
}
