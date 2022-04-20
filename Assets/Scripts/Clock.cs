using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private GameObject HourHand;

    [SerializeField]
    private GameObject MinuteHand;
    [SerializeField]
    private GameObject SecondHand;

    [SerializeField]
    private AudioSource ClockSound;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTime", 1f, 1f);        
    }

    private void UpdateTime()
    {
        DateTime dateTime = DateTime.Now;

        int hours = dateTime.Hour > 12 ? dateTime.Hour - 12 : dateTime.Hour;
        int minutes = dateTime.Minute;
        int seconds = dateTime.Second;

        double hoursInDegrees = (hours * 30) + (minutes * 30.0 / 60);
        double minutesInDegrees = minutes * 6;
        double secondsInDegrees = seconds  * 6;

        SecondHand.transform.localRotation = Quaternion.Euler(0, (float)secondsInDegrees, 0);
        MinuteHand.transform.localRotation = Quaternion.Euler(0, (float)minutesInDegrees, 0);
        HourHand.transform.localRotation = Quaternion.Euler(0, (float)hoursInDegrees, 0);

        ClockSound.Play();    
    }
}
