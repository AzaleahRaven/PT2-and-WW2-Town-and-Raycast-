public class TrainDude : NPC
{
    public override void Start()
    {
        name = "Lost Guy"; // Set the NPC name
        base.Start(); // Call the base Start method
    }

    public override void Talk()
    {
        MessageManager.messageManager.ShowDialogueSequence("Train Guy", new string[]
        {
        "They told me this is the way to the subway",
        "I don't see any trains",
        "This world is weird, bro..."
        });
    }

}
