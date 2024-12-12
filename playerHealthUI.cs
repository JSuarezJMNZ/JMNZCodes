using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealthUI : MonoBehaviour
{
    //
    public GameObject heartPrefab;
    public GameObject heartContainer;
    public playerHealth playerHealthScript;

    int previousHealthValue = 0;
    
    private void Start()
    {
        playerHealthScript = GetComponent<playerHealth>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (previousHealthValue != playerHealthScript.health)
        {
            // update our UI
            // clear the health container, remove all hearts
            var allHearts =
 heartContainer.transform.GetComponentsInChildren<Image>();
            foreach (var heart in allHearts)
            {
                Destroy(heart.gameObject);
            }
            // add the number of heart we have
            for (int i = 0; i < playerHealthScript.health; i++)
            {
                Instantiate(heartPrefab, heartContainer.transform);
            }
        }
        previousHealthValue = playerHealthScript.health;
    }
}
