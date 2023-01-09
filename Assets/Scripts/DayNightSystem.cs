using UnityEngine;
using System.Collections;

public enum DayState {
    Day,
    Night
}

public class DayNightSystem : Singleton<DayNightSystem>
{
    [Header("Day time in seconds")]
    public int dayTime = 60;
    [Header("Night time in seconds")]
    public int nightTime = 45;
    [Header("Actual state of the day")]
    public DayState actualState = DayState.Day;

    // Event handler
    public GameEvent dayCicle;
    public GameEvent nightCicle;

    // Optimazation variables
    private WaitForSeconds dayTimeWait;
    private WaitForSeconds nightTimeWait;

    protected override void Awake()
    {
        IsPersistentBetweenScenes = true;
        base.Awake();
    }

    void Start()
    {
        dayTimeWait = new WaitForSeconds(dayTime);
        nightTimeWait = new WaitForSeconds(nightTime);
        StartCoroutine("ChangeDayCicle");
    }

    // Update is called once per frame
    protected override void OnDestroy() {
        StopAllCoroutines();
        base.OnDestroy();
    }

    public void StopDayNightCicle() {
        StopAllCoroutines();
    }

    public void StartDayNightCicle() {
        StartCoroutine("ChangeDayCicle");
    }

    private IEnumerator ChangeDayCicle()
    {
        while (true)
        {   
            if (actualState == DayState.Day) {
                yield return dayTimeWait;
                actualState = DayState.Night;
                nightCicle.TriggerEvent();
            } else {
                yield return nightTimeWait;
                actualState = DayState.Day;
                dayCicle.TriggerEvent();
            }
        }
    }

    
}
