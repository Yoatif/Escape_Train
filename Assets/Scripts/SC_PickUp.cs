using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    
    public float throwForce = 500f; 
    public float pickUpRange = 5f; 
    private float rotationSensitivity = 1f; 
    private GameObject heldObj; 
    private Rigidbody heldObjRb; 
    private bool canDrop = true; 
    private int LayerNumber; 
    
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("holdLayer"); 

       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (heldObj == null)  // si on ne tient rien on ramasse
            {
                
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))   //On trouve l'objet a coup de raycast
                {
                    
                    if (hit.transform.gameObject.tag == "canPickUp")  //Est-ce un objet interactible ?
                    {
                        
                        PickUpObject(hit.transform.gameObject);  
                    }
                }
            }
            else  // si on tient quelque chose on le lache
            {
                if (canDrop == true) 
                {
                    StopClipping(); 
                    DropObject();
                }
            }
        }
        if (heldObj != null)
        {
            MoveObject();
            RotateObject();
            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true)  // si on clique on lance
            {
                StopClipping();
                ThrowObject();
            }

        }
    }

    //Fonction qui assigne l'objet qu'on veut tenir a nos var
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) 
        {
            heldObj = pickUpObj; 
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); 
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; 
            heldObj.layer = LayerNumber; 
            
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    //Fonction pour l�cher l'objet
    void DropObject()
    {
        
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; 
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; 
        heldObj = null; 
    }
    //Fonction qui replace l'objet au centre de la camera et � la bonne distance
    void MoveObject()
    {
        
        heldObj.transform.position = holdPos.transform.position;
    }

    // Fonction de rotation de l'objet tenu
    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {
            
            
            canDrop = false; //on empeche l'objet de pouvoir �tre lanc�

            
            
            //on fait rotate l'objet selon la souris
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            
            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
        else
        {
           
            
            canDrop = true;
        }
    }

    //Fonction pour lancer l'objet
    void ThrowObject()   
    {
        
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }
    void StopClipping()     //On empeche le clipping de l'objet tenu
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); 
        
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        
        if (hits.Length > 1)
        {
            
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); 
            
        }
    }
}