using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartyStory : MonoBehaviour
{
    // ========================================================
    // UI
    // ========================================================

    [Header("Party UI")]
    public TMP_Text speakerText;
    public TMP_Text dialogueText;

    [Header("Story Artwork")]
    public Image storyImage;

    public Sprite partyOpeningImage;
    public Sprite julianIntroductionImage;

    // ========================================================
    // JULIAN ARTWORK
    // ========================================================

    [Header("Julian Hypnosis Artwork")]
    public Sprite julianPhoneImage;
    public Sprite julianSleepyImage;
    public Sprite julianDeepHypnosisImage;
    public Sprite julianMeanwhileImage;
    public Sprite julianCloseupImage;

    [Header("Julian Intervention Artwork")]
    public Sprite julianInterventionImage;

    // ========================================================
    // MARCUS ARTWORK
    // ========================================================

    [Header("Marcus Party Artwork")]
    public Sprite marcusImage1;
    public Sprite marcusImage2;
    public Sprite marcusImage3;
    public Sprite marcusImage4;
    public Sprite marcusImage5;
    public Sprite marcusImage6;
    public Sprite marcusImage7;
    public Sprite marcusImage8;
    public Sprite marcusImage9;

    [Header("Marcus Intervention Artwork")]
    public Sprite marcusInterventionImage;

    // ========================================================
    // ADRIAN ARTWORK
    // ========================================================

    [Header("Adrian Party Artwork")]
    public Sprite adrianImage1;
    public Sprite adrianImage2;
    public Sprite adrianImage3;
    public Sprite adrianImage4;
    public Sprite adrianImage5;
    public Sprite adrianImage6;
    public Sprite adrianImage7;
    public Sprite adrianImage8;
    public Sprite adrianImage9;
    public Sprite adrianImage10;
    public Sprite adrianImage11;
    public Sprite adrianImage12;
    public Sprite adrianImage13;
    public Sprite adrianImage14;

    [Header("Adrian Route Outcomes")]
    public Sprite adrianNoInterveneImage;
    public Sprite adrianMorningAfterImage;
    public Sprite adrianStepInImage;

    // ========================================================
    // BUTTONS
    // ========================================================

    [Header("Buttons")]
    public GameObject nextButton;
    public GameObject choiceAButton;
    public GameObject choiceBButton;

    // ========================================================
    // STORY STATE
    // ========================================================

    private int currentLine = 0;
    private int storySection = 0;
    private int choiceStage = 0;

    private bool waitingForChoice = false;
    private bool choiceFinished = false;
    private bool routeWrapUpShown = false;

    private bool julianHypnosisAccepted = false;
    private bool julianMomentFinished = false;
    private bool julianInterventionShown = false;
    private bool julianIntervened = false;

    private bool partySequenceFinished = false;

    private bool marcusSelected = false;
    private bool marcusEventFinished = false;
    private bool marcusInterventionShown = false;
    private bool marcusIntervened = false;

    private bool adrianSelected = false;
    private bool adrianEventFinished = false;
    private bool adrianInterventionShown = false;
    private bool adrianIntervened = false;

    // ========================================================
    // OPENING PARTY DIALOGUE
    // ========================================================

    private string[] openingSpeakers =
    {
        "MC",
        "MAYA",
        "MC",
        "MAYA",
        "MC"
    };

    private string[] openingDialogue =
    {
        "A few days later, Maya and I decided to throw a party at our place.",

        "This is going to be fun. We haven't had everyone together in forever.",

        "Maya seemed excited. I was just hoping nothing got broken before the night was over.",

        "Come on. Relax a little. It's just our friends.",

        "At the time, I had no idea how important this night would become."
    };

    // ========================================================
    // ROUTE INTRODUCTION
    // ========================================================

    private string[] routeSpeakers =
    {
        "MC",
        "MC",
        "MAYA",
        "MC",
        "MC",
        "MAYA"
    };

    private string[] routeDialogue =
    {
        "The apartment filled up quickly. Music, drinks, conversations... suddenly everyone seemed to be everywhere at once.",

        "Marcus was already making himself comfortable near the living room, talking like he'd been there a hundred times before.",

        "Adrian made it too. I didn't know him as well, but Maya seemed happy to see him.",

        "Daniel and Ethan were somewhere deeper in the crowd, and I caught a glimpse of Julian arriving a little later.",

        "For what was supposed to be a simple party, Maya suddenly had a lot of people competing for her attention.",

        "Hey... who should we go talk to first?"
    };

    // ========================================================
    // MARCUS FIRST PARTY EVENT
    // ========================================================

    private string[] marcusSpeakers =
    {
        "MC",
        "MARCUS",
        "MAYA",
        "NARRATOR",

        "MARCUS",
        "MAYA",
        "NARRATOR",

        "MARCUS",
        "MAYA",
        "MARCUS",
        "MAYA",

        "MAYA",
        "NARRATOR",

        "MAYA",
        "MARCUS",
        "NARRATOR",

        "NARRATOR",
        "MAYA",
        "NARRATOR",
        "MARCUS",

        "MAYA",
        "MARCUS",
        "NARRATOR",
        "MAYA",
        "NARRATOR",

        "MAYA",
        "MARCUS",
        "MAYA",
        "NARRATOR",
        "MARCUS",

        "MARCUS",
        "MAYA",
        "MARCUS",
        "MAYA",
        "MARCUS",
        "MAYA",
        "NARRATOR"
    };

    private string[] marcusDialogue =
    {
        "Hey, Maya, check it out... that's Marcus.",

        "There you two are. I was wondering when you'd finally come over.",

        "H-hey, Marcus.",

        "Maya looked away almost immediately. The color in her cheeks appeared the moment Marcus gave her his full attention.",

        "We're starting beer pong. You're on my team, Maya. Think you can keep up?",

        "Oh please... you better hope you can keep up with me.",

        "She answered confidently, but the blush on her face told a slightly different story.",

        "Let's make it interesting. Miss a shot, and you show me that belly of yours.",

        "W-what? No way...",

        "Come on, Maya. It'll be fun. Unless you're afraid you'll miss?",

        "Ugh... fine. If I miss, I'll show you.",

        "Watch this.",

        "Maya leaned across the table and released the ping-pong ball, both of them watching as it sailed toward the cups.",

        "YES! I made it!",

        "There we go!",

        "Caught up in the celebration, Maya threw both arms into the air. Marcus stepped in behind her and wrapped both hands around her waist.",

        "The excitement lasted only a moment before Maya suddenly became aware that Marcus was still holding her.",

        "...Marcus...",

        "Her cheeks burned bright red. She lowered both hands onto his, but for a moment she didn't actually move them away.",

        "What? You made the shot.",

        "I know...",

        "Looks like we both win.",

        "Maya looked up into Marcus's eyes. The noise of the party seemed to disappear around her as she found herself leaning closer without even realizing it.",

        "...I—",

        "For one dangerous second, Maya looked ready to close the remaining distance. Then the thought of MC snapped back into her mind.",

        "Okay... okay. Hands off.",

        "Alright. I'm letting go.",

        "Ah—!",

        "As Marcus moved his hands away, one of his fingers happened to graze past Maya's bellybutton. Her reaction was immediate.",

        "Whoa. What was that?",

        "Wait... you're really that sensitive there?",

        "I'm not that sensitive.",

        "Maya, you practically jumped.",

        "Shut up... I just wasn't expecting it.",

        "Uh-huh. I'll remember that.",

        "Marcus...",

        "Maya quickly pulled her shirt down and looked away, cheeks still burning. Marcus didn't push any further, but the look on his face made one thing obvious: he had learned something about Maya that he wasn't going to forget."
    };

    // ========================================================
    // ADRIAN FIRST PARTY EVENT
    // One dialogue beat per artwork slide.
    // ========================================================

    private string[] adrianSpeakers =
    {
        "MC",        // Slide 1
        "MAYA",      // Slide 2
        "ADRIAN",    // Slide 3
        "MAYA",      // Slide 4
        "NARRATOR",  // Slide 5
        "MAYA",      // Slide 6
        "NARRATOR",  // Slide 7
        "MAYA",      // Slide 8
        "NARRATOR",  // Slide 9
        "MAYA",      // Slide 10
        "NARRATOR",  // Slide 11
        "NARRATOR",  // Slide 12
        "NARRATOR",  // Slide 13
        "NARRATOR"   // Slide 14
    };

    private string[] adrianDialogue =
    {
        "Adrian had taken over the beer pong table. Every time someone challenged him, the result seemed to be exactly the same.",

        "You're getting way too smug about this. Play me.",

        "You want a game? Fine. One condition. Every time I make a shot, you drink... and I get to see that famous sensitive bellybutton I've heard about.",

        "Maya pulled her shirt back into place and gave Adrian a stubborn glare. Fine. Deal. But don't get comfortable. You're not winning.",

        "Adrian's first shot dropped cleanly into Maya's cups. The confident look on her face disappeared immediately.",

        "One shot doesn't mean anything. Maya took her drink and reluctantly followed through with the other half of their wager.",

        "Then Adrian made another. Maya's cheeks were becoming warmer now, and the competition suddenly wasn't looking quite as easy as she'd expected.",

        "Again? Ugh... fine. But I'm still beating you.",

        "Another ball disappeared into Maya's cups. This time she stared at it with a tipsy, almost disbelieving smile.",

        "How are you still making these...? Maya laughed as she took another drink, noticeably less concerned about the wager than she had been at the beginning.",

        "The final shot landed. Adrian had won decisively, while Maya was now visibly drunk and leaning against the table for support.",

        "When Maya tried to walk away from the table, Adrian caught up behind her and steadied her by the waist.",

        "Away from the crowd, Maya sank back onto the bed while Adrian began organizing the professional piercing supplies he'd brought with him.",

        "Adrian finished preparing everything. Maya lay back while he got ready to begin."
    };

    // ========================================================
    // ADRIAN NO-INTERVENTION OUTCOME
    // ========================================================

    private string[] adrianOutcomeSpeakers =
    {
        "NARRATOR",
        "MAYA"
    };

    private string[] adrianOutcomeDialogue =
    {
        "With no interruption, the rest of the moment happened out of the MC's sight. Only the player knows what happened between Adrian and Maya.",

        "The next morning, Maya slowly woke up... and froze when she discovered the new A-shaped jewelry at her bellybutton."
    };

    // ========================================================
    // JULIAN INTRODUCTION
    // ========================================================

    private string[] julianSpeakers =
    {
        "MC",
        "MC",
        "JULIAN",
        "MAYA",
        "JULIAN",
        "MAYA"
    };

    private string[] julianDialogue =
    {
        "A little later, I noticed Julian standing near the quieter side of the apartment.",

        "I used to work with him. He was always a little unusual, but I'd never had a reason not to trust him.",

        "Maya, right? I've heard a lot about you. I've always had an interest in the human mind.",

        "The human mind? What does that mean?",

        "Hypnosis, suggestion, little tricks with attention. Nothing dramatic. It's mostly just psychology.",

        "Hypnosis? Seriously?"
    };

    // ========================================================
    // JULIAN FIRST HYPNOSIS EVENT
    // ========================================================

    private string[] hypnosisSpeakers =
    {
        "MC",
        "JULIAN",
        "MC",
        "MC",
        "NARRATOR",
        "JULIAN",
        "MAYA",
        "JULIAN",
        "MAYA",
        "JULIAN",
        "MAYA",
        "NARRATOR",
        "JULIAN",
        "JULIAN",
        "MAYA",
        "JULIAN",
        "NARRATOR",
        "NARRATOR"
    };

    private string[] hypnosisDialogue =
    {
        "Maya kept watching the spiral for a few seconds. I couldn't help but laugh a little.",

        "Just keep your eyes on the center. Don't think about it too much.",

        "Yeah, I don't think that's actually going to work on her.",

        "Someone called my name from the other room. Figuring Julian's little demonstration was harmless, I went to see what they needed.",

        "Meanwhile...",

        "Maya? Can you still hear me?",

        "...Yeah.",

        "Good. Just keep focusing on the screen. You feel relaxed, don't you?",

        "Mhm... really relaxed.",

        "Then let's try something simple. Lift your sweater just enough to show me your bellybutton.",

        "...Okay.",

        "Still focused on the spiral, Maya slowly complied with the suggestion.",

        "Interesting... so that's the sensitive spot I've heard about.",

        "Your bellybutton is far more sensitive than I expected. It needs to be conditioned. Little by little, until it responds exactly the way I want. And soon... it'll be under my control.",

        "Yes... need my... bellybutton conditioned...",

        "Good. You're going to get used to hearing that.",

        "Maya continued staring blankly ahead, the suggestion settling deeper while the party carried on around them.",

        "For the first time that night, something had happened between Julian and Maya that the MC knew absolutely nothing about."
    };

    // ========================================================
    // START
    // ========================================================

    private void Start()
    {
        currentLine = 0;
        storySection = 0;
        choiceStage = 0;

        waitingForChoice = false;
        choiceFinished = false;
        routeWrapUpShown = false;

        julianHypnosisAccepted = false;
        julianMomentFinished = false;
        julianInterventionShown = false;
        julianIntervened = false;

        partySequenceFinished = false;

        marcusSelected = false;
        marcusEventFinished = false;
        marcusInterventionShown = false;
        marcusIntervened = false;

        adrianSelected = false;
        adrianEventFinished = false;
        adrianInterventionShown = false;
        adrianIntervened = false;

        SetStoryImage(partyOpeningImage);

        HideChoices();
        ShowNextButton();
        ShowCurrentLine();
    }

    // ========================================================
    // NEXT
    // ========================================================

    public void NextLine()
    {
        if (waitingForChoice || partySequenceFinished)
            return;

        // ----------------------------------------------------
        // RESPONSES AFTER CHOICES
        // ----------------------------------------------------

        if (choiceFinished)
        {
            choiceFinished = false;

            if (choiceStage == 1)
            {
                StartRouteIntroduction();
                return;
            }

            if (choiceStage == 2)
            {
                if (marcusSelected)
                    StartMarcusPartyScene();
                else if (adrianSelected)
                    StartAdrianPartyScene();
                else
                    FinishRouteChoice();

                return;
            }

            if (choiceStage == 3)
            {
                StartJulianIntroduction();
                return;
            }

            if (choiceStage == 4)
            {
                FinishJulianPartyMoment();
                return;
            }

            if (choiceStage == 5)
            {
                if (marcusIntervened)
                    FinishMarcusIntervention();
                else
                    ContinueMarcusAfterInterventionChoice();

                return;
            }

            if (choiceStage == 6)
            {
                if (julianIntervened)
                    FinishJulianIntervention();
                else
                    ContinueJulianAfterInterventionChoice();

                return;
            }

            // Adrian intervention
            if (choiceStage == 7)
            {
                if (adrianIntervened)
                    FinishAdrianIntervention();
                else
                    StartAdrianNoInterventionOutcome();

                return;
            }
        }

        // ----------------------------------------------------
        // MARCUS EVENT FINISHED
        // ----------------------------------------------------

        if (marcusEventFinished)
        {
            marcusEventFinished = false;
            FinishRouteChoice();
            return;
        }

        // ----------------------------------------------------
        // ADRIAN INTERVENTION EVENT FINISHED
        // ----------------------------------------------------

        if (adrianEventFinished)
        {
            adrianEventFinished = false;
            FinishRouteChoice();
            return;
        }

        // ----------------------------------------------------
        // ROUTE WRAP-UP
        // ----------------------------------------------------

        if (routeWrapUpShown)
        {
            routeWrapUpShown = false;
            ShowJulianApproachChoice();
            return;
        }

        // ----------------------------------------------------
        // JULIAN MOMENT
        // ----------------------------------------------------

        if (julianMomentFinished)
        {
            julianMomentFinished = false;

            if (julianHypnosisAccepted)
                StartHypnosisScene();
            else
                FinishPartyWithoutHypnosis();

            return;
        }

        // ----------------------------------------------------
        // MARCUS INTERVENTION POINT
        // ----------------------------------------------------

        if (storySection == 4 &&
            currentLine == 19 &&
            !marcusInterventionShown)
        {
            ShowMarcusInterventionChoice();
            return;
        }

        // ----------------------------------------------------
        // JULIAN INTERVENTION POINT
        // ----------------------------------------------------

        if (storySection == 3 &&
            currentLine == 2 &&
            !julianInterventionShown)
        {
            ShowJulianInterventionChoice();
            return;
        }

        // ----------------------------------------------------
        // ADRIAN INTERVENTION POINT
        // Slide 14 is currently visible.
        // ----------------------------------------------------

        if (storySection == 5 &&
            currentLine == 13 &&
            !adrianInterventionShown)
        {
            ShowAdrianInterventionChoice();
            return;
        }

        // ----------------------------------------------------
        // NORMAL ADVANCE
        // ----------------------------------------------------

        currentLine++;

        if (storySection == 0)
        {
            if (currentLine >= openingDialogue.Length)
            {
                ShowFirstChoice();
                return;
            }
        }
        else if (storySection == 1)
        {
            if (currentLine >= routeDialogue.Length)
            {
                ShowRouteChoice();
                return;
            }
        }
        else if (storySection == 2)
        {
            if (currentLine >= julianDialogue.Length)
            {
                ShowJulianHypnosisChoice();
                return;
            }
        }
        else if (storySection == 3)
        {
            if (currentLine >= hypnosisDialogue.Length)
            {
                FinishHypnosisScene();
                return;
            }
        }
        else if (storySection == 4)
        {
            if (currentLine >= marcusDialogue.Length)
            {
                FinishMarcusFirstPartyEvent();
                return;
            }
        }
        else if (storySection == 5)
        {
            if (currentLine >= adrianDialogue.Length)
            {
                ShowAdrianInterventionChoice();
                return;
            }
        }
        else if (storySection == 6)
        {
            if (currentLine >= adrianOutcomeDialogue.Length)
            {
                FinishAdrianNoInterventionRoute();
                return;
            }
        }

        ShowCurrentLine();
    }

    // ========================================================
    // DISPLAY CURRENT LINE
    // ========================================================

    private void ShowCurrentLine()
    {
        if (storySection == 0)
        {
            speakerText.text = openingSpeakers[currentLine];
            dialogueText.text = openingDialogue[currentLine];
        }
        else if (storySection == 1)
        {
            speakerText.text = routeSpeakers[currentLine];
            dialogueText.text = routeDialogue[currentLine];
        }
        else if (storySection == 2)
        {
            speakerText.text = julianSpeakers[currentLine];
            dialogueText.text = julianDialogue[currentLine];
        }
        else if (storySection == 3)
        {
            ApplyHypnosisArtwork();

            speakerText.text = hypnosisSpeakers[currentLine];
            dialogueText.text = hypnosisDialogue[currentLine];
        }
        else if (storySection == 4)
        {
            ApplyMarcusArtwork();

            speakerText.text = marcusSpeakers[currentLine];
            dialogueText.text = marcusDialogue[currentLine];
        }
        else if (storySection == 5)
        {
            ApplyAdrianArtwork();

            speakerText.text = adrianSpeakers[currentLine];
            dialogueText.text = adrianDialogue[currentLine];
        }
        else if (storySection == 6)
        {
            ApplyAdrianOutcomeArtwork();

            speakerText.text = adrianOutcomeSpeakers[currentLine];
            dialogueText.text = adrianOutcomeDialogue[currentLine];
        }
    }

    // ========================================================
    // MARCUS ARTWORK
    // ========================================================

    private void ApplyMarcusArtwork()
    {
        if (currentLine <= 3)
            SetStoryImage(marcusImage1);
        else if (currentLine <= 6)
            SetStoryImage(marcusImage2);
        else if (currentLine <= 10)
            SetStoryImage(marcusImage3);
        else if (currentLine <= 12)
            SetStoryImage(marcusImage4);
        else if (currentLine <= 15)
            SetStoryImage(marcusImage5);
        else if (currentLine <= 19)
            SetStoryImage(marcusImage6);
        else if (currentLine <= 24)
            SetStoryImage(marcusImage7);
        else if (currentLine <= 29)
            SetStoryImage(marcusImage8);
        else
            SetStoryImage(marcusImage9);
    }

    // ========================================================
    // ADRIAN ARTWORK
    // ========================================================

    private void ApplyAdrianArtwork()
    {
        switch (currentLine)
        {
            case 0:
                SetStoryImage(adrianImage1);
                break;

            case 1:
                SetStoryImage(adrianImage2);
                break;

            case 2:
                SetStoryImage(adrianImage3);
                break;

            case 3:
                SetStoryImage(adrianImage4);
                break;

            case 4:
                SetStoryImage(adrianImage5);
                break;

            case 5:
                SetStoryImage(adrianImage6);
                break;

            case 6:
                SetStoryImage(adrianImage7);
                break;

            case 7:
                SetStoryImage(adrianImage8);
                break;

            case 8:
                SetStoryImage(adrianImage9);
                break;

            case 9:
                SetStoryImage(adrianImage10);
                break;

            case 10:
                SetStoryImage(adrianImage11);
                break;

            case 11:
                SetStoryImage(adrianImage12);
                break;

            case 12:
                SetStoryImage(adrianImage13);
                break;

            default:
                SetStoryImage(adrianImage14);
                break;
        }
    }

    private void ApplyAdrianOutcomeArtwork()
    {
        if (currentLine == 0)
            SetStoryImage(adrianNoInterveneImage);
        else
            SetStoryImage(adrianMorningAfterImage);
    }

    // ========================================================
    // JULIAN ARTWORK
    // ========================================================

    private void ApplyHypnosisArtwork()
    {
        if (currentLine == 0)
            SetStoryImage(julianPhoneImage);
        else if (currentLine <= 2)
            SetStoryImage(julianSleepyImage);
        else if (currentLine <= 8)
            SetStoryImage(julianDeepHypnosisImage);
        else if (currentLine <= 11)
            SetStoryImage(julianMeanwhileImage);
        else
            SetStoryImage(julianCloseupImage);
    }

    // ========================================================
    // FIRST PARTY CHOICE
    // ========================================================

    private void ShowFirstChoice()
    {
        waitingForChoice = true;
        choiceStage = 1;

        speakerText.text = "MAYA";
        dialogueText.text =
            "Everyone's starting to arrive. Are you staying with me, or are you going to go mingle?";

        SetChoiceText(
            "STAY WITH MAYA",
            "GO MINGLE"
        );

        HideNextButton();
        ShowChoices();
    }

    // ========================================================
    // ROUTE INTRODUCTION
    // ========================================================

    private void StartRouteIntroduction()
    {
        storySection = 1;
        currentLine = 0;

        ShowNextButton();
        HideChoices();
        ShowCurrentLine();
    }

    // ========================================================
    // MARCUS / ADRIAN CHOICE
    // ========================================================

    private void ShowRouteChoice()
    {
        waitingForChoice = true;
        choiceStage = 2;

        speakerText.text = "MAYA";
        dialogueText.text =
            "Marcus and Adrian are both right over there. Who do you want to talk to first?";

        SetChoiceText(
            "TALK TO MARCUS",
            "TALK TO ADRIAN"
        );

        HideNextButton();
        ShowChoices();
    }

    // ========================================================
    // START MARCUS
    // ========================================================

    private void StartMarcusPartyScene()
    {
        storySection = 4;
        currentLine = 0;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.State.currentStoryNode =
                "Party_Marcus_First_Attraction_Event";
        }

        SetStoryImage(marcusImage1);

        HideChoices();
        ShowNextButton();
        ShowCurrentLine();
    }

    // ========================================================
    // START ADRIAN
    // ========================================================

    private void StartAdrianPartyScene()
    {
        storySection = 5;
        currentLine = 0;

        adrianInterventionShown = false;
        adrianIntervened = false;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.State.currentStoryNode =
                "Party_Adrian_BeerPong";
        }

        SetStoryImage(adrianImage1);

        HideChoices();
        ShowNextButton();
        ShowCurrentLine();

        Debug.Log(
            "Adrian beer pong route started."
        );
    }

    // ========================================================
    // ADRIAN INTERVENTION
    // ========================================================

    private void ShowAdrianInterventionChoice()
    {
        adrianInterventionShown = true;
        waitingForChoice = true;
        choiceStage = 7;

        speakerText.text = "MC";
        dialogueText.text =
            "I found Maya in the bedroom with Adrian preparing his piercing supplies. I could walk in now... or leave them alone.";

        SetChoiceText(
            "STEP IN",
            "DON'T INTERVENE"
        );

        HideNextButton();
        ShowChoices();
    }

    private void FinishAdrianIntervention()
    {
        waitingForChoice = false;
        adrianEventFinished = true;

        SetStoryImage(adrianStepInImage);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeAffection(2f);
            GameManager.Instance.ChangeLoyalty(1f);
            GameManager.Instance.ChangeCorruption(-1f);

            // MC personally witnessed enough to know
            // Adrian had been preparing a piercing.
            GameManager.Instance.AddMCKnowledge(1);
            GameManager.Instance.AddPlayerKnowledge(1);

            GameManager.Instance.State.currentStoryNode =
                "Party_Adrian_Interrupted";
        }

        speakerText.text = "MC";
        dialogueText.text =
            "Hey—what's going on in here?";

        HideChoices();
        ShowNextButton();

        Debug.Log(
            "Adrian event interrupted. " +
            "Piercing prevented | Affection +2 | " +
            "Loyalty +1 | Corruption -1 | MC Knowledge +1"
        );
    }

    // ========================================================
    // ADRIAN NO-INTERVENTION ROUTE
    // ========================================================

    private void StartAdrianNoInterventionOutcome()
    {
        waitingForChoice = false;

        storySection = 6;
        currentLine = 0;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeAttraction(
                CharacterID.Adrian,
                5f
            );

            GameManager.Instance.ChangeRouteProgress(
                CharacterID.Adrian,
                5f
            );

            GameManager.Instance.ChangeNavelFamiliarity(
                CharacterID.Adrian,
                8f
            );

            GameManager.Instance.ChangeCorruption(3f);

            GameManager.Instance.SetNavelJewelry(
                NavelJewelry.AdrianInitialA
            );

            GameManager.Instance.ChangeSecrecy(8f);

            // Player sees the hidden event.
            // MC does NOT receive knowledge.
            GameManager.Instance.AddPlayerKnowledge(1);

            GameManager.Instance.State.currentStoryNode =
                "Party_Adrian_Hidden_Piercing";
        }

        SetStoryImage(adrianNoInterveneImage);

        HideChoices();
        ShowNextButton();
        ShowCurrentLine();

        Debug.Log(
            "Adrian hidden route continued. " +
            "Adrian Attraction +5 | Route Progress +5 | " +
            "Navel Familiarity +8 | Corruption +3 | " +
            "Secrecy +8 | Player Knowledge +1 | " +
            "MC Knowledge unchanged"
        );
    }

    private void FinishAdrianNoInterventionRoute()
    {
        partySequenceFinished = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.State.currentStoryNode =
                "Adrian_Morning_After_A_Ring";
        }

        speakerText.text = "NARRATOR";
        dialogueText.text =
            "ADRIAN ROUTE: Maya now has a secret connected to Adrian that the MC knows nothing about.";

        HideChoices();
        HideNextButton();

        Debug.Log(
            "Adrian first party route complete. " +
            "Morning After reached."
        );
    }

    // ========================================================
    // MARCUS INTERVENTION CHOICE
    // ========================================================

    private void ShowMarcusInterventionChoice()
    {
        marcusInterventionShown = true;
        waitingForChoice = true;
        choiceStage = 5;

        speakerText.text = "MC";
        dialogueText.text =
            "Marcus was still holding Maya around the waist. For a second, she didn't seem to be pulling away.";

        SetChoiceText(
            "STEP IN",
            "LET IT PLAY OUT"
        );

        HideNextButton();
        ShowChoices();
    }

    private void ContinueMarcusAfterInterventionChoice()
    {
        waitingForChoice = false;

        currentLine = 20;

        SetStoryImage(marcusImage7);

        HideChoices();
        ShowNextButton();
        ShowCurrentLine();

        Debug.Log(
            "MC chose not to intervene. Marcus route continues."
        );
    }

    private void FinishMarcusIntervention()
    {
        waitingForChoice = false;
        marcusEventFinished = true;

        SetStoryImage(marcusInterventionImage);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeAffection(2f);
            GameManager.Instance.ChangeLoyalty(1f);

            GameManager.Instance.ChangeAttraction(
                CharacterID.Marcus,
                1f
            );

            GameManager.Instance.State.currentStoryNode =
                "Party_Marcus_Interrupted";
        }

        speakerText.text = "MC";
        dialogueText.text =
            "Hey, Maya. Come help me with something for a second.";

        HideChoices();
        ShowNextButton();

        Debug.Log(
            "MC interrupted Marcus. " +
            "Affection +2 | Loyalty +1 | " +
            "Marcus Attraction +1 | No Corruption"
        );
    }

    // ========================================================
    // COMPLETE MARCUS EVENT
    // ========================================================

    private void FinishMarcusFirstPartyEvent()
    {
        marcusEventFinished = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeAttraction(
                CharacterID.Marcus,
                5f
            );

            GameManager.Instance.ChangeRouteProgress(
                CharacterID.Marcus,
                3f
            );

            GameManager.Instance.ChangeNavelFamiliarity(
                CharacterID.Marcus,
                5f
            );

            GameManager.Instance.ChangeCorruption(1f);

            GameManager.Instance.UnlockMarcusNavelInterest();

            GameManager.Instance.AddPlayerKnowledge(1);

            GameManager.Instance.State.currentStoryNode =
                "Party_Marcus_First_Attraction_Event_Complete";
        }

        speakerText.text = "NARRATOR";
        dialogueText.text =
            "MARCUS ROUTE: First attraction event complete.";

        Debug.Log(
            "Marcus first party event complete. " +
            "Marcus Attraction +5 | " +
            "Route Progress +3 | " +
            "Navel Familiarity +5 | " +
            "Corruption +1 | " +
            "Marcus Navel Interest Unlocked"
        );

        HideChoices();
        ShowNextButton();
    }

    // ========================================================
    // ROUTE WRAP-UP
    // ========================================================

    private void FinishRouteChoice()
    {
        HideChoices();
        ShowNextButton();

        routeWrapUpShown = true;

        speakerText.text = "MC";
        dialogueText.text =
            "I didn't think much of what happened that night. It was just a party... or so I thought.";

        Debug.Log(
            "Party route introduction complete."
        );
    }

    // ========================================================
    // JULIAN APPROACH
    // ========================================================

    private void ShowJulianApproachChoice()
    {
        waitingForChoice = true;
        choiceStage = 3;

        speakerText.text = "MC";
        dialogueText.text =
            "Later, I spotted Julian across the room. I hadn't talked to my old coworker in a while.";

        SetChoiceText(
            "GO TALK TO JULIAN",
            "STAY WITH MAYA"
        );

        HideNextButton();
        ShowChoices();
    }

    // ========================================================
    // START JULIAN
    // ========================================================

    private void StartJulianIntroduction()
    {
        storySection = 2;
        currentLine = 0;

        SetStoryImage(julianIntroductionImage);

        ShowNextButton();
        HideChoices();
        ShowCurrentLine();
    }

    // ========================================================
    // JULIAN HYPNOSIS CHOICE
    // ========================================================

    private void ShowJulianHypnosisChoice()
    {
        waitingForChoice = true;
        choiceStage = 4;

        speakerText.text = "JULIAN";
        dialogueText.text =
            "Want to see one of the tricks I've been practicing? It's harmless. You just have to focus on something on my phone.";

        SetChoiceText(
            "LET MAYA TRY IT",
            "CHANGE THE SUBJECT"
        );

        HideNextButton();
        ShowChoices();
    }

    // ========================================================
    // JULIAN INTERVENTION
    // ========================================================

    private void ShowJulianInterventionChoice()
    {
        julianInterventionShown = true;
        waitingForChoice = true;
        choiceStage = 6;

        speakerText.text = "MC";
        dialogueText.text =
            "Someone called my name from the other room. Maya was still staring at Julian's phone. I could stay here, or go see what they needed.";

        SetChoiceText(
            "STAY WITH MAYA",
            "GO HELP"
        );

        HideNextButton();
        ShowChoices();
    }

    private void ContinueJulianAfterInterventionChoice()
    {
        waitingForChoice = false;

        currentLine = 3;

        SetStoryImage(julianDeepHypnosisImage);

        HideChoices();
        ShowNextButton();
        ShowCurrentLine();

        Debug.Log(
            "MC left the room. Julian route continues."
        );
    }

    private void FinishJulianIntervention()
    {
        waitingForChoice = false;
        partySequenceFinished = true;

        SetStoryImage(julianInterventionImage);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeAffection(2f);
            GameManager.Instance.ChangeTrust(1f);

            GameManager.Instance.State.currentStoryNode =
                "Party_Julian_Interrupted";
        }

        speakerText.text = "MC";
        dialogueText.text =
            "Actually, I'll stay here. Whoever called me can wait.";

        HideChoices();
        HideNextButton();

        Debug.Log(
            "MC stayed with Maya. Julian private event prevented. " +
            "Affection +2 | Trust +1 | No Julian Conditioning"
        );
    }

    // ========================================================
    // CHOICE A
    // ========================================================

    public void ChoiceA()
    {
        if (!waitingForChoice)
            return;

        if (choiceStage == 1)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.ChangeAffection(3f);
                GameManager.Instance.ChangeTrust(2f);
                GameManager.Instance.ChangeLoyalty(2f);
            }

            FinishChoice(
                "MAYA",
                "Good. Stay with me for a little while."
            );
            return;
        }

        if (choiceStage == 2)
        {
            marcusSelected = true;
            adrianSelected = false;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.State.currentStoryNode =
                    "Party_Marcus_Introduction";
            }

            FinishChoice(
                "MAYA",
                "Okay... let's go see what Marcus is up to."
            );
            return;
        }

        if (choiceStage == 3)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.State.currentStoryNode =
                    "Party_Julian_Introduction";
            }

            FinishChoice(
                "MC",
                "Sure. Maya and I walked over to say hello."
            );
            return;
        }

        if (choiceStage == 4)
        {
            julianHypnosisAccepted = true;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.State.currentStoryNode =
                    "Party_Julian_Hypnosis_Begins";
            }

            FinishChoice(
                "MAYA",
                "Okay... sure. That sounds harmless enough."
            );
            return;
        }

        if (choiceStage == 5)
        {
            marcusIntervened = true;

            FinishChoice(
                "MC",
                "Maybe I should step in."
            );
            return;
        }

        if (choiceStage == 6)
        {
            julianIntervened = true;

            FinishChoice(
                "MC",
                "Actually... I'll stay here."
            );
            return;
        }

        // ADRIAN — STEP IN
        if (choiceStage == 7)
        {
            adrianIntervened = true;

            FinishChoice(
                "MC",
                "No. I'm going in."
            );
            return;
        }
    }

    // ========================================================
    // CHOICE B
    // ========================================================

    public void ChoiceB()
    {
        if (!waitingForChoice)
            return;

        if (choiceStage == 1)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.ChangeAffection(-1f);
                GameManager.Instance.ChangeTrust(-1f);
            }

            FinishChoice(
                "MAYA",
                "Okay. I'll find you later, then."
            );
            return;
        }

        if (choiceStage == 2)
        {
            marcusSelected = false;
            adrianSelected = true;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.State.currentStoryNode =
                    "Party_Adrian_Introduction";
            }

            FinishChoice(
                "MAYA",
                "Sure. Let's go talk to Adrian."
            );
            return;
        }

        if (choiceStage == 3)
        {
            FinishChoice(
                "MAYA",
                "We can catch up with him later. Stay with me."
            );
            return;
        }

        if (choiceStage == 4)
        {
            julianHypnosisAccepted = false;

            if (GameManager.Instance != null)
            {
                GameManager.Instance.State.currentStoryNode =
                    "Party_Julian_Hypnosis_Avoided";
            }

            FinishChoice(
                "MC",
                "Maybe another time. We should probably check on everyone."
            );
            return;
        }

        if (choiceStage == 5)
        {
            marcusIntervened = false;

            FinishChoice(
                "MC",
                "They're just celebrating. I don't need to interfere."
            );
            return;
        }

        if (choiceStage == 6)
        {
            julianIntervened = false;

            FinishChoice(
                "MC",
                "It's probably nothing. I'll go see who called me."
            );
            return;
        }

        // ADRIAN — DON'T INTERVENE
        if (choiceStage == 7)
        {
            adrianIntervened = false;

            FinishChoice(
                "MC",
                "I'll leave them alone."
            );
            return;
        }
    }

    // ========================================================
    // FINISH CHOICE
    // ========================================================

    private void FinishChoice(
        string speaker,
        string response)
    {
        waitingForChoice = false;
        choiceFinished = true;

        HideChoices();
        ShowNextButton();

        speakerText.text = speaker;
        dialogueText.text = response;
    }

    // ========================================================
    // JULIAN PHONE MOMENT
    // ========================================================

    private void FinishJulianPartyMoment()
    {
        HideChoices();
        ShowNextButton();

        julianMomentFinished = true;

        speakerText.text = "MC";

        if (julianHypnosisAccepted)
        {
            dialogueText.text =
                "Julian pulled out his phone. A slowly turning spiral filled the screen, and Maya stared at it with an amused little smile.";

            SetStoryImage(julianPhoneImage);
        }
        else
        {
            dialogueText.text =
                "The conversation moved on, and the party continued around us.";
        }
    }

    // ========================================================
    // START HYPNOSIS
    // ========================================================

    private void StartHypnosisScene()
    {
        storySection = 3;
        currentLine = 0;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.State.currentStoryNode =
                "Party_Julian_First_Corruption";
        }

        SetStoryImage(julianPhoneImage);

        ShowNextButton();
        HideChoices();
        ShowCurrentLine();
    }

    // ========================================================
    // COMPLETE JULIAN EVENT
    // ========================================================

    private void FinishHypnosisScene()
    {
        partySequenceFinished = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ChangeCorruption(2f);
            GameManager.Instance.ChangeJulianInfluence(4f);
            GameManager.Instance.ChangeJulianConditioning(3f);

            GameManager.Instance.ChangeRouteProgress(
                CharacterID.Julian,
                3f
            );

            GameManager.Instance.ChangeNavelFamiliarity(
                CharacterID.Julian,
                5f
            );

            GameManager.Instance.AddPlayerKnowledge(1);

            GameManager.Instance.State.knowledge
                .knowsJulianConnection = true;

            GameManager.Instance.State.currentStoryNode =
                "Party_Julian_First_Corruption_Complete";
        }

        speakerText.text = "NARRATOR";
        dialogueText.text =
            "JULIAN ROUTE: First corruption event complete.";

        Debug.Log(
            "Julian first corruption complete. " +
            "Corruption +2 | Influence +4 | Conditioning +3 | " +
            "Route Progress +3 | Navel Familiarity +5"
        );

        HideChoices();
        HideNextButton();
    }

    // ========================================================
    // JULIAN EVENT AVOIDED
    // ========================================================

    private void FinishPartyWithoutHypnosis()
    {
        partySequenceFinished = true;

        speakerText.text = "MC";
        dialogueText.text =
            "For now, Julian's strange little demonstration was forgotten as the party carried on.";

        Debug.Log(
            "Julian hypnosis opportunity avoided."
        );

        HideChoices();
        HideNextButton();
    }

    // ========================================================
    // ARTWORK
    // ========================================================

    private void SetStoryImage(Sprite newImage)
    {
        if (storyImage != null && newImage != null)
        {
            storyImage.sprite = newImage;
            storyImage.preserveAspect = true;
        }
    }

    // ========================================================
    // CHOICE TEXT
    // ========================================================

    private void SetChoiceText(
        string choiceA,
        string choiceB)
    {
        if (choiceAButton != null)
        {
            TMP_Text textA =
                choiceAButton.GetComponentInChildren<TMP_Text>();

            if (textA != null)
                textA.text = choiceA;
        }

        if (choiceBButton != null)
        {
            TMP_Text textB =
                choiceBButton.GetComponentInChildren<TMP_Text>();

            if (textB != null)
                textB.text = choiceB;
        }
    }

    // ========================================================
    // BUTTON VISIBILITY
    // ========================================================

    private void HideChoices()
    {
        if (choiceAButton != null)
            choiceAButton.SetActive(false);

        if (choiceBButton != null)
            choiceBButton.SetActive(false);
    }

    private void ShowChoices()
    {
        if (choiceAButton != null)
            choiceAButton.SetActive(true);

        if (choiceBButton != null)
            choiceBButton.SetActive(true);
    }

    private void HideNextButton()
    {
        if (nextButton != null)
            nextButton.SetActive(false);
    }

    private void ShowNextButton()
    {
        if (nextButton != null)
            nextButton.SetActive(true);
    }
}