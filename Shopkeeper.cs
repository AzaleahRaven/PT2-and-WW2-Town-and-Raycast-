public class Shopkeeper : NPC
{
    public override void Start()
    {
        name = "Marie"; // Set the NPC name
        base.Start(); // Call the base Start method
    }

    public override void Talk()
    {
        MessageManager.messageManager.ShowDialogueSequence("Marie", new string[]
        {
        "Hello, this is Marie.",
        "We're out of stock today.",
        "Please come back soon."
        });
    }

}
