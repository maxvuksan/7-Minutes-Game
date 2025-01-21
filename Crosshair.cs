using Microsoft.Unity.VisualStudio.Editor;
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

    void Awake(){
        SetCrosshairType(Type.DEFAULT);
    }

    public void SetCrosshairType(Type type){

        GetComponentInChildren<UnityEngine.UI.Image>().sprite = crosshairSprites[(int)type];
    }

}
