﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpSystem : MonoBehaviour
{
    public float rayDistance = 5f;

    [SerializeField] private LayerMask _interact;
    //public TextMeshPro helpText;
    public TMP_Text helpText_UI;

    public GameObject aim;

    public GameObject MachineDiagram;

    // Update is called once per frame
    private void Start()
    {
        MachineDiagram.SetActive(false);
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(aim.transform.position, aim.transform.forward, out hit, rayDistance, _interact))
        {
            if (hit.transform.CompareTag("Help")) 
            {
                helpText_UI.gameObject.SetActive(true);
                helpText_UI.SetText(hit.transform.GetComponent<HelpText>().helpTex);
            }
            if (hit.transform.CompareTag("Diagram"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    MachineDiagram.SetActive(true);                  
                }
                if (Input.GetKeyDown(KeyCode.Escape) && MachineDiagram.activeSelf)
                {
                    MachineDiagram.SetActive(false);
                }
            }
        }
        else
        {
            helpText_UI.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Interaction();
        }
    }
    private void Interaction() 
    {
        RaycastHit hit;
        if (Physics.Raycast(aim.transform.position, aim.transform.forward, out hit, rayDistance, _interact))
        {
            if (hit.collider.TryGetComponent(out Interaction interactionObject))
            {
                interactionObject.Interact();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(aim.transform.position, aim.transform.forward * rayDistance);
    }
}
