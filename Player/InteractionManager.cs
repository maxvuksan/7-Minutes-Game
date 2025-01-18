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

    private Interactable currentInteraction;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * interactionRange);
    }


    void Update(){

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

