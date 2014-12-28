
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Reflection;
using FileHelpers;


public interface IConfigDataTable
{
	/// <summary>
	/// Gets config file name.
	/// </summary>
	/// <returns>The name.</returns>
	string GetName();

	/// <summary>
	/// Load data from string from memory
	/// </summary>
	void LoadFromString(string content);


	/// <summary>
	/// Loads from asset.
	/// </summary>
	/// <param name="textAsset">Text asset.</param>
	void LoadFromAsset(TextAsset textAsset);


	/// <summary>
	/// Loads from asset path.
	/// </summary>
	/// <param name="path">Path.</param>
	void LoadFromAssetPath(string path);

	/// <summary>
	/// Clear all data
	/// </summary>
	void Clear();
	
}

public class GConfigDataTable<TData> : IConfigDataTable where TData : class
{

	public List<TData> records {get; private set;}
	public string name {get; private set;}

	public GConfigDataTable()
	{
		this.name = GetType().Name;
		this.records = new List<TData>();
	}

	public GConfigDataTable(string name)
	{
		this.name = name;
		this.records = new List<TData>();
	}

	public string GetName()
	{
		return name;
	}

	public void LoadFromString (string content)
	{
		if (string.IsNullOrEmpty(content))
			throw new ArgumentException("Content is null or empty");

		FileHelperEngine  engine = new FileHelperEngine(typeof(TData));
		TData[] items = engine.ReadString(content) as TData[];
		records.AddRange(items);
	}

	public void LoadFromAsset (TextAsset textAsset)
	{
		if(textAsset == null)
			throw new ArgumentNullException("TextAsset data is invalid");
		LoadFromString(textAsset.text);
	}

	public void LoadFromAssetPath (string path)
	{
		TextAsset textAsset = GKUtil.LoadTextAsset(path);
		if(textAsset == null)
		{
			Debug.LogError("Cannot found path "+path);
			return;
		}
		LoadFromAsset(textAsset);
	}

	public void Clear ()
	{

	}
}

