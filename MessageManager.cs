using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public static MessageManager messageManager;
    public TextMeshProUGUI messageText;

    private Coroutine dialogueCoroutine;

    void Awake()
    {
        if (messageManager == null)
        {
            messageManager = this;
        }
    }

    // New method for multiple messages
    public void ShowDialogueSequence(string sender, string[] dialogueLines)
    {
        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
        }
        dialogueCoroutine = StartCoroutine(DisplayDialogue(sender, dialogueLines));
    }

    private IEnumerator DisplayDialogue(string sender, string[] dialogueLines)
    {
        foreach (string line in dialogueLines)
        {
            string fullMessage = $"{sender}: {line}";
            Debug.Log("Displaying: " + fullMessage);
            messageText.text = fullMessage;

            yield return new WaitForSeconds(2f); // Time between lines
        }

        // Wait and clear after last line
        yield return new WaitForSeconds(4f);
        messageText.text = "";
    }

    // Optional: fallback for single-line calls
    public void UpdateMessage(Message message)
    {
        Debug.Log("Updating message to: " + message.content);
        messageText.text = message.content;

        if (dialogueCoroutine != null)
        {
            StopCoroutine(dialogueCoroutine);
        }
        dialogueCoroutine = StartCoroutine(ClearAfterDelay());
    }

    private IEnumerator ClearAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        messageText.text = "";
    }
}

[System.Serializable]
public class Message
{
    public string sender;
    public string content;

    public Message(string sender, string content)
    {
        this.sender = sender;
        this.content = content;
    }
}
