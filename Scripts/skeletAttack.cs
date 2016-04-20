using UnityEngine;
using System.Collections;

public class skeletAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	public bool attacking;
	public float rotSpeed;


	hitCol hitCol;
	NavMeshAgent agent;
	Transform tran;
	Animator anim;
	GameObject player;

	playerHP playerHealth;
	skeletHP enemyHealth;
	bool playerInRange;
	public bool dontRot;
	float timer;


	void Awake ()
	{	
		hitCol = GetComponentInChildren<hitCol> ();

		agent = GetComponent<NavMeshAgent> ();
		tran = GetComponent<Transform> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <playerHP> ();
		enemyHealth = GetComponent<skeletHP>();
		anim = GetComponent <Animator> ();
		dontRot = false;
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}


	void Update ()
	{
		timer += Time.deltaTime;

		Vector3 relativePos = player.transform.position - transform.position;
		Quaternion targetRot = Quaternion.LookRotation (relativePos);


		if (dontRot == false) 
		{
			
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRot, Time.time * rotSpeed);
		}


		if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
		{
			attacking = true; 
			Attack ();
		}

		if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger ("PlayerDead");
		}
	}


	void Attack ()
	{
		timer = 0f;

		if(playerHealth.currentHealth > 0)
		{
		
			dontRot = true;

			anim.SetTrigger ("Attack");
			
		}
	}


	void Act2()
	{
		if (hitCol.attRange == true) 
		{
			playerHealth.TakeDamage (attackDamage);
		
		}
	}

	void Act3()
	{
		 
		attacking = false;

		dontRot = false;

		
	}

}	
