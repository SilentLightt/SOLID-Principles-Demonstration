using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Collections.Generic;
using System.Collections;
public class TimeManager : MonoBehaviour
{
    private int minutes;
    public int Minutes
    { get { return minutes; }set { minutes = value; OnMinutesChange( value); } }
    private int hours;
    public int Hours
    { get { return hours; } set { hours = value; OnHoursChange( value ); } }

    private int days;
    public int Days
            { get { return days; } set { days = value; } }
    private float tempSecond;

    public void Update()
    {
        tempSecond += Time.deltaTime;
        if (tempSecond >= 1)
        {
            minutes += 1;
            tempSecond = 0;
        }
    }
    private void OnMinutesChange(int value)
    {
        if (value >= 60)
        {
            Hours++;
            minutes = 0;
        }
        if (Hours >= 24)
        {
            Hours = 0;
            Days++;
        }
    }
    private void OnHoursChange(int value)
    {
        if (value == 6)
        {
          
        }
        else if (value == 8)
        {
            
        }
        else if (value == 18)
        {

        }
        else if (value == 22)
        {

        }
    }
}
