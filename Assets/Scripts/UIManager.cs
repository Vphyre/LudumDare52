using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
    public Button cornSeed;
    public TextMeshProUGUI cornSeedQtd;
    public Button potatoSeed;
    public TextMeshProUGUI potatoSeedQtd;
    public Button carrotSeed;
    public TextMeshProUGUI carrotSeedQtd;
    public GameObject activeCorn;
    public GameObject activeCarrot;
    public GameObject activePotato;

    public Button carrotWeapon;
    public TextMeshProUGUI carrotBullets;
    public Button potatoWeapon;
    public TextMeshProUGUI potatoBullets;
    public Button cornWeapon;
    public TextMeshProUGUI cornBullets;
    public Button greenBananaWeapon;
    public TextMeshProUGUI greenBananaQtd;
    public Button yellowBananWeapon;
    public TextMeshProUGUI yellowBananaQtd;
    public GameObject activeCornWeapon;
    public GameObject activeCarrotWeapon;
    public GameObject activePotatoWeapon;
    public GameObject activeGreenBananaWeapon;
    public GameObject activeYellowBananaWeapon;
    public string actualSelectedSeed;
    public string actualSelectedWeapon;

    protected override void Awake()
    {
        IsPersistentBetweenScenes = false;
        base.Awake();
    }

    public void UpdateSeedUI()
    {
        cornSeedQtd.text = "Corn: " + InventorySystem.Instance.cornSeedQtd.ToString();
        carrotSeedQtd.text = "Carrot: " + InventorySystem.Instance.carrotSeedQtd.ToString();
        potatoSeedQtd.text = "Potato: " + InventorySystem.Instance.potatoSeedQtd.ToString();
        if (InventorySystem.Instance.cornSeedQtd <= 0)
        {
            cornSeed.interactable = false;
            activeCorn.SetActive(false);
        }
        else
        {
            cornSeed.interactable = true;
        }
        if (InventorySystem.Instance.carrotSeedQtd <= 0)
        {
            carrotSeed.interactable = false;
            activeCarrot.SetActive(false);
        }
        else
        {
            carrotSeed.interactable = true;
        }
        if (InventorySystem.Instance.potatoSeedQtd <= 0)
        {
            potatoSeed.interactable = false;
            activePotato.SetActive(false);
        }
        else
        {
            potatoSeed.interactable = true;
        }
    }

    public void SelectSeed(string seed)
    {
        switch (seed)
        {
            case "corn":
                if (actualSelectedSeed == "corn")
                {
                    activeCorn.SetActive(false);
                    actualSelectedSeed = "";
                }
                else
                {
                    activeCorn.SetActive(true);
                    activeCarrot.SetActive(false);
                    activePotato.SetActive(false);
                    actualSelectedSeed = "corn";
                }
                break;
            case "carrot":
                if (actualSelectedSeed == "carrot")
                {
                    activeCarrot.SetActive(false);
                    actualSelectedSeed = "";
                }
                else
                {
                    activeCorn.SetActive(false);
                    activeCarrot.SetActive(true);
                    activePotato.SetActive(false);
                    actualSelectedSeed = "carrot";
                }
                break;
            case "potato":
                if (actualSelectedSeed == "potato")
                {
                    activePotato.SetActive(false);
                    actualSelectedSeed = "";
                }
                else
                {
                    activeCorn.SetActive(false);
                    activeCarrot.SetActive(false);
                    activePotato.SetActive(true);
                    actualSelectedSeed = "potato";
                }
                break;
        }
        InventorySystem.Instance.SelectSeed(seed);
    }

    public void UpdateWeaponUI()
    {
        cornBullets.text = "Corn: " + InventorySystem.Instance.cornBullets.ToString();
        carrotBullets.text = "Carrot: " + InventorySystem.Instance.carrotBullets.ToString();
        potatoBullets.text = "Potato: " + InventorySystem.Instance.potatoBullets.ToString();
        if (InventorySystem.Instance.cornBullets <= 0)
        {
            cornWeapon.interactable = false;
            activeCornWeapon.SetActive(false);
        }
        else
        {
            cornWeapon.interactable = true;
        }
        if (InventorySystem.Instance.carrotBullets <= 0)
        {
            carrotWeapon.interactable = false;
            activeCarrotWeapon.SetActive(false);
        }
        else
        {
            carrotWeapon.interactable = true;
        }
        if (InventorySystem.Instance.potatoBullets <= 0)
        {
            potatoWeapon.interactable = false;
            activePotatoWeapon.SetActive(false);
        }
        else
        {
            potatoWeapon.interactable = true;
        }
    }

    public void SelectWeapon(string bulletName)
    {
        switch (bulletName)
        {
            case "corn":
                if (actualSelectedWeapon == "corn")
                {
                    activeCornWeapon.SetActive(false);
                    actualSelectedSeed = "";
                }
                else
                {
                    activeCornWeapon.SetActive(true);
                    activeCarrotWeapon.SetActive(false);
                    activePotatoWeapon.SetActive(false);
                    activeGreenBananaWeapon.SetActive(false);
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "corn";
                }
                break;
            case "carrot":
                if (actualSelectedWeapon == "carrot")
                {
                    activeCarrotWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                }
                else
                {
                    activeCornWeapon.SetActive(false);
                    activeCarrotWeapon.SetActive(true);
                    activePotatoWeapon.SetActive(false);
                    activeGreenBananaWeapon.SetActive(false);
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "carrot";
                }
                break;
            case "potato":
                if (actualSelectedWeapon == "potato")
                {
                    activePotatoWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                }
                else
                {
                    activeCornWeapon.SetActive(false);
                    activeCarrotWeapon.SetActive(false);
                    activePotatoWeapon.SetActive(true);
                    activeGreenBananaWeapon.SetActive(false);
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedSeed = "potato";
                }
                break;
            case "greenBanana":
                if (actualSelectedWeapon == "greenBanana")
                {
                    activeGreenBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                }
                else
                {
                    activeCornWeapon.SetActive(false);
                    activeCarrotWeapon.SetActive(false);
                    activePotatoWeapon.SetActive(false);
                    activeGreenBananaWeapon.SetActive(true);
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedSeed = "greenBanana";
                }
                break;
            case "yellowBanana":
                if (actualSelectedWeapon == "yellowBanana")
                {
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                }
                else
                {
                    activeCornWeapon.SetActive(false);
                    activeCarrotWeapon.SetActive(false);
                    activePotatoWeapon.SetActive(false);
                    activeGreenBananaWeapon.SetActive(false);
                    activeYellowBananaWeapon.SetActive(true);
                    actualSelectedSeed = "yellowBanana";
                }
                break;
        }
        InventorySystem.Instance.SelectWeapon(bulletName);
    }
}
