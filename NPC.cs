using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCData npcData; 
    public virtual void Start()
    {
        // For overrides
    }

    public virtual void Talk()
    {
        npcData.Talk();
    }

    public NPCData GetData()
    {
        return npcData;
    }
}
