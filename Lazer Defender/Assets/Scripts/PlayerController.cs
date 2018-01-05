using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 1f;
	public float projectileSpeed = 0f;
	public float fireRate = 0.2f;
	public float health = 250f;
	public AudioClip fireSound;

	public GameObject projectile;

	float minX, maxX;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		minX = leftMost.x + padding;
		maxX = rightMost.x - padding;

	}

	void Fire()
	{
		Vector3 start = transform.position + new Vector3(0, 1, 0);
		GameObject lazerBeam = Instantiate(projectile, start, Quaternion.identity) as GameObject;
		lazerBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(fireSound, Camera.main.transform.position);
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			InvokeRepeating("Fire", 0.000001f, fireRate);
		}
		if(Input.GetKeyUp(KeyCode.Space))
		{
			CancelInvoke("Fire");
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}



		//restrict player to namespace
		float newX = Mathf.Clamp(transform.position.x, minX, maxX);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Player Hit");
		Projectile missile = collision.gameObject.GetComponent<Projectile>();
		if (missile)
		{
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0)
			{
				LevelManager manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
				manager.LoadLevel("End Menu");
				Destroy(gameObject);
			}
		}

	}

}
