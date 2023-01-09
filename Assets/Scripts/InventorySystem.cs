using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : Singleton<InventorySystem>
{
    public List<Seed> seeds = new List<Seed>();
    public Seed selectedSeed = null;

    protected override void Awake() {
        IsPersistentBetweenScenes = false;
        base.Awake();
    }

    public void AddSeed (Seed seed) {
        seeds.Add(seed);
        if (!selectedSeed) {
            selectedSeed = seed;
        }
        // Updated HUD quantity
        // if quantity = 0, selectedSeed = null;
    }

    public Seed UseSeed () {
        if (!selectedSeed) {
            return null;
        }
        Seed oldSeed = selectedSeed;
        seeds.Remove(selectedSeed);
        selectedSeed = null;
        return oldSeed;
    }

    public void SelectSeed (Seed seed) {
        selectedSeed = seed;
    }
}
