using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject canvasObject;
    [SerializeField] private KeyCode optionsMenuKey;


    // Start is called before the first frame update
    void Start()
    {
        // auto sets the canvas inactive when scene loads
        canvasObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(optionsMenuKey))
        {
            canvasObject.SetActive(!canvasObject.activeSelf);
        }
    }
}
