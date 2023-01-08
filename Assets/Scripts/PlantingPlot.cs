using UnityEngine;

public class PlantingPlot : MonoBehaviour
{
    public int daysPassed = 0;
    public Seed actualSeed;

    public void dayCicle() {
        if (!actualSeed) {
            return;
        }
        daysPassed = Mathf.Clamp(daysPassed + 1, 0, actualSeed.daysToGrow);
        if (daysPassed == actualSeed.daysToGrow) {
            Debug.Log("Ready to harvest");
            //Change sprite to the growUp Sprite
            // transform.GetComponent<Sprite>().sprite = actualSeed.growUpSprite
        }
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)) {
            if (!actualSeed) {
                Debug.Log("Trying to plant");
                //Get selected from inventory .plant()
                // actualSeed = seed;
            }
            else if (actualSeed) {
                if (daysPassed == actualSeed.daysToGrow) {
                    Debug.Log("Harvested");
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
