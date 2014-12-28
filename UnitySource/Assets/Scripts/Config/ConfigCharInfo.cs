using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FileHelpers;
using System.Reflection;
using System.Linq;
using System.Text;

[DelimitedRecord("\t")]
[IgnoreEmptyLines(true)]
[IgnoreFirst(1)]
[IgnoreCommentedLines("//")]
public class ConfigCharInfoItem {

	public int id;
	public int health;
	public int maxHealth;
	public int attackDamage;
	public float moveSpeed;
	public int level;
	public int exp;


	public override string ToString ()
	{
		return string.Format ("id:{0} health:{1} attackDamage:{2}", id, health, attackDamage);
	}
}



public class ConfigCharInfo: GConfigDataTable<ConfigCharInfoItem>
{
	public ConfigCharInfo():base("ConfigCharInfo")
	{

	}

	public List<ConfigCharInfoItem> GetAllItems()
	{
		return records;
	}

	public ConfigCharInfoItem GetItemById(int id)
	{
		foreach (var item in GetAllItems ()) {
			if(item.id == id )
				return item;
		}

		return null;
	}

}
