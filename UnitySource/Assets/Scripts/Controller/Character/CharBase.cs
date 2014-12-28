using UnityEngine;
using System.Collections;


public enum CharState{
	Idle = 0,
	Moving = 1,
	Fly = 2,
	Walk = 3,
	Death = 4,
	Attack = 5
};

public class CharBase : MonoBehaviour {

	// health info
	public int health;
	public int maxHealth;
	public int attackDamage;
	public float moveSpeed;
	public int level;
	public int exp;

	protected bool isDeath;
	protected Animator animator;
	private CharState charState;

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator>();
	}


	public void AttackEnemy(GameObject enemy)
	{
		if(isDeath)
			return;


		charState = CharState.Attack;

		// send message tru mau enemy
		enemy.SendMessage("HittedByEnemy");
	}

	public void HittedByEnemy(int damage)
	{
		health -= damage;
		if(health <0)
		{
			health = 0;
			isDeath = true;
			charState = CharState.Death;
		}
		if(health == 0)
		{
			OnDie();
		}
	}

	public void OnDie()
	{
		Destroy(this.gameObject, 2);
	}

	public void OnMove(Vector3 dir)
	{


		AnimateWithDirection(dir);

		Vector3 newPos = dir * 4 * Time.deltaTime;
		newPos += transform.position;
		Vector3 pos = Camera.main.WorldToViewportPoint(newPos);
		float x = Mathf.Clamp(pos.x, 0.0f, 1.0f);
		float y =  Mathf.Clamp(pos.y, 0.0f, 1.0f);
		pos = new Vector3(x, y, pos.z);
		Vector3 worldPos =  Camera.main.ViewportToWorldPoint(pos);

		if(Vector3.Distance(transform.position, worldPos) < 0.01f)
		{
			charState = CharState.Idle;
		}else
		{
			charState = CharState.Walk;
		}

		transform.position = worldPos;
	}
	

	void AnimateWithDirection(Vector3 dir)
	{

		if(dir == Vector3.left)
		{
			animator.SetInteger("Direction", 1);
		}else if(dir == Vector3.right)
		{
			animator.SetInteger("Direction", 3);
		}else if(dir == Vector3.up)
		{
			animator.SetInteger("Direction", 2);
		}else if(dir == Vector3.down)
		{
			animator.SetInteger("Direction", 0);
		}

	}
}
