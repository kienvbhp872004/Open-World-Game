using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_info_UI;
    TextMeshProUGUI interaction_info_text;
    public float maxDistance = 5f;
    public bool onTarget = false;
    public GameObject selectedObject;
    public static SelectionManager instance {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        interaction_info_text = interaction_info_UI.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            InteractableObject interactable = selection.GetComponent<InteractableObject>();
            if (interactable&& interactable.playerInRange)
            {
                selectedObject = interactable.gameObject;
                onTarget = true;
                interaction_info_text.text = interactable.GetNameObject();
                interaction_info_UI.SetActive(true);
                print(hit.transform.name);
            }
            else
            {
                onTarget = false;
                interaction_info_UI.SetActive(false);
                
            }
        }
        else
        {
            onTarget = false;
            
        }
    }
}
