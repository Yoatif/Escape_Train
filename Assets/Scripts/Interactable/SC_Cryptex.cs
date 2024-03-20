using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Cryptex : C_Interactable
{
    public GameObject player;
    public Transform holdPos;
    public GameObject myself;
    public bool isPicked;
    public SC_PickUp pickUpScript;
    public SC_FPSController fpsController;
    private Rigidbody myselfRigidbody;

    [SerializeField]
    private Vector3 originPos;
    [SerializeField]
    private Quaternion originRot;




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
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                PutBack();
            }
            


        }

    }

    //Fonction d'interaction
    public override void Interact()
    {

        fpsController.canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pickUpScript.canInteract = false;


        isPicked = true;
        myself.transform.rotation = Camera.main.transform.rotation;
        myself.transform.Rotate(0, 0, 90);
        myself.transform.parent = holdPos.transform;
        myself.transform.position = holdPos.transform.position;

        
        myselfRigidbody.freezeRotation = true;

        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), true);



    }






    //Fonction pour lâcher l'objet
    void PutBack()
    {
       
        isPicked = false;
        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        myself.layer = 0;
        myself.transform.parent = null;
        pickUpScript.canInteract = true;
        myselfRigidbody.freezeRotation = false;
        fpsController.canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        myself.transform.position = originPos;
        myself.transform.rotation= originRot;
    }



}
