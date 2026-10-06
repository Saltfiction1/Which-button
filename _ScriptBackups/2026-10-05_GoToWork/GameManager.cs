using UnityEngine;

// ============================================================
// WHICH BUTTON
// GameManager.cs
//
// Controls the current playthrough and keeps GameState alive
// when moving between scenes.
// ============================================================

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Current Playthrough")]
    public GameState State = new GameState();

    private void Awake()
    {
        // Prevent duplicate GameManagers.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Keep this GameManager alive between scenes.
        DontDestroyOnLoad(gameObject);

        InitializeGame();
    }

    private void InitializeGame()
    {
        if (State == null)
        {
            State = new GameState();
        }

        State.Validate();

        Debug.Log("Which Button GameManager initialized.");

        Debug.Log(
            "Maya starting stats | " +
            "Affection: " + State.maya.affection +
            " | Trust: " + State.maya.trust +
            " | Loyalty: " + State.maya.loyalty +
            " | Corruption: " + State.maya.corruption
        );
    }

    // ========================================================
    // NEW GAME
    // ========================================================

    public void StartNewGame()
    {
        State = new GameState();

        State.Validate();

        Debug.Log("New Which Button game started.");
    }

    // ========================================================
    // TIME
    // ========================================================

    public void SetTime(int day, int hour, int minute)
    {
        State.day = Mathf.Max(1, day);
        State.hour = Mathf.Clamp(hour, 0, 23);
        State.minute = Mathf.Clamp(minute, 0, 59);
    }

    public void AdvanceDay()
    {
        State.day++;

        State.hour = 7;
        State.minute = 0;

        // Redness naturally decreases overnight.
        State.maya.navel.ReduceRedness(15f);

        Debug.Log("Advanced to Day " + State.day);
    }

    // ========================================================
    // MAYA CORE STATS
    // ========================================================

    public void ChangeAffection(float amount)
    {
        State.maya.affection += amount;
        ValidateStats();
    }

    public void ChangeTrust(float amount)
    {
        State.maya.trust += amount;
        ValidateStats();
    }

    public void ChangeLoyalty(float amount)
    {
        State.maya.loyalty += amount;
        ValidateStats();
    }

    public void ChangeCorruption(float amount)
    {
        State.maya.corruption += amount;
        ValidateStats();
    }

    public void ChangeSecrecy(float amount)
    {
        State.maya.secrecy += amount;
        ValidateStats();
    }

    public void ChangeConfidence(float amount)
    {
        State.maya.confidence += amount;
        ValidateStats();
    }

    public void ChangeRiskTaking(float amount)
    {
        State.maya.riskTaking += amount;
        ValidateStats();
    }

    public void ChangeBoundaries(float amount)
    {
        State.maya.boundaries += amount;
        ValidateStats();
    }

    // ========================================================
    // CHARACTER RELATIONSHIPS
    // ========================================================

    public void ChangeAttraction(
        CharacterID character,
        float amount)
    {
        RelationshipState relationship =
            State.maya.GetRelationship(character);

        if (relationship == null)
            return;

        relationship.attraction += amount;

        ValidateStats();
    }

    public void ChangeLove(
        CharacterID character,
        float amount)
    {
        RelationshipState relationship =
            State.maya.GetRelationship(character);

        if (relationship == null)
            return;

        relationship.love += amount;

        ValidateStats();
    }

    public void ChangeRouteProgress(
        CharacterID character,
        float amount)
    {
        RelationshipState relationship =
            State.maya.GetRelationship(character);

        if (relationship == null)
            return;

        relationship.routeProgress += amount;

        if (relationship.routeProgress > 0f)
        {
            relationship.routeUnlocked = true;
        }

        ValidateStats();
    }

    public void ChangeNavelFamiliarity(
        CharacterID character,
        float amount)
    {
        RelationshipState relationship =
            State.maya.GetRelationship(character);

        if (relationship == null)
            return;

        relationship.navelFamiliarity += amount;

        ValidateStats();
    }

    public void ChangeArousalResponse(
        CharacterID character,
        float amount)
    {
        RelationshipState relationship =
            State.maya.GetRelationship(character);

        if (relationship == null)
            return;

        relationship.arousalResponse += amount;

        ValidateStats();
    }

    // ========================================================
    // NAVEL STATUS
    // ========================================================

    public void AddNavelRedness(float amount)
    {
        State.maya.navel.AddRedness(amount);
    }

    public void ReduceNavelRedness(float amount)
    {
        State.maya.navel.ReduceRedness(amount);
    }

    public void SetNavelJewelry(NavelJewelry jewelry)
    {
        State.maya.navel.SetJewelry(jewelry);
    }

    public void RemoveNavelJewelry()
    {
        State.maya.navel.RemoveJewelry();
    }

    // ========================================================
    // KNOWLEDGE
    // ========================================================

    public void AddPlayerKnowledge(int amount)
    {
        State.knowledge.playerKnowledge += amount;
    }

    public void AddMCKnowledge(int amount)
    {
        State.knowledge.mcKnowledge += amount;
    }

    // ========================================================
    // MARCUS ROUTE
    // ========================================================

    public void UnlockMarcusNavelInterest()
    {
        State.maya.marcusNavelInterestUnlocked = true;

        State.knowledge.knowsMarcusInterest = true;

        Debug.Log(
            "PLAYER KNOWLEDGE: Marcus noticed something."
        );
    }

    public void ChangeMarcusClaim(float amount)
    {
        State.maya.marcusClaim += amount;

        ValidateStats();
    }

    // ========================================================
    // JULIAN ROUTE
    // Conditioning remains separate from voluntary attachment.
    // ========================================================

    public void ChangeJulianInfluence(float amount)
    {
        State.maya.julianInfluence += amount;

        ValidateStats();
    }

    public void ChangeJulianConditioning(float amount)
    {
        State.maya.julianConditioning += amount;

        ValidateStats();
    }

    public void ChangeJulianVoluntaryAttachment(float amount)
    {
        State.maya.julianVoluntaryAttachment += amount;

        ValidateStats();
    }

    // ========================================================
    // VALIDATION
    // ========================================================

    private void ValidateStats()
    {
        if (State == null || State.maya == null)
            return;

        State.maya.ClampAllStats();
    }

    // ========================================================
    // DEBUG
    //
    // This lets us verify Maya's state while developing.
    // ========================================================

    public void PrintCurrentState()
    {
        Debug.Log(
            "DAY " + State.day +
            " | Affection: " + State.maya.affection +
            " | Trust: " + State.maya.trust +
            " | Loyalty: " + State.maya.loyalty +
            " | Corruption: " + State.maya.corruption +
            " | Secrecy: " + State.maya.secrecy +
            " | Navel Redness: " + State.maya.navel.redness +
            " | Jewelry: " + State.maya.navel.actualJewelry
        );
    }
}