using UnityEngine;

public class Inspectable : Interactable
{
    private Transform originalTransform;
    public Transform inspectableItem;
    public Transform targetTransform;
    public Vector3 inspectedRotation;

    public float distanceFromCamera = 0.5f; // how far is the object from players face

    void Start()
    {
        originalTransform = transform;
    }


    public override void OnInteract(InteractionManager interactionManager){
        
        HeadMovement.SetDisableMovement(true);
        InteractionManager.SetShouldPanAnchor(true);

        interactionManager.inspectionTransform.localPosition = new Vector3(0, 0, distanceFromCamera);

        inspectableItem.transform.parent = interactionManager.inspectionTransform;

        targetTransform.transform.parent = interactionManager.inspectionTransform;
        targetTransform.localPosition = Vector3.zero;
        targetTransform.localRotation = Quaternion.Euler(inspectedRotation.x, inspectedRotation.y, inspectedRotation.z);
    }


    public override void EndPersistentInteraction(InteractionManager interactionManager){

        HeadMovement.SetDisableMovement(false);
        InteractionManager.SetShouldPanAnchor(false);

        inspectableItem.transform.parent = originalTransform;

        targetTransform.transform.parent = originalTransform;
        targetTransform.localPosition = Vector3.zero;
        targetTransform.localRotation = Quaternion.Euler(0,0,0);
    }

    void Update(){

        inspectableItem.position = Vector3.Lerp(inspectableItem.position, targetTransform.position, 0.1f);
        inspectableItem.localRotation = Quaternion.Euler(Quaternion.Lerp(inspectableItem.localRotation, targetTransform.localRotation, 0.1f).eulerAngles);

    }

}
