using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetA : MonoBehaviour
{

	public GameObject whiteParticleGO;
	

	

	private void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.name == "Player")
		{
			playParticle();

			Destroy(gameObject);
			ScoreManager.AddScore(10);
		}	
		
		if (other.gameObject.CompareTag("Wall"))
		{
			Destroy(gameObject);
		}
		
	}
	
	void playParticle()
	{
		GameObject explosion = (GameObject) Instantiate(whiteParticleGO);
		explosion.transform.position = transform.position;
	}
}
