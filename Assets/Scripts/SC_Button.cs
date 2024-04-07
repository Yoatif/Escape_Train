using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Button : MonoBehaviour
{
    [SerializeField]
    private int buttonValue;
    [SerializeField]
    private bool isClicked = false;


    public SC_AlarmButton alarmButton;

    public int ReturnValue(int buttonValue)
    {
        return buttonValue;
    }

    private void OnMouseDown()
    {
        if (isClicked)
        {
            isClicked = true;
            alarmButton.ReceiveValue(buttonValue);

        }
    }
}
