using UnityEngine;
using System.Collections;

public class ballMove : MonoBehaviour {

	private Rigidbody rigid;
	private GameObject player;
	private Vector3 relativePos;
	private Vector3 mage;
	public float speed;
	private bool explode;

	playerHP playerHP;
	//ParticleSystem explosion;


	public int damage;


	void Awake()
	{
		//explosion = GameObject.FindGameObjectWithTag ("Explosion").GetComponent<ParticleSystem>();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHP = player.GetComponent<playerHP> ();
		mage = new Vector3(transform.position.x,transform.position.y,transform.position.z);

		rigid = GetComponent<Rigidbody> ();

		rigid.AddForce (transform.forward * speed);
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9) {				//SHOOTABLE

		} else if(other.gameObject.tag == "Player")
		{
			playerHP.TakeDamage (damage);
			Explode ();
		}
		else {
			//explode = true;
			Explode();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, mage) >= 30) {
			Destroy (gameObject);
		}



	}

	void Explode ()
	{
		//explosion.Play ();
		Destroy (gameObject);
	}
}
