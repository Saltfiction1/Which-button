using System;
using UnityEngine;

// ============================================================
// WHICH BUTTON
// GameState.cs
// Stores the core state of the current playthrough.
// ============================================================


// ============================================================
// CHARACTERS
// ============================================================

public enum CharacterID
{
    MC,
    Ethan,
    Adrian,
    Daniel,
    Marcus,
    Julian
}


// ============================================================
// ROUTES
// ============================================================

public enum RouteID
{
    None,
    Loyal,
    Ethan,
    Adrian,
    Daniel,
    Marcus,
    Julian
}


// ============================================================
// MAYA'S NAVEL JEWELRY
// None remains a valid state throughout the game.
// ============================================================

public enum NavelJewelry
{
    None,

    // Loyal / MC route
    MCHeart,

    // Ethan route
    EthanBlueTeardrop,

    // Adrian route
    AdrianInitialA,

    // Daniel route
    DanielStar,

    // Marcus route
    MarcusQueenOfSpades,

    // Julian route
    JulianPurpleAnchor
}


// ============================================================
// WHAT THE MC CURRENTLY KNOWS ABOUT A PIERCING
// Actual state and MC knowledge are deliberately separate.
// ============================================================

public enum PiercingKnowledge
{
    Unknown,
    Suspicious,
    Glimpsed,
    PiercingConfirmed,
    JewelryIdentified
}


// ============================================================
// RELATIONSHIP STATE
// Each character gets his own relationship values.
// ============================================================

[Serializable]
public class RelationshipState
{
    public CharacterID character;

    [Range(0f, 100f)]
    public float attraction = 0f;

    [Range(0f, 100f)]
    public float love = 0f;

    [Range(0f, 100f)]
    public float routeProgress = 0f;

    [Range(0f, 100f)]
    public float navelFamiliarity = 0f;

    [Range(0f, 100f)]
    public float arousalResponse = 0f;

    public bool routeUnlocked = false;
}


// ============================================================
// NAVEL STATE
// Tracks what is actually true separately from what the MC knows.
// ============================================================

[Serializable]
public class NavelState
{
    // --------------------------------------------------------
    // ACTUAL STATE
    // --------------------------------------------------------

    [Range(0f, 100f)]
    public float redness = 2f;

    public bool pierced = false;

    public NavelJewelry actualJewelry =
        NavelJewelry.None;


    // --------------------------------------------------------
    // MC KNOWLEDGE
    // --------------------------------------------------------

    public PiercingKnowledge mcKnowledge =
        PiercingKnowledge.Unknown;

    public NavelJewelry mcKnownJewelry =
        NavelJewelry.None;

    public int lastObservedDay = 1;


    // --------------------------------------------------------
    // CONCEALMENT / DISCOVERY
    // --------------------------------------------------------

    public bool mayaIsConcealingPiercing = false;

    [Range(0f, 100f)]
    public float concealmentSkill = 0f;

    public int observationOpportunities = 0;

    public int successfulObservations = 0;


    // --------------------------------------------------------
    // NAVEL FUNCTIONS
    // --------------------------------------------------------

    public void SetJewelry(NavelJewelry jewelry)
    {
        actualJewelry = jewelry;

        pierced =
            jewelry != NavelJewelry.None;
    }


    public void RemoveJewelry()
    {
        actualJewelry =
            NavelJewelry.None;

        pierced = false;
    }


    public void AddRedness(float amount)
    {
        redness = Mathf.Clamp(
            redness + amount,
            0f,
            100f
        );
    }


    public void ReduceRedness(float amount)
    {
        redness = Mathf.Clamp(
            redness - amount,
            0f,
            100f
        );
    }
}


// ============================================================
// MAYA
// Her central character state.
// ============================================================

[Serializable]
public class MayaState
{
    // ========================================================
    // RELATIONSHIP WITH MC
    // ========================================================

    [Range(0f, 100f)]
    public float affection = 72f;

    [Range(0f, 100f)]
    public float trust = 75f;

    [Range(0f, 100f)]
    public float loyalty = 85f;


