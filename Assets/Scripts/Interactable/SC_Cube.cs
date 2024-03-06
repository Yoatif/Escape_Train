using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Cube : C_Interactable
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
    
    private int LayerNumber;
    



    private void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer");
        myselfRigidbody = myself.GetComponent<Rigidbody>();
        pickUpScript = FindObjectOfType<SC_PickUp>();
        fpsController = FindObjectOfType<SC_FPSController>();
    }

    void Update()
    {
        if (isPicked)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                DropObject();
                MoveObject();
                


            }
            RotateObject();
            
        }
           
    }

    //Fonction d'interaction
    public override void Interact( )
    {
        isPicked = true;
        myselfRigidbody.isKinematic = true;
        myself.transform.Rotate(0, 0, 0, Space.World);
        myself.transform.parent = holdPos.transform;


        myself.layer = LayerNumber;

        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        


    }

    //FCT qui met l'objet dans les mains du joueur
    void MoveObject()
    {
        myself.transform.Rotate(0, 0, 0, Space.World);
        myself.transform.position = holdPos.transform.position;
    }



    //Fonction pour lâcher l'objet
    void DropObject()
    {
        isPicked=false;
        Physics.IgnoreCollision(myself.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        myself.layer = 0;
        myselfRigidbody.isKinematic = false;
        myself.transform.parent = null;
        pickUpScript.canInteract = true;
        
    }

   

    //Fonction pour rotate l'objet dans les mains (WIP)
    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {
            fpsController.canMove = false;
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                myself.transform.Rotate(0,90,0,Space.World);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                myself.transform.Rotate(0,-90, 0, Space.World);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                myself.transform.Rotate(0, 0, 90,Space.World);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                myself.transform.Rotate(0, 0,-90, Space.World);
            }

        }
        else
        {
            fpsController.canMove = true;
        }       
       
    }
}
