using UnityEngine;
using System.Collections;

public class skeletMove_Mage_ : MonoBehaviour
{
	GameObject player;
	playerHP playerHealth;
	skeletHP_Mage_ enemyHealth;
	NavMeshAgent nav;
	Animator anim;
	Transform tran;
	skeletAttack_Mage_ skeletAttack;

	public bool playerInRange;


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		tran = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <playerHP> ();
		enemyHealth = GetComponent <skeletHP_Mage_> ();
		nav = GetComponent <NavMeshAgent> ();
		anim = GetComponent <Animator> ();
		skeletAttack = GetComponent <skeletAttack_Mage_> ();

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
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && skeletAttack.attacking == false)
		{
			nav.enabled = true;
			nav.SetDestination (tran.position);
			Run ();
		}
		else
		{
			nav.enabled = false;
		}
	}





	void Run()
	{
		anim.SetBool ("Walk", true);
	}
}
