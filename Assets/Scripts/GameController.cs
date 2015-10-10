/* Author: Venkatesh Managoli*/
/* File: GameController.cs */
/* Creation Date: Sept 30, 2015 */
/* Description: This script controls Game aspects, spwaning of hazards */

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject player;
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public AudioSource[] sounds;
	public AudioSource sound1;
	public AudioSource sound2;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	public int life = 4;


	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "Life :" + life;
		gameOverText.text = "";
		score = 0;
		sounds = GetComponents<AudioSource>();
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void SpawnPlayer ()
	{
		life = (life - 1);
		restartText.text = "Life : " + life;
		Instantiate (player, player.transform.position, player.transform.rotation);
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		sound2.Play ();
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}