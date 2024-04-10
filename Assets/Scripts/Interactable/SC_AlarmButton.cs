using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AlarmButton : MonoBehaviour
{
    [SerializeField]
    //private List<int> ClickedObjectValue = new List<int>();
    public List<string> ClickedObjectValue = new List<string>();

    [SerializeField]
    private List<string> AlarmCode = new List<string>();

    private string codeString;
    public bool alarm = false;
    private int count;

    public AudioSource alarmSound;

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            int randomNumber = Random.Range(1, 9);
            codeString = randomNumber.ToString();
            AlarmCode[i] = codeString;
            Debug.Log("le chiffre a trouver est :" + AlarmCode[i]);
        }
        print("le code a trouver est " + AlarmCode[0] + AlarmCode[1] + AlarmCode[2] + AlarmCode[3]);
    }

    public void ReceiveValue(string receivedValue)
    {
        ClickedObjectValue.Add(receivedValue);

        Debug.Log(ClickedObjectValue[0]);
        Debug.Log(ClickedObjectValue[1]);
        Debug.Log(ClickedObjectValue[2]);
        Debug.Log(ClickedObjectValue[3]);
    }

    void CheckValidation()
    {
            for (int i = 0;i < ClickedObjectValue.Count;i++) { 

                if (ClickedObjectValue[i] == AlarmCode[i])
                {
                Debug.Log("is good");
                count++;
                }
                else { return; }
            }
        if (count == 4)
        {
            StopAlarm();
        }
    }
    

    public void StartAlarm()
    {
        alarm = true;
    }
    public void StopAlarm()
    {
        alarm = false;
        Debug.Log("l'alarme est éteinte");
    }

    public void OnMouseDown()
    {
        Debug.Log("try validation");
    
        CheckValidation();
    }
}