    // ========================================================
    // PERSONALITY / HIDDEN STORY VALUES
    // Corruption and Loyalty are NOT opposites.
    // ========================================================

    [Range(0f, 100f)]
    public float corruption = 0f;

    [Range(0f, 100f)]
    public float secrecy = 5f;

    [Range(0f, 100f)]
    public float confidence = 30f;

    [Range(0f, 100f)]
    public float riskTaking = 10f;

    [Range(0f, 100f)]
    public float boundaries = 80f;


    // ========================================================
    // NAVEL STATE
    // ========================================================

    public NavelState navel =
        new NavelState();


    // ========================================================
    // ETHAN
    // Strongest natural starting attraction.
    // ========================================================

    public RelationshipState ethan =
        new RelationshipState
        {
            character = CharacterID.Ethan,
            attraction = 65f,
            love = 0f,
            routeProgress = 0f,
            navelFamiliarity = 0f,
            arousalResponse = 0f,
            routeUnlocked = false
        };


    // ========================================================
    // ADRIAN
    // Confidence / temptation route.
    // ========================================================

    public RelationshipState adrian =
        new RelationshipState
        {
            character = CharacterID.Adrian,
            attraction = 45f,
            love = 0f,
            routeProgress = 0f,
            navelFamiliarity = 0f,
            arousalResponse = 0f,
            routeUnlocked = false
        };


    // ========================================================
    // DANIEL
    // Playful / wildcard route.
    // ========================================================

    public RelationshipState daniel =
        new RelationshipState
        {
            character = CharacterID.Daniel,
            attraction = 35f,
            love = 0f,
            routeProgress = 0f,
            navelFamiliarity = 0f,
            arousalResponse = 0f,
            routeUnlocked = false
        };


    // ========================================================
    // MARCUS
    // Queen of Spades / Navel Claim route.
    // ========================================================

    public RelationshipState marcus =
        new RelationshipState
        {
            character = CharacterID.Marcus,
            attraction = 25f,
            love = 0f,
            routeProgress = 0f,
            navelFamiliarity = 0f,
            arousalResponse = 0f,
            routeUnlocked = false
        };


    // Marcus-specific progression.

    [Range(0f, 100f)]
    public float marcusClaim = 0f;

    public bool marcusNavelInterestUnlocked =
        false;

    public bool queenOfSpadesAccepted =
        false;

    public bool queenOfSpadesDiscovered =
        false;


    // ========================================================
    // JULIAN
    // Influence / conditioning route.
    //
    // Conditioning is deliberately kept separate from
    // voluntary attraction and attachment.
    // ========================================================

    public RelationshipState julian =
        new RelationshipState
        {
            character = CharacterID.Julian,
            attraction = 15f,
            love = 0f,
            routeProgress = 0f,
            navelFamiliarity = 0f,
            arousalResponse = 0f,
            routeUnlocked = false
        };


    [Range(0f, 100f)]
    public float julianInfluence = 0f;

    [Range(0f, 100f)]
    public float julianConditioning = 0f;

    [Range(0f, 100f)]
    public float julianRingAttachment = 0f;

    [Range(0f, 100f)]
    public float julianVoluntaryAttachment = 0f;

    [Range(0f, 100f)]
    public float mayaAwareness = 100f;


    // ========================================================
    // RELATIONSHIP LOOKUP
    // ========================================================

    public RelationshipState GetRelationship(
        CharacterID character)
    {
        switch (character)
        {
            case CharacterID.Ethan:
                return ethan;

            case CharacterID.Adrian:
                return adrian;

            case CharacterID.Daniel:
                return daniel;

            case CharacterID.Marcus:
                return marcus;

            case CharacterID.Julian:
                return julian;

            default:
                return null;
        }
    }


    // ========================================================
    // KEEP ALL STATS BETWEEN 0 AND 100
    // ========================================================

