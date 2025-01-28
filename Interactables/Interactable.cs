using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  
    Base class for interactable objects, 
    objects with this class should be a collider 
*/
public class Interactable : MonoBehaviour
{
    public string label;                // what will be displayed when hovering
    public bool persistentInteraction = true;   // does the interaction persist after OnInteract() ?
    [HideInInspector] public bool interactionEnabled = true;

    public InspectionControl[] controls; // can be empty

    // should be overridden to provide interaction logic
    public virtual void OnInteract(){

        
    }

    public virtual void OnInteract(InteractionManager interactionManager){
        
        
        
    }


    public virtual void EndPersistentInteraction(InteractionManager interactionManager){

    }

}
