using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public enum DayState {
    Day,
    Night
}

public class DayNightSystem : MonoBehaviour
{
    [Header("Day time in seconds")]
    public int dayTime = 60;
    [Header("Night time in seconds")]
    public int nightTime = 45;
    [Header("Actual state of the day")]
    public DayState actualState = DayState.Day;

    // Event handler
    public GameEvent dayNightCicleEvent;

    // Optimazation variables
    private WaitForSeconds dayTimeWait;
    private WaitForSeconds nightTimeWait;

    void Start()
    {
        dayTimeWait = new WaitForSeconds(dayTime);
        nightTimeWait = new WaitForSeconds(nightTime);
        StartCoroutine("ChangeDayCicle");
    }

    // Update is called once per frame
    void OnDestroy() {
        StopAllCoroutines();
    }

    private IEnumerator ChangeDayCicle()
    {
        while (true)
        {
            Debug.Log("Passou");
            Debug.Log(actualState);
            if (actualState == DayState.Day) {
                yield return dayTimeWait;
                Debug.Log("Continue to Night");
                actualState = DayState.Night;
                dayNightCicleEvent.TriggerEvent();
            } else {
                yield return nightTimeWait;
                Debug.Log("Continue to Day");
                actualState = DayState.Day;
                dayNightCicleEvent.TriggerEvent();
            }
        }
    }

    
}
