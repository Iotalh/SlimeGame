
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health = 100;
	public GameObject impactEffect;
	public AudioSource deathAudio;
    public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			deathAudio.Play();
			Die();
		}
	}

	void Die()
	{
		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}