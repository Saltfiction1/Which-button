using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;
using System;

public class HomeScreenUI : MonoBehaviour
{
    // =========================================================
    // HOME BACKGROUND
    // =========================================================

    [Header("Home Background")]
    public Image backgroundImage;

    public Sprite morningBackground;
    public Sprite afternoonBackground;
    public Sprite eveningBackground;
    public Sprite nightBackground;


    // =========================================================
    // TOP RIGHT HUD
    // =========================================================

    [Header("Top Right HUD")]
    public TMP_Text dayText;
    public TMP_Text timeText;
    public TMP_Text moneyText;


    // =========================================================
    // BELLYBUTTON STATUS
    // =========================================================

    [Header("Bellybutton Status UI")]
    public Image navelStatusImage;
    public TMP_Text navelStatusText;

    [Header("Bellybutton Status Images")]
    public Sprite normalBellybuttonImage;
    public Sprite adrianBellybuttonImage;
    public Sprite marcusBellybuttonImage;
    public Sprite julianBellybuttonImage;


    // =========================================================
    // MAYA OUTFIT + ROUTE SPRITES
    // =========================================================

    [Serializable]
    public class MayaOutfitSpriteSet
    {
        public string outfitName = "Casual";

        [Header("Normal Maya")]
        public Sprite normalStage1;
        public Sprite normalStage2;
        public Sprite normalStage3;

        [Header("Adrian Maya")]
        public Sprite adrianStage1;
        public Sprite adrianStage2;
        public Sprite adrianStage3;

        [Header("Marcus Maya")]
        public Sprite marcusStage1;
        public Sprite marcusStage2;
        public Sprite marcusStage3;

        [Header("Julian Maya")]
        public Sprite julianStage1;
        public Sprite julianStage2;
        public Sprite julianStage3;
    }


    [Header("Maya Main Character")]
    public Image mayaCharacterImage;

    [Header("Current Wardrobe")]
    public string currentOutfit = "Casual";

    [Header("Maya Outfit Sprite Sets")]
    public MayaOutfitSpriteSet[] outfitSpriteSets;


    // =========================================================
    // START
    // =========================================================

    private void Start()
    {
        RefreshHomeVisuals();
    }


    // =========================================================
    // REFRESH EVERYTHING
    // =========================================================

    public void RefreshHomeVisuals()
    {
        RefreshBackground();
        RefreshHUD();
        RefreshNavelStatus();
        RefreshMayaCharacter();
    }


    // =========================================================
    // HOME BACKGROUND
    // =========================================================

    public void RefreshBackground()
    {
        if (backgroundImage == null)
            return;

        if (GameManager.Instance == null)
            return;

        if (GameManager.Instance.State == null)
            return;

        int hour = GameManager.Instance.State.hour;

        Sprite chosenBackground = null;


        // -----------------------------------------------------
        // MORNING
        // 5:00 AM - 10:59 AM
        // -----------------------------------------------------

        if (hour >= 5 && hour < 11)
        {
            chosenBackground = morningBackground;
        }


        // -----------------------------------------------------
        // AFTERNOON
        // 11:00 AM - 4:59 PM
        // -----------------------------------------------------

        else if (hour >= 11 && hour < 17)
        {
            chosenBackground = afternoonBackground;
        }


        // -----------------------------------------------------
        // EVENING
        // 5:00 PM - 8:59 PM
        // -----------------------------------------------------

        else if (hour >= 17 && hour < 21)
        {
            chosenBackground = eveningBackground;
        }


        // -----------------------------------------------------
        // NIGHT
        // 9:00 PM - 4:59 AM
        // -----------------------------------------------------

        else
        {
            chosenBackground = nightBackground;
        }


        if (chosenBackground != null)
        {
            backgroundImage.sprite = chosenBackground;
            backgroundImage.preserveAspect = true;
        }
    }


    // =========================================================
    // TOP RIGHT HUD
    // =========================================================

    public void RefreshHUD()
    {
        if (GameManager.Instance == null)
            return;

        if (GameManager.Instance.State == null)
            return;

        GameState state = GameManager.Instance.State;


        // -----------------------------------------------------
        // DAY
        // -----------------------------------------------------

        if (dayText != null)
        {
            dayText.text = "DAY " + state.day;
        }


        // -----------------------------------------------------
        // TIME
        // -----------------------------------------------------

        if (timeText != null)
        {
            int hour12 = state.hour % 12;

            if (hour12 == 0)
            {
                hour12 = 12;
            }

            string amPm =
                state.hour >= 12
                ? "PM"
                : "AM";

            timeText.text =
                hour12.ToString() +
                ":" +
                state.minute.ToString("00") +
                " " +
                amPm;
        }


        // -----------------------------------------------------
        // MONEY
        // -----------------------------------------------------

        if (moneyText != null)
        {
            moneyText.text = "$" + state.money;
        }
    }


    // =========================================================
    // WARDROBE BUTTON FUNCTIONS
    // =========================================================

    public void SetCasualOutfit()
    {
        SetOutfit("Casual");
    }

    public void SetLoungeOutfit()
    {
        SetOutfit("Lounge");
    }

    public void SetStreetwearOutfit()
    {
        SetOutfit("Streetwear");
    }

    public void SetDateNightOutfit()
    {
        SetOutfit("Date Night");
    }

    public void SetSmartCasualOutfit()
    {
        SetOutfit("Smart Casual");
    }

    public void SetCozyOutfit()
    {
        SetOutfit("Cozy");
    }


    public void SetOutfit(string outfitName)
    {
        currentOutfit = outfitName;

        RefreshMayaCharacter();
    }


    // =========================================================
    // BELLYBUTTON STATUS
    // =========================================================

    public void RefreshNavelStatus()
    {
        if (navelStatusImage == null ||
            navelStatusText == null)
        {
            return;
        }

        string jewelryName = GetCurrentJewelryName();

        switch (jewelryName)
        {
            case "None":

                navelStatusImage.sprite =
                    normalBellybuttonImage;

                navelStatusText.text =
                    "NO RING";

                break;


            case "AdrianInitialA":

                navelStatusImage.sprite =
                    adrianBellybuttonImage;

                navelStatusText.text =
                    "ADRIAN A";

                break;


            case "MarcusQueenOfSpades":

                navelStatusImage.sprite =
                    marcusBellybuttonImage;

                navelStatusText.text =
                    "QUEEN OF SPADES";

                break;


            case "JulianPurpleAnchor":

                navelStatusImage.sprite =
                    julianBellybuttonImage;

                navelStatusText.text =
                    "WATCHFUL EYE";

                break;


            default:

                navelStatusImage.sprite =
                    normalBellybuttonImage;

                navelStatusText.text =
                    "NO RING";

                break;
        }

        navelStatusImage.preserveAspect = true;
    }


    // =========================================================
    // MAYA MAIN CHARACTER
    // =========================================================

    public void RefreshMayaCharacter()
    {
        if (mayaCharacterImage == null)
            return;

        MayaOutfitSpriteSet outfit =
            FindCurrentOutfitSet();

        if (outfit == null)
            return;

        string routeName =
            GetVisualRouteName();

        float corruption =
            GetCurrentCorruption();

        int stage =
            GetSpriteStage(corruption);

        Sprite chosenSprite =
            GetSpriteForLook(
                outfit,
                routeName,
                stage
            );

        if (chosenSprite != null)
        {
            mayaCharacterImage.sprite =
                chosenSprite;

            mayaCharacterImage.preserveAspect =
                true;
        }
    }


    private MayaOutfitSpriteSet FindCurrentOutfitSet()
    {
        if (outfitSpriteSets == null ||
            outfitSpriteSets.Length == 0)
        {
            return null;
        }

        foreach (
            MayaOutfitSpriteSet outfit
            in outfitSpriteSets)
        {
            if (outfit == null)
                continue;

            if (string.Equals(
                outfit.outfitName,
                currentOutfit,
                StringComparison.OrdinalIgnoreCase))
            {
                return outfit;
            }
        }


        // If selected outfit doesn't exist yet,
        // use the first available outfit.

        return outfitSpriteSets[0];
    }


    private Sprite GetSpriteForLook(
        MayaOutfitSpriteSet outfit,
        string routeName,
        int stage)
    {
        switch (routeName)
        {
            case "Adrian":

                return GetStageSprite(
                    stage,
                    outfit.adrianStage1,
                    outfit.adrianStage2,
                    outfit.adrianStage3
                );


            case "Marcus":

                return GetStageSprite(
                    stage,
                    outfit.marcusStage1,
                    outfit.marcusStage2,
                    outfit.marcusStage3
                );


            case "Julian":

                return GetStageSprite(
                    stage,
                    outfit.julianStage1,
                    outfit.julianStage2,
                    outfit.julianStage3
                );


            default:

                return GetStageSprite(
                    stage,
                    outfit.normalStage1,
                    outfit.normalStage2,
                    outfit.normalStage3
                );
        }
    }


