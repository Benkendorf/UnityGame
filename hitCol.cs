using UnityEngine;
using System.Collections;

public class hitCol : MonoBehaviour {

	GameObject player;

	public bool attRange;


	// Use this for initialization
	void Awake () {

		player = GameObject.FindGameObjectWithTag ("Player");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			attRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			attRange = false;
		}
	}




}
