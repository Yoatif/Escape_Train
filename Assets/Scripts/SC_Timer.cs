using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject moon, earth;

    [SerializeField]
    private Vector2 maxEarth, minEarth, maxMoon, minMoon;

    private float lerp;
    
    
    void Start()
    {
        earth.transform.localScale= maxEarth;
        
        moon.transform.localScale = minMoon;


    }

    
    void Update()
    {
        lerp += Time.deltaTime/60;

        earth.transform.localScale = Vector2.Lerp(maxEarth, minEarth, lerp);

        moon.transform.localScale = Vector3.Lerp(minMoon,maxMoon, lerp);


    }
}
