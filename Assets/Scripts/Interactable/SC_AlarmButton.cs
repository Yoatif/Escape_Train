using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AlarmButton : MonoBehaviour
{
    private List<int> ClickedObjectValue = new List<int>();

    [SerializeField]
    private List<int> AlarmCode = new List<int>();


    private int clickedCounter = 0;
    public bool alarm = false;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomNumber = Random.Range(1, 9);
            AlarmCode[i] = randomNumber;
        }
    }

    public void ReceiveValue(int receivedValue)
    {
        ClickedObjectValue.Add(receivedValue);
        clickedCounter++;
        Debug.Log(ClickedObjectValue[0]);
        Debug.Log(ClickedObjectValue[1]);
        Debug.Log(ClickedObjectValue[2]);
        Debug.Log(ClickedObjectValue[3]);
    }

    void CheckValidation()
    {
        if (clickedCounter == 4)
        {
            if (ClickedObjectValue[0] == AlarmCode[0])
            {
                if (ClickedObjectValue[1] == AlarmCode[1])
                {
                    if (ClickedObjectValue[2] == AlarmCode[2])
                    {
                        if (ClickedObjectValue[3] == AlarmCode[3])
                        {
                            StopAlarm();
                        }
                    }
                }
            }
        }
    }

    public void StartAlarm()
    {
        alarm = true;
    }
    public void StopAlarm()
    {
        alarm = false;
    }

    private void OnMouseDown()
    {
        if(clickedCounter == 4)
        {
            CheckValidation();
        }
        
    }

}
