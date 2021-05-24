using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float startHealth;
	private float health;

	public int worth = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead = false;

	void Start()
	{
		health = startHealth;
	}

	public void TakeDamage(float amount)
	{
		health = health - amount;


		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	void Die()
	{
		isDead = true;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);
		WaveSpawner.enemeiesAlive--;
		Destroy(gameObject);
		PlayerStats.score = PlayerStats.score + 10;
		PlayerStats.money = PlayerStats.money + 1;
	}
}
