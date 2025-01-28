using Unity.VisualScripting;
using UnityEngine;

public class Inspectable : Interactable
{
    private Transform originalTransform;
    public Transform inspectableItem;
    private MeshFilter inspectableItemMeshFilter;

    public Transform targetTransform;
    public Vector3 inspectedRotation;

    public Mesh lowdetailMesh;
    private Mesh highdetailMesh;

    public bool isInspecting = false;
    public float distanceFromCamera = 0.5f; // how far is the object from players face
    public bool canZoom = false;
    public float distanceFromCameraWhenZooming = 0.5f; // how far is the object from players face
    private float currDistance = 0.5f;
    public float zoomMovementScaler = 1.3f;

    void Start()
    {

        inspectableItemMeshFilter = inspectableItem.GetComponent<MeshFilter>();

        if(inspectableItemMeshFilter != null){
            highdetailMesh = GetComponentInChildren<MeshFilter>().mesh;
        }

        if(lowdetailMesh != null){
            inspectableItem.GetComponent<MeshFilter>().mesh = lowdetailMesh;
        }

        originalTransform = transform;
        currDistance = distanceFromCamera;
    }


    public override void OnInteract(InteractionManager interactionManager){

        isInspecting = true;

        if(inspectableItemMeshFilter != null){
            inspectableItemMeshFilter.mesh = highdetailMesh;

        }

        if(canZoom){
            FindAnyObjectByType<Crosshair>().SetCrosshairType(Crosshair.Type.ZOOM);
        }
        else{
            FindAnyObjectByType<Crosshair>().SetCrosshairType(Crosshair.Type.OPEN_HAND);
        }
        
        HeadMovement.SetDisableMovement(true);
        InteractionManager.SetShouldPanAnchor(true);

        interactionManager.inspectionTransform.localPosition = new Vector3(0, 0, distanceFromCamera);

        inspectableItem.transform.parent = interactionManager.inspectionTransform;

        targetTransform.transform.parent = interactionManager.inspectionTransform;
        targetTransform.localPosition = Vector3.zero;
        targetTransform.localRotation = Quaternion.Euler(inspectedRotation.x, inspectedRotation.y, inspectedRotation.z);
    }


    public override void EndPersistentInteraction(InteractionManager interactionManager){

        isInspecting = false;

        if(inspectableItemMeshFilter != null && lowdetailMesh != null){
            inspectableItemMeshFilter.mesh = lowdetailMesh;
        }

        HeadMovement.SetDisableMovement(false);
        InteractionManager.SetShouldPanAnchor(false);

        inspectableItem.transform.parent = originalTransform;

        targetTransform.transform.parent = originalTransform;
        targetTransform.localPosition = Vector3.zero;
        targetTransform.localRotation = Quaternion.Euler(0,0,0);
    }

    void Update(){

        if(isInspecting){

            if(canZoom){
                if(Input.GetMouseButton((int)MouseButton.Left)){

                    Vector3 mousePosition = Input.mousePosition;

                    float normalizedX = (mousePosition.x / Screen.width) * 2 - 1;
                    float normalizedY = (mousePosition.y / Screen.height) * 2 - 1;

                    currDistance = Mathf.Lerp(currDistance, distanceFromCameraWhenZooming, 0.1f);
                    targetTransform.localPosition = Vector3.Lerp(targetTransform.localPosition, 
                                                                new Vector3(normalizedX * -distanceFromCameraWhenZooming * zoomMovementScaler, 
                                                                            normalizedY * -distanceFromCameraWhenZooming * zoomMovementScaler), 0.1f);
                }
                else{
                    currDistance = Mathf.Lerp(currDistance, distanceFromCamera, 0.1f);
                    targetTransform.localPosition = Vector3.Lerp(targetTransform.localPosition, Vector3.zero, 0.1f);
                }
            }
            else{
                currDistance = distanceFromCamera;
                targetTransform.localPosition = Vector3.zero;
            }

            GameObject.FindAnyObjectByType<InteractionManager>().inspectionTransform.localPosition = new Vector3(0, 0, currDistance);
        }

        inspectableItem.position = Vector3.Lerp(inspectableItem.position, targetTransform.position, 0.1f);
        inspectableItem.localRotation = Quaternion.Euler(Quaternion.Lerp(inspectableItem.localRotation, targetTransform.localRotation, 0.1f).eulerAngles);

    }

}
