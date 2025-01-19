using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{

    public LayerMask interactableLayer;    // what collision layer is the interactables on?
    public float interactionRange = 5;         // how far can thhe player reach?
    public TextMeshProUGUI interactionText;

    public Transform inspectionTransform;
    public Animator crosshairAnimator;

    static InteractionManager instance;

    private Interactable currentInteraction;

    static bool shouldPanAnchor;
    

    // when inspecting
    public static void SetShouldPanAnchor(bool state){
        shouldPanAnchor = state;

        if(!state){
            instance.inspectionTransform.localRotation = Quaternion.Euler(0,0,0);

            //HeadMovement.SetRotation()
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * interactionRange);
    }


    void Start(){
        instance = this;
    }

    private void FixedUpdate() {

        if(shouldPanAnchor){
            Vector3 mousePosition = Input.mousePosition;

            float normalizedX = (mousePosition.x / Screen.width) * 2 - 1;
            float normalizedY = (mousePosition.y / Screen.height) * 2 - 1;

            instance.inspectionTransform.localRotation = Quaternion.Euler(normalizedY * 45, normalizedX * -45,0);

        
            HeadMovement.rotationOffsetX = Mathf.Lerp(HeadMovement.rotationOffsetX, -normalizedY * 3.0f, 0.2f);
            HeadMovement.rotationOffsetY = Mathf.Lerp(HeadMovement.rotationOffsetY, normalizedX * 3.0f, 0.2f);     

            
        }
        else{
                    
            HeadMovement.rotationOffsetX = 0; Mathf.Lerp(HeadMovement.rotationOffsetX, 0, 0.2f);
            HeadMovement.rotationOffsetY = 0; Mathf.Lerp(HeadMovement.rotationOffsetY, 0, 0.2f);    
        }
    }

    private void Update(){
        

        if(currentInteraction == null){
            InteractionDetection();
        }
        else{
            interactionText.text = "";

            // exit interaction

            if(Input.GetKey(KeyCode.Escape)){
                currentInteraction.EndPersistentInteraction(this);
                currentInteraction = null;
            }
        }
    }

    void InteractionDetection(){

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, interactionRange, interactableLayer)){

            crosshairAnimator.SetBool("Hovered", true);

            Interactable inter = hit.collider.gameObject.GetComponent<Interactable>();

            if(inter != null){

                interactionText.text = inter.label;

                if(inter.interactionEnabled){
                    
                    // trigger interaction on key press
                    if(Input.GetKeyDown(KeyCode.E)){

                        inter.OnInteract();
                        inter.OnInteract(this);


                        if(inter.persistentInteraction){
                            // hold onto interaction
                            currentInteraction = inter;
                        }
                        else{
                            currentInteraction = null;
                        }
                    }
                }
            }

        }
        else{
            crosshairAnimator.SetBool("Hovered", false);
            interactionText.text = "";
        }
    }

}

