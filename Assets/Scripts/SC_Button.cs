using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Button : MonoBehaviour
{
    
    public string buttonValue;



    public SC_AlarmButton alarmButton;

    /*public int ReturnValue(int buttonValue)
    {
        Debug.Log("valeur du bouton :" + buttonValue);
        return buttonValue;

    }

    public void OnMouseDown()
    {
        if (isClicked)
        {
            
            alarmButton.ReceiveValue(buttonValue);

        }
    }*/

    public void OnMouseDown()
    {
        Debug.Log("la valeur est de :" +  buttonValue);
        alarmButton.ReceiveValue(buttonValue);
    }
}
