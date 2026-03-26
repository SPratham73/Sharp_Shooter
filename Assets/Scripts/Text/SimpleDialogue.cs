using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class SimpleDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public GameObject gameplayUI;
    public GameObject background; 

    string[] lines = {
        "COMMANDER: Ramirez, respond. Do you hear me?",
        "Ramirez: Signal is clear, Commander.",
        "COMMANDER: We've lost control of the station. All systems are now in enemy hands.",
        "Ramirez: Any survivors?",
        "COMMANDER: No survivors. The robots have turned against us. You're the only one left who can handle this.",
        "Ramirez: Mission objective?",
        "COMMANDER: Retrieve the core control chip from the central hub. Once you have the chip, escape the station immediately.",
        "Ramirez: Understood. Commander!",
        "COMMANDER: Stay alert... those machines are no longer under our command.",
        "Ramirez: Copy that. Moving in."
    };

    int index = 0;

    void Start()
    {
        dialogueBox.SetActive(true);
        gameplayUI.SetActive(false);
        background.SetActive(true); 
        index = 0;
        dialogueText.text = lines[index];
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            index++;

            if (index < lines.Length)
            {
                dialogueText.text = lines[index];
            }
            else
            {
                EndDialogue();
            }
        }
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        gameplayUI.SetActive(true);
        background.SetActive(false); 
    }
}