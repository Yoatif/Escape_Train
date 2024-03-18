using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Cryptex : C_Interactable
{
    public GameObject player;
    public Transform holdPos;
    public GameObject myself;
    public bool isPicked;
    public float throwForce = 500f;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    


    [SerializeField]
    private float angleX, angleY, angleZ;


    private Rigidbody myselfRigidbody;

    




    private void Start()
    {
        
        myselfRigidbody = myself.GetComponent<Rigidbody>();
        pickUpScript = FindObjectOfType<SC_PickUp>();
        fpsController = FindObjectOfType<SC_FPSController>();
    }

    void Update()
    {
        if (isPicked)
        {
            myself.transform.position = holdPos.transform.position;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                DropObject();
            }
            


        }

    }

    //Fonction d'interaction
    public override void Interact()
    {

        
        

        isPicked = true;
        //myselfRigidbody.isKinematic = true;
        myself.transform.rotation = Camera.main.transform.rotation;
        myself.transform.Rotate(0, 0, 90);
        myself.transform.parent = holdPos.transform;
        myself.transform.position = holdPos.transform.position;

        
        myselfRigidbody.freezeRotation = true;

        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), true);



    }






    //Fonction pour lâcher l'objet
    void DropObject()
    {
       
        isPicked = false;
        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        myself.layer = 0;
        myselfRigidbody.isKinematic = false;
        myself.transform.parent = null;
        pickUpScript.canInteract = true;
        myselfRigidbody.freezeRotation = false;
    }



}
