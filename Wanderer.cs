public class Wanderer : NPC
{
    public override void Start()
    {
        name = "Boris"; // Set the NPC name
        base.Start(); // Call the base Start method
    }

    public override void Talk()
    {
        MessageManager.messageManager.ShowDialogueSequence("Boris", new string[]
        {
        "Why is everything so plain?",
        "Where are the bears?",
        "This is nothing like Russia!"
        });
    }

}
