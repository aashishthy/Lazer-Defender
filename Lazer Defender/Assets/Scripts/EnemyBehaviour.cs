﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	
	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float shotPerSecond = 0.5f;
	public int scoreValue = 150;
	public AudioClip explosion;
	public AudioClip fireSound;

	private ScoreKeeper scoreKeeper;


	private void Start()
	{
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Projectile missile = collision.gameObject.GetComponent<Projectile>();
		if(missile)
		{
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0)
			{
				scoreKeeper.Score(scoreValue);
				AudioSource.PlayClipAtPoint(explosion, Camera.main.transform.position);
				Destroy(gameObject);
			}
		}
		
	}

	private void Update()
	{
		float probability = Time.deltaTime * shotPerSecond;
		if (Random.value < probability) 
			Fire();
	}

	void Fire()
	{
		Vector3 start = transform.position + new Vector3(0, -1, 0) ;
		GameObject lazerBeam = Instantiate(projectile, start, Quaternion.identity) as GameObject;
		lazerBeam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position);
	}

}
