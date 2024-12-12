using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

	[SerializeField] public int health = 10;
	public int maxHealth = 10;
	
	public void Start()
	{
		health = maxHealth;
	}
	
	public void TakeDamage(int damageAmount)
	{
		health = health - damageAmount;
		if(health < 1)
		{
			// reset the level!
			SceneManager.LoadScene(0);
		}
	}
	
	public void TakeHealth(int healthAmount)
	{
		health = health + healthAmount;
		if(health > maxHealth)
		{
			health = maxHealth;
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			// damage
		}
	}
}