    // =========================================================
    // MAYA SPRITE STAGES
    //
    // Stage 1 = 0 - 33.99 corruption
    // Stage 2 = 34 - 66.99 corruption
    // Stage 3 = 67+
    // =========================================================

    private int GetSpriteStage(float corruption)
    {
        if (corruption >= 67f)
            return 3;

        if (corruption >= 34f)
            return 2;

        return 1;
    }


    private Sprite GetStageSprite(
        int stage,
        Sprite stage1,
        Sprite stage2,
        Sprite stage3)
    {
        if (stage == 3 &&
            stage3 != null)
        {
            return stage3;
        }

        if (stage == 2 &&
            stage2 != null)
        {
            return stage2;
        }

        if (stage1 != null)
        {
            return stage1;
        }


        // Fallbacks so Maya never disappears
        // if artwork is temporarily missing.

        if (stage2 != null)
        {
            return stage2;
        }

        if (stage3 != null)
        {
            return stage3;
        }

        return null;
    }


    // =========================================================
    // VISUAL ROUTE
    // =========================================================

    private string GetVisualRouteName()
    {
        string jewelryName =
            GetCurrentJewelryName();


        // Actual jewelry takes priority.

        if (jewelryName ==
            "AdrianInitialA")
        {
            return "Adrian";
        }

        if (jewelryName ==
            "MarcusQueenOfSpades")
        {
            return "Marcus";
        }

        if (jewelryName ==
            "JulianPurpleAnchor")
        {
            return "Julian";
        }


        // Before route jewelry appears,
        // use dominant route.

        string dominantRoute =
            GetDominantRouteName();


        if (dominantRoute.Contains("Adrian"))
        {
            return "Adrian";
        }

        if (dominantRoute.Contains("Marcus"))
        {
            return "Marcus";
        }

        if (dominantRoute.Contains("Julian"))
        {
            return "Julian";
        }


        return "Normal";
    }


    // =========================================================
    // READ GAME STATE
    // =========================================================

    private string GetCurrentJewelryName()
    {
        if (GameManager.Instance == null)
            return "None";

        if (GameManager.Instance.State == null)
            return "None";


        object jewelry =
            FindFieldRecursive(
                GameManager.Instance.State,
                "actualJewelry",
                0
            );


        if (jewelry == null)
            return "None";


        return jewelry.ToString();
    }


    private string GetDominantRouteName()
    {
        if (GameManager.Instance == null)
            return "None";

        if (GameManager.Instance.State == null)
            return "None";


        object route =
            FindFieldRecursive(
                GameManager.Instance.State,
                "dominantRoute",
                0
            );


        if (route == null)
            return "None";


        return route.ToString();
    }


    private float GetCurrentCorruption()
    {
        if (GameManager.Instance == null)
            return 0f;

        if (GameManager.Instance.State == null)
            return 0f;


        object corruption =
            FindFieldRecursive(
                GameManager.Instance.State,
                "corruption",
                0
            );


        if (corruption == null)
            return 0f;


        try
        {
            return Convert.ToSingle(
                corruption
            );
        }
        catch
        {
            return 0f;
        }
    }


    // =========================================================
    // REFLECTION SEARCH
    // =========================================================

    private object FindFieldRecursive(
        object obj,
        string fieldName,
        int depth)
    {
        if (obj == null ||
            depth > 6)
        {
            return null;
        }


        Type type =
            obj.GetType();


        FieldInfo targetField =
            type.GetField(
                fieldName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );


        if (targetField != null)
        {
            return targetField.GetValue(obj);
        }


        FieldInfo[] fields =
            type.GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance
            );


        foreach (
            FieldInfo field
            in fields)
        {
            Type fieldType =
                field.FieldType;


            if (fieldType.IsPrimitive ||
                fieldType.IsEnum ||
                fieldType == typeof(string) ||
                typeof(UnityEngine.Object)
                    .IsAssignableFrom(fieldType))
            {
                continue;
            }


            object child;


            try
            {
                child =
                    field.GetValue(obj);
            }
            catch
            {
                continue;
            }


            object result =
                FindFieldRecursive(
                    child,
                    fieldName,
                    depth + 1
                );


            if (result != null)
            {
                return result;
            }
        }


        return null;
    }
}