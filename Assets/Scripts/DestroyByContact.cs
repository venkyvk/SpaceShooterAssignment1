/* Author: Venkatesh Managoli*/
/* File: DestroyByContact.cs */
/* Creation Date: Sept 30, 2015 */
/* Description: This script controls the destrution of object when come in contact */

using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

		void Start ()
		{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}
			
		if (other.tag == "Player") {
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
			while(gameController.life > 0){
				gameController.SpawnPlayer();
			}
			gameController.GameOver();
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);

		}

			Destroy (other.gameObject);
			gameController.AddScore(scoreValue);
			Destroy (gameObject);
		
	}

}