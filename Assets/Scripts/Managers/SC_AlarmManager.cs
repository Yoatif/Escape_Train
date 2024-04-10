using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_AlarmManager : MonoBehaviour
{
    [SerializeField]
    private List<int> ClickedObjectValue = new List<int>();

    [SerializeField]
    private List<int> AlarmCode = new List<int>();

    private string codeString;

    public void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            int randomNumber = Random.Range(1, 9);
            AlarmCode[i] = randomNumber;
            Debug.Log("le chiffre a trouver est :" + AlarmCode[i]);

        }
        codeString = AlarmCode.ToString();
        print(codeString);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
