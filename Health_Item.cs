using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Item : MonoBehaviour
{
    [SerializeField] private int healthAmount = 5;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			// add health to player
			
collision.gameObject.GetComponent<playerHealth>().TakeHealth(healthAmount);
			// destroy self
			Destroy(gameObject);
		}
	}
}