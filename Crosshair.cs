
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    
    public enum Type{

        DEFAULT,
        POINTER,
        ZOOM,
        OPEN_HAND,

    }

    public Sprite[] crosshairSprites;
    private ControlPointTracker controlPointTracker;

    Type type;

    void Awake(){
        SetCrosshairType(Type.DEFAULT);
    }

    void Start(){
        controlPointTracker = FindObjectOfType<ControlPointTracker>();
    }

    public void SetCrosshairType(Type _type){

        type = _type;

    }

    public void Update(){
        
        if(controlPointTracker == null)
        {
            return;
        }

        if(controlPointTracker.IsMouseHoveringControlPoint()){
            GetComponentInChildren<UnityEngine.UI.Image>().sprite = crosshairSprites[(int)Type.POINTER];
        }
        else{
            GetComponentInChildren<UnityEngine.UI.Image>().sprite = crosshairSprites[(int)type];
        }
    }

}
