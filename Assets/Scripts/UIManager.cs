using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
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
    private int dayCount = 0;
    public TextMeshProUGUI daysPassed;
    public TextMeshProUGUI timeCounter;
    public float timeLeft = 0f;
    public bool isDay = true;
    private int selectWeaponIndex = 0;
    public List<string> weaponsAvaliable;

    protected override void Awake()
    {
        IsPersistentBetweenScenes = false;
        base.Awake();
    }

    private void Start()
    {
        timeLeft = DayNightSystem.Instance.dayTime;
        UpdateAvaliableWeapons();
    }

    private void Update()
    {
        if (isDay)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timeCounter.text = "Time to night: " + (Mathf.Ceil(timeLeft)).ToString();
            }
        }
        else
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timeCounter.text = "Time to day: " + (Mathf.Ceil(timeLeft)).ToString();
            }
        }
        
        if (weaponsAvaliable.Count == 0)
        {
            return;
        }
        SelectWeaponByNumber();
        SelectWeaponByMouseWheel();
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
        if (InventorySystem.Instance.hasGoldenBanana == false)
        {
            yellowBananWeapon.interactable = false;
            activeYellowBananaWeapon.SetActive(false);
        }
        else
        {
            yellowBananWeapon.interactable = true;
        }
        if (InventorySystem.Instance.hasGreenBanana == false)
        {
            greenBananaWeapon.interactable = false;
            activeGreenBananaWeapon.SetActive(false);
        }
        else
        {
            greenBananaWeapon.interactable = true;
        }
        UpdateAvaliableWeapons();
    }

    public void SelectWeapon(string bulletName)
    {
        switch (bulletName)
        {
            case "corn":
                if (actualSelectedWeapon == "corn")
                {
                    activeCornWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                    // selectWeaponIndex = 0;
                }
                else
                {
                    activeCornWeapon.SetActive(true);
                    activeCarrotWeapon.SetActive(false);
                    activePotatoWeapon.SetActive(false);
                    activeGreenBananaWeapon.SetActive(false);
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "corn";
                    selectWeaponIndex = 1;
                }
                break;
            case "carrot":
                if (actualSelectedWeapon == "carrot")
                {
                    activeCarrotWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                    // selectWeaponIndex = 0;
                }
                else
                {
                    activeCornWeapon.SetActive(false);
                    activeCarrotWeapon.SetActive(true);
                    activePotatoWeapon.SetActive(false);
                    activeGreenBananaWeapon.SetActive(false);
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "carrot";
                    selectWeaponIndex = 2;
                }
                break;
            case "potato":
                if (actualSelectedWeapon == "potato")
                {
                    activePotatoWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                    // selectWeaponIndex = 0;
                }
                else
                {
                    activeCornWeapon.SetActive(false);
                    activeCarrotWeapon.SetActive(false);
                    activePotatoWeapon.SetActive(true);
                    activeGreenBananaWeapon.SetActive(false);
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "potato";
                    selectWeaponIndex = 3;
                }
                break;
            case "greenBanana":
                if (actualSelectedWeapon == "greenBanana")
                {
                    activeGreenBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                    // selectWeaponIndex = 0;
                }
                else
                {
                    activeCornWeapon.SetActive(false);
                    activeCarrotWeapon.SetActive(false);
                    activePotatoWeapon.SetActive(false);
                    activeGreenBananaWeapon.SetActive(true);
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "greenBanana";
                    selectWeaponIndex = 4;
                }
                break;
            case "yellowBanana":
                if (actualSelectedWeapon == "yellowBanana")
                {
                    activeYellowBananaWeapon.SetActive(false);
                    actualSelectedWeapon = "";
                    // selectWeaponIndex = 0;
                }
                else
                {
                    activeCornWeapon.SetActive(false);
                    activeCarrotWeapon.SetActive(false);
                    activePotatoWeapon.SetActive(false);
                    activeGreenBananaWeapon.SetActive(false);
                    activeYellowBananaWeapon.SetActive(true);
                    actualSelectedWeapon = "yellowBanana";
                    selectWeaponIndex = 5;
                }
                break;
        }
        InventorySystem.Instance.SelectWeapon(bulletName);
    }

    public void DayCicle()
    {
        dayCount++;
        daysPassed.text = "Days: " + dayCount.ToString();
        isDay = true;
        timeLeft = DayNightSystem.Instance.dayTime;
    }

    public void NightCicle()
    {
        isDay = false;
        timeLeft = DayNightSystem.Instance.nightTime;
    }
    public void SelectWeaponByNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponsAvaliable.Count > 0)
        {
            selectWeaponIndex = 0;
            SelectWeaponByIndex();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weaponsAvaliable.Count > 1)
        {
            selectWeaponIndex = 1;
            SelectWeaponByIndex();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weaponsAvaliable.Count > 2)
        {
            selectWeaponIndex = 2;
            SelectWeaponByIndex();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && weaponsAvaliable.Count > 3)
        {
            selectWeaponIndex = 3;
            SelectWeaponByIndex();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && weaponsAvaliable.Count > 4)
        {
            selectWeaponIndex = 4;
            SelectWeaponByIndex();
            return;
        }
    }
    public void SelectWeaponByMouseWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ChangeIndex(1);
            SelectWeaponByIndex();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            ChangeIndex(-1);
            SelectWeaponByIndex();
        }

    }
    private void ChangeIndex(int change)
    {
        selectWeaponIndex += change;
        if (selectWeaponIndex > weaponsAvaliable.Count - 1)
        {
            selectWeaponIndex = 0;
            return;
        }
        if (selectWeaponIndex < 0)
        {
            selectWeaponIndex = weaponsAvaliable.Count - 1;
            return;
        }
    }
    private void SelectWeaponByIndex()
    {
        SelectWeapon(weaponsAvaliable[selectWeaponIndex]);
        // if (selectWeaponIndex == 1 && InventorySystem.Instance.cornBullets > 0)
        // {
        //     SelectWeapon("corn");
        //     return;
        // }

        // if (selectWeaponIndex == 2 && InventorySystem.Instance.carrotBullets > 0)
        // {
        //     SelectWeapon("carrot");
        //     return;
        // }

        // if (selectWeaponIndex == 3 && InventorySystem.Instance.potatoBullets > 0)
        // {
        //     SelectWeapon("potato");
        //     return;
        // }

        // if (selectWeaponIndex == 4 && InventorySystem.Instance.hasGreenBanana)
        // {
        //     SelectWeapon("greenBanana");
        //     return;
        // }

        // if (selectWeaponIndex == 5 && InventorySystem.Instance.hasGoldenBanana)
        // {
        //     SelectWeapon("yellowBanana");
        //     return;
        // }
    }
    public void UpdateAvaliableWeapons()
    {
        weaponsAvaliable = new List<string>();

        if (InventorySystem.Instance.cornBullets > 0)
        {
            weaponsAvaliable.Add("corn");
        }

        if (InventorySystem.Instance.carrotBullets > 0)
        {
            weaponsAvaliable.Add("carrot");
        }

        if (InventorySystem.Instance.potatoBullets > 0)
        {
            weaponsAvaliable.Add("potato");
        }

        if (InventorySystem.Instance.hasGreenBanana)
        {
            weaponsAvaliable.Add("greenBanana");
        }

        if (InventorySystem.Instance.hasGoldenBanana)
        {
            weaponsAvaliable.Add("yellowBanana");
        }
    }
}