    public void ClampAllStats()
    {
        affection =
            ClampStat(affection);

        trust =
            ClampStat(trust);

        loyalty =
            ClampStat(loyalty);

        corruption =
            ClampStat(corruption);

        secrecy =
            ClampStat(secrecy);

        confidence =
            ClampStat(confidence);

        riskTaking =
            ClampStat(riskTaking);

        boundaries =
            ClampStat(boundaries);


        // Marcus

        marcusClaim =
            ClampStat(marcusClaim);


        // Julian

        julianInfluence =
            ClampStat(julianInfluence);

        julianConditioning =
            ClampStat(julianConditioning);

        julianRingAttachment =
            ClampStat(julianRingAttachment);

        julianVoluntaryAttachment =
            ClampStat(julianVoluntaryAttachment);

        mayaAwareness =
            ClampStat(mayaAwareness);


        // Relationships

        ClampRelationship(ethan);
        ClampRelationship(adrian);
        ClampRelationship(daniel);
        ClampRelationship(marcus);
        ClampRelationship(julian);


        // Navel

        navel.redness =
            ClampStat(navel.redness);

        navel.concealmentSkill =
            ClampStat(
                navel.concealmentSkill
            );
    }


    private void ClampRelationship(
        RelationshipState relationship)
    {
        if (relationship == null)
            return;

        relationship.attraction =
            ClampStat(
                relationship.attraction
            );

        relationship.love =
            ClampStat(
                relationship.love
            );

        relationship.routeProgress =
            ClampStat(
                relationship.routeProgress
            );

        relationship.navelFamiliarity =
            ClampStat(
                relationship.navelFamiliarity
            );

        relationship.arousalResponse =
            ClampStat(
                relationship.arousalResponse
            );
    }


    private float ClampStat(float value)
    {
        return Mathf.Clamp(
            value,
            0f,
            100f
        );
    }
}


// ============================================================
// PLAYER KNOWLEDGE VS MC KNOWLEDGE
//
// The player can witness "Meanwhile..." scenes that the
// protagonist has not personally discovered.
// ============================================================

[Serializable]
public class KnowledgeState
{
    public int playerKnowledge = 0;

    public int mcKnowledge = 0;


    // Route clues

    public bool knowsEthanConnection =
        false;

    public bool knowsAdrianConnection =
        false;

    public bool knowsDanielConnection =
        false;

    public bool knowsMarcusInterest =
        false;

    public bool knowsJulianConnection =
        false;
}


// ============================================================
// TUTORIAL STATE
// Prevents tutorials from constantly repeating.
// ============================================================

[Serializable]
public class TutorialState
{
    public bool tutorialsEnabled =
        true;

    public bool choicesSeen =
        false;

    public bool playerKnowledgeSeen =
        false;

    public bool mayaProfileSeen =
        false;

    public bool navelStatusSeen =
        false;

    public bool evidenceSeen =
        false;

    public bool savingSeen =
        false;
}


// ============================================================
// COMPLETE SAVE / PLAYTHROUGH STATE
// ============================================================

[Serializable]
public class GameState
{
    // ========================================================
    // WORLD
    // ========================================================

    public int day = 1;

    public int hour = 7;

    public int minute = 18;

    public int money = 100;


    // ========================================================
    // CURRENT DOMINANT ROUTE
    //
    // This does NOT mean other routes are automatically closed.
    // ========================================================

    public RouteID dominantRoute =
        RouteID.None;


    // ========================================================
    // CORE DATA
    // ========================================================

    public MayaState maya =
        new MayaState();

    public KnowledgeState knowledge =
        new KnowledgeState();

    public TutorialState tutorials =
        new TutorialState();


    // ========================================================
    // STORY PROGRESS
    // ========================================================

    public bool openingCompleted =
        false;

    public bool dayOneCompleted =
        false;

    public bool partyCompleted =
        false;

    public string currentStoryNode =
        "Opening_Start";


    // ========================================================
    // SAVE VALIDATION
    // ========================================================

    public void Validate()
    {
        if (maya == null)
            maya = new MayaState();

        if (knowledge == null)
            knowledge = new KnowledgeState();

        if (tutorials == null)
            tutorials = new TutorialState();

        maya.ClampAllStats();

        day = Mathf.Max(day, 1);

        hour = Mathf.Clamp(
            hour,
            0,
            23
        );

        minute = Mathf.Clamp(
            minute,
            0,
            59
        );
    }
}