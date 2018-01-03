using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	
	public float health = 150;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Projectile missile = collision.gameObject.GetComponent<Projectile>();
		if(missile)
		{
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0)
			{
				Destroy(gameObject);
			}
		}
		
	}

	private void Update()
	{
		
	}

}
