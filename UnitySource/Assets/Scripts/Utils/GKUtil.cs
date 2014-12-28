using UnityEngine;
using System.Collections;

public class GKUtil {


	public static TextAsset LoadTextAsset(string path)
	{
		try {
			return Resources.Load(path, typeof(TextAsset)) as TextAsset;
		} catch (System.Exception ex) {
			Debug.LogError("Cannot load TextAsset with path "+path+", error: "+ex.Message);
		}

		return null;
	}
}
