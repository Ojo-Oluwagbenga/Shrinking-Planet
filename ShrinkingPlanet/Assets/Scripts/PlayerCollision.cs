using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public GameObject deathEffect;

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Meteor")
		{
			
			//This will be a point of contact to initialize panel open function in the Extrabehaviour script;
			BoardControl extrab = GameObject.Find("PanelHold").GetComponent<BoardControl>();
			extrab.initPanelOpen = 2;
			Debug.Log("Val called");

			GameObject.Find("ControlHold").SetActive(false);

			
			Instantiate(deathEffect, transform.position, transform.rotation);
			GameManager.instance.EndGame();

			AudioManager.instance.Play("PlayerDeath");

			Destroy(gameObject);
		}
	}


}
