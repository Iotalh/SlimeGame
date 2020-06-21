using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public int maxHealth = 100;
	public int damage = 20;
	public int heal = 10;
	public int currentHealth;
	public HealthBar healthBar;
    private void Start()
    {
		currentHealth = maxHealth;
		healthBar.setMaxHealth(maxHealth);
		healthBar.setHealth(currentHealth);
	}

    public void TakeDamage(int damage)
	{
		if (currentHealth > 0)
		{
			currentHealth -= damage;
		}
		healthBar.setHealth(currentHealth);
		if (currentHealth <= 0)
		{
			SceneManager.LoadScene(2);
		}
	}

	public void HealHP(int heal)
    {
		if (currentHealth > 0)
		{
			currentHealth += heal;
		}
		healthBar.setHealth(currentHealth);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Enemy"))
		{
			TakeDamage(damage);
		}

	}
}
