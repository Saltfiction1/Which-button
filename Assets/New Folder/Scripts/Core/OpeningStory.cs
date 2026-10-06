using UnityEngine;
using TMPro;

public class OpeningStory : MonoBehaviour
{
    [Header("Opening UI")]
    public TMP_Text speakerText;
    public TMP_Text dialogueText;

    [Header("Buttons")]
    public GameObject nextButton;
    public GameObject choiceAButton;
    public GameObject choiceBButton;

    private int currentLine = 0;
    private bool waitingForChoice = false;
    private bool choiceFinished = false;

    private string[] speakers =
    {
        "MC",
        "MC",
        "MC",
        "MC",
        "MC",
        "MC",
        "MC"
    };

    private string[] dialogue =
    {
        "My life isn't particularly exciting.",

        "I have a simple routine, a simple home... and Maya.",

        "Maya is my girlfriend. She's sweet, playful, and somehow makes even an ordinary day feel worth remembering.",

        "She also has one strangely sensitive spot: her bellybutton. Even the slightest touch can make her jump.",

        "I always thought it was just another little thing that made Maya... Maya.",

        "What I didn't know was that other people had started paying attention to it too.",

        "And before long, the choices I made would determine whether Maya and I stayed together... or whether someone else became more important to her."
    };

    private void Start()
    {
        currentLine = 0;
        waitingForChoice = false;
        choiceFinished = false;

        HideChoices();
        ShowNextButton();
        ShowCurrentLine();
    }

    public void NextLine()
    {
        if (waitingForChoice)
        {
            return;
        }

        if (choiceFinished)
        {
            FinishOpening();
            return;
        }

        currentLine++;

        if (currentLine >= dialogue.Length)
        {
            ShowFirstChoice();
            return;
        }

        ShowCurrentLine();
    }

    private void ShowCurrentLine()
    {
        if (speakerText != null)
        {
            speakerText.text = speakers[currentLine];
        }

        if (dialogueText != null)
        {
            dialogueText.text = dialogue[currentLine];
        }
    }

    private void ShowFirstChoice()
    {
        waitingForChoice = true;

        if (speakerText != null)
        {
            speakerText.text = "MAYA";
        }

        if (dialogueText != null)
        {
            dialogueText.text =
                "You really think we'll always be okay... right?";
        }

        HideNextButton();
        ShowChoices();
    }

    public void ChoiceA()
    {
        Debug.Log("OPENING CHOICE A selected.");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeAffection(5f);
            GameManager.Instance.ChangeTrust(3f);
            GameManager.Instance.ChangeLoyalty(2f);
        }

        FinishChoice(
            "MAYA",
            "You always know how to make me feel better."
        );
    }

    public void ChoiceB()
    {
        Debug.Log("OPENING CHOICE B selected.");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeAffection(-2f);
            GameManager.Instance.ChangeTrust(-2f);
            GameManager.Instance.ChangeLoyalty(-1f);
        }

        FinishChoice(
            "MAYA",
            "Oh... okay. I thought you'd understand."
        );
    }

    private void FinishChoice(string speaker, string response)
    {
        waitingForChoice = false;
        choiceFinished = true;

        HideChoices();
        ShowNextButton();

        if (speakerText != null)
        {
            speakerText.text = speaker;
        }

        if (dialogueText != null)
        {
            dialogueText.text = response;
        }
    }

    private void HideChoices()
    {
        if (choiceAButton != null)
        {
            choiceAButton.SetActive(false);
        }

        if (choiceBButton != null)
        {
            choiceBButton.SetActive(false);
        }
    }

    private void ShowChoices()
    {
        if (choiceAButton != null)
        {
            choiceAButton.SetActive(true);
        }

        if (choiceBButton != null)
        {
            choiceBButton.SetActive(true);
        }
    }

    private void HideNextButton()
    {
        if (nextButton != null)
        {
            nextButton.SetActive(false);
        }
    }

    private void ShowNextButton()
    {
        if (nextButton != null)
        {
            nextButton.SetActive(true);
        }
    }

    private void FinishOpening()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.State.openingCompleted = true;
            GameManager.Instance.State.currentStoryNode = "Party_Start";
        }

        Debug.Log("Opening completed.");
    }
}