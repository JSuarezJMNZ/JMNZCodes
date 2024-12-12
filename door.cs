using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableDoor : MonoBehaviour
{
    public KeyCode interactButton;
    public Sprite openDoorSprite;

    public bool playerInSpace = false;   
    public float delayTime = 2;

    public GameObject playerObject;

    int currentSceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if object is tagged Player
        if (collision.gameObject.CompareTag("Player")) {
            playerInSpace = true;
            // get reference to the player object
            playerObject = collision.gameObject;
        }
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneIndex = scene.buildIndex;
    }
    private void Update()
    {
        if (Input.GetKeyDown(interactButton) && playerInSpace == true)
        {
            // check if PlayerCollection has at least one key
            if (playerObject.GetComponent<PlayerCollection>().numKeys > 0)
            {

                // unlock door
                GetComponent<SpriteRenderer>().sprite = openDoorSprite;
                Invoke("LoadNextScene", delayTime);
                // subtract one from numkeys
                playerObject.GetComponent<PlayerCollection>().numKeys--;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // check if object is tagged Player
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInSpace = false;
            playerObject = null;
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}