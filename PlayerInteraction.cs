using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f; // Interaction range
    public KeyCode interactKey = KeyCode.E; // The key to press to interact with NPCs

    void Update()
    {
        // Detect NPCs in range
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            // Check if the hit object is an NPC
            if (hit.collider.CompareTag("NPC") && Input.GetKeyDown(interactKey))
            {
                NPC npc = hit.collider.GetComponent<NPC>(); // Get the NPC component
                if (npc != null)
                {
                    npc.Talk(); // Trigger the NPC interaction
                }
            }
        }
    }
}
