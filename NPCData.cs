using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/Create NPC", order = 1)]
public class NPCData : ScriptableObject
{
    public string npcName; // NPC Name
    public string[] dialogue; // Array of dialogues

    // This method will be used to handle the dialogues
    public void Talk()
    {
        // Show each line of dialogue (can be extended to handle more complex scenarios)
        for (int i = 0; i < dialogue.Length; i++)
        {
            Message message = new Message(npcName, dialogue[i]);
            MessageManager.messageManager.UpdateMessage(message);
        }
    }
}
