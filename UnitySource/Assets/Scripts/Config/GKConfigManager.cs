using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GKConfigManager : Singleton<GKConfigManager> {

	public static ConfigCharInfo configCharInfo;



	private void LoadDataConfig<TConfigTable>(ref TConfigTable configTable, params string[] paths)
		where TConfigTable : IConfigDataTable, new()
	{
		try {
			configTable = new TConfigTable();

			foreach (var path in paths) {
				configTable.LoadFromAssetPath(path);
			}
		} catch (System.Exception ex) {
			Debug.LogError("Load config error: "+configTable.GetName()+", cause: "+ex.ToString() );
		}
	}


	public void LoadAll()
	{
		LoadDataConfig<ConfigCharInfo>(ref configCharInfo, "Config/ConfigCharInfo");
	}
}
