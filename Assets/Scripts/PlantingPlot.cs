using UnityEngine;

public class PlantingPlot : MonoBehaviour
{
    public int daysPassed = 0;
    public Seed actualSeed;
    public SpriteRenderer plantedSeedSprite;

    public void DayCicle() {
        if (!actualSeed) {
            return;
        }
        daysPassed = Mathf.Clamp(daysPassed + 1, 0, actualSeed.daysToGrow);
        if (daysPassed == actualSeed.daysToGrow) {
            plantedSeedSprite.sprite = actualSeed.growUpSprite;
        }
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)) {
            if (!actualSeed) {
                Debug.Log("Trying to plant");
                Seed seed = InventorySystem.Instance.UseSeed();
                plantedSeedSprite.sprite = seed.defaultSprite;
                actualSeed = seed;
                daysPassed = 0;
            }
            else if (actualSeed) {
                if (daysPassed == actualSeed.daysToGrow) {
                    Debug.Log("Harvested");
                    plantedSeedSprite.sprite = null;
                    actualSeed = null;
                    daysPassed = 0;
                } else {
                    Debug.Log("Not ready yet");
                    // Show an UI saying the remaining days to grow up
                }
            }
        }
    }
}
