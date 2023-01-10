using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : Singleton<InventorySystem>
{
    public List<Seed> seeds = new List<Seed>();
    public Seed selectedSeed = null;
    public Seed potato;
    public Seed carrot;
    public Seed corn;
    public int carrotSeedQtd = 0;
    public int potatoSeedQtd = 0;
    public int cornSeedQtd = 0;
    public int carrotBullets = 0;
    public int potatoBullets = 0;
    public int cornBullets = 0;
    public BulletType selectedBullet = null;
    public BulletType cornBullet;
    public BulletType carrotBullet;
    public BulletType potatoBullet;
    public BulletType greenBananaBullet;
    public BulletType yellowBananaBullet;
    public bool hasGoldenBanana = false;
    public bool hasGreenBanana = false;

    protected override void Awake()
    {
        IsPersistentBetweenScenes = false;
        base.Awake();
    }

    private void Start()
    {
        UIManager.Instance.UpdateSeedUI();
        UIManager.Instance.UpdateWeaponUI();
    }

    public void AddSeed(Seed seed)
    {
        seeds.Add(seed);
        switch (seed.seedName)
        {
            case "potato":
                potatoSeedQtd++;
                break;
            case "corn":
                cornSeedQtd++;
                break;
            case "carrot":
                carrotSeedQtd++;
                break;
            case "goldenBanana":
                hasGoldenBanana = true;
                UIManager.Instance.UpdateWeaponUI();
                break;
            case "greenBanana":
                hasGreenBanana = true;
                UIManager.Instance.UpdateWeaponUI();
                break;
            default:
                break;
        }
        UIManager.Instance.UpdateSeedUI();
    }

    public void AddBullets(Seed seed)
    {
        switch (seed.seedName)
        {
            case "potato":
                potatoBullets += seed.bulletsPerPlant;
                break;
            case "corn":
                cornBullets += seed.bulletsPerPlant;
                break;
            case "carrot":
                carrotBullets += seed.bulletsPerPlant;
                break;
            default:
                break;
        }
        UIManager.Instance.UpdateWeaponUI();
    }

    public BulletType UseBullet()
    {
        if (!selectedBullet)
        {
            return null;
        }
        BulletType oldBullet = selectedBullet;
        switch (oldBullet.bulletName)
        {
            case "potato":
                potatoBullets--;
                if (potatoBullets == 0)
                {
                    selectedBullet = null;
                }
                break;
            case "corn":
                cornBullets--;
                if (cornBullets == 0)
                {
                    selectedBullet = null;
                }
                break;
            case "carrot":
                carrotBullets--;
                if (carrotBullets == 0)
                {
                    selectedBullet = null;
                }
                break;
            default:
                break;
        }
        UIManager.Instance.UpdateWeaponUI();
        return oldBullet;
    }


    // SELECT BULLET VAI TER O TIPO SELECIONADO ATUAL, UTILIZAR PARA TROCAR A BALA DO PERSONAGEM
    // TERÁ Q SER CRIADO UM TIPO DE BALA PRA CADA PARA SABERMOS O QUE UTILIZAR.
    public void SelectWeapon(string weaponName)
    {
        switch (weaponName)
        {
            case "potato":
                if (selectedBullet && selectedBullet.bulletName == weaponName)
                {
                    selectedBullet = null;
                }
                else
                {
                    selectedBullet = potatoBullet;
                }
                break;
            case "corn":
                if (selectedBullet && selectedBullet.bulletName == weaponName)
                {
                    selectedBullet = null;
                }
                else
                {
                    selectedBullet = cornBullet;
                }
                break;
            case "carrot":
                if (selectedBullet && selectedBullet.bulletName == weaponName)
                {
                    selectedBullet = null;
                }
                else
                {
                    selectedBullet = carrotBullet;
                }
                break;
            case "greenBanana":
                if (selectedBullet && selectedBullet.bulletName == weaponName)
                {
                    selectedBullet = null;
                }
                else
                {
                    selectedBullet = greenBananaBullet;
                }
                break;
            case "yellowBanana":
                if (selectedBullet && selectedBullet.bulletName == weaponName)
                {
                    selectedBullet = null;
                }
                else
                {
                    selectedBullet = yellowBananaBullet;
                }
                break;
            default:
                break;
        }
    }

    public Seed UseSeed()
    {
        if (!selectedSeed)
        {
            return null;
        }
        Seed oldSeed = selectedSeed;
        seeds.Remove(selectedSeed);
        switch (oldSeed.seedName)
        {
            case "potato":
                potatoSeedQtd--;
                if (potatoSeedQtd == 0)
                {
                    selectedSeed = null;
                }
                break;
            case "corn":
                cornSeedQtd--;
                if (cornSeedQtd == 0)
                {
                    selectedSeed = null;
                }
                break;
            case "carrot":
                carrotSeedQtd--;
                if (carrotSeedQtd == 0)
                {
                    selectedSeed = null;
                }
                break;
            default:
                break;
        }
        UIManager.Instance.UpdateSeedUI();
        return oldSeed;
    }

    public void SelectSeed(string seedName)
    {
        switch (seedName)
        {
            case "potato":
                if (selectedSeed && selectedSeed.seedName == seedName)
                {
                    selectedSeed = null;
                }
                else
                {
                    selectedSeed = potato;
                }
                break;
            case "corn":
                if (selectedSeed && selectedSeed.seedName == seedName)
                {
                    selectedSeed = null;
                }
                else
                {
                    selectedSeed = corn;
                }
                break;
            case "carrot":
                if (selectedSeed && selectedSeed.seedName == seedName)
                {
                    selectedSeed = null;
                }
                else
                {
                    selectedSeed = carrot;
                }
                break;
            default:
                break;
        }
    }
}
