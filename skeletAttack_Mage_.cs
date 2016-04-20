using UnityEngine;
using System.Collections;

public class skeletAttack_Mage_ : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	public bool attacking;
	public float rotSpeed;

	public GameObject ball;
	public Transform point;


	Animator anim;
	GameObject player;
	skeletMove_Mage_ Mage;
	playerHP playerHealth;
	skeletHP_Mage_ enemyHealth;
	bool playerInRange;
	public bool dontRot;
	float timer;


	void Awake ()
	{	
		
		Mage = GetComponent<skeletMove_Mage_> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <playerHP> ();
		enemyHealth = GetComponent<skeletHP_Mage_>();
		anim = GetComponent <Animator> ();
		dontRot = false;
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


		if(timer >= timeBetweenAttacks && Mage.playerInRange == true && enemyHealth.currentHealth > 0)
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
		Quaternion quat = transform.rotation;
		//quat.y -= 180;
		Instantiate (ball, point.position, quat);
	
	}


	void ActFinale()
	{
		attacking = false;
		dontRot = false;
	}



}	
