using UnityEngine;

public class skeletHP_Mage_ : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;
	public AudioClip deathClip;
	playerHP playerHP;
	skeletAttack_Mage_ skeletAttack;
	Animator anim;
	AudioSource enemyAudio;
	//ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;


	void Awake ()
	{
		skeletAttack = GetComponent <skeletAttack_Mage_> (); 
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		//hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHP>();
		currentHealth = startingHealth;
	}


	void Update ()
	{
		if(isSinking)
		{
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}


	public void TakeDamage (int amount/*, Vector3 hitPoint*/)
	{
		if(isDead)
			return;

		enemyAudio.Play ();

		currentHealth -= amount;

		//hitParticles.transform.position = hitPoint;
		//hitParticles.Play();

		if(currentHealth <= 0 && playerHP.currentHealth > 0)
		{
			Death ();

		}
	}


	void Death ()
	{
		isDead = true;

		skeletAttack.enabled = false;

		capsuleCollider.isTrigger = true;

		anim.SetTrigger ("Dead");

		enemyAudio.clip = deathClip;
		enemyAudio.Play ();

	}


	public void StartSinking ()
	{	
		//skeletAttack.dontRot = true;
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		//ScoreManager.score += scoreValue;
		Destroy (gameObject, 1f);
	}
}
