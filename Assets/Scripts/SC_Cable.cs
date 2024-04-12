using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Cable : C_Interactable
{
    
    public GameObject mySelf;

    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;

    public Transform holdPos;
    public float smoothSpeed;
    public string variableString;
    public bool isPicked;


    private int layerNumber;
    private Rigidbody myselfRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        layerNumber = LayerMask.NameToLayer("holdLayer");
        myselfRigidbody = mySelf.GetComponent<Rigidbody>();
        pickUpScript = FindObjectOfType<SC_PickUp>();
        fpsController = FindObjectOfType<SC_FPSController>();
    }
    
    public void OnMouseOver()
    {
        
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        isPicked = true;
        myselfRigidbody.isKinematic = true;
        mySelf.transform.parent = holdPos.transform;
        mySelf.layer = layerNumber;
        Debug.Log("Interacting with a cable");
        
    }

    void DropObject()
    {
        isPicked = false;
        mySelf.layer = 0;
        myselfRigidbody.isKinematic = false;
        mySelf.transform.parent = null;
        pickUpScript.canInteract = true;
    }


}
