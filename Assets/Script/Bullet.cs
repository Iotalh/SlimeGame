using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;
	public AudioSource shootAudio;
	public AudioSource exploAudio;

	// Use this for initialization
	void Start()
	{
		shootAudio.Play();
		rb.velocity = transform.right * speed * -1;
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		exploAudio.Play();
		if (hitInfo.CompareTag("Enemy"))
		{
			//Debug.Log(hitInfo.name);
			Enemy enemy = hitInfo.GetComponent<Enemy>();
			enemy.TakeDamage(damage);
		}

        if (!hitInfo.CompareTag("Player"))
        {
			Instantiate(impactEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

}