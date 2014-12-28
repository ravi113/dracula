using UnityEngine;
using System.Collections;

public class PlayerController : CharBase {

	public SpriteRenderer spriteRender;

	// Use this for initialization
	void Start () {
		GKConfigManager.Instance.LoadAll();
		foreach (var item in GKConfigManager.configCharInfo.GetAllItems()) {
			Debug.LogError(item);
				}
	}
	
	// Update is called once per frame
	void Update () {
		if(isDeath)
			return;

		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		if(Input.GetKey(KeyCode.A))
		{
			OnMove(Vector3.left);
		}
		else if(Input.GetKey(KeyCode.D))
		{
			OnMove(Vector3.right);
		}else if(Input.GetKey(KeyCode.W))
		{
			OnMove(Vector3.up);
		}else if(Input.GetKey(KeyCode.S))
		{
			OnMove(Vector3.down);
		}


	}

}
