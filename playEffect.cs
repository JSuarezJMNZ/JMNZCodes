using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playEffect : MonoBehaviour
{
    // AudioSource Variable
    [SerializeField] AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        // refernce to the AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Logic for when to play
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            audioSource.Play();
        }
    }
}
