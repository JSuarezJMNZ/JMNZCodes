using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damageDealt = 3;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			// do damage to player
			
	collision.gameObject.GetComponent<playerHealth>().TakeDamage(damageDealt);
			}
		}
	}