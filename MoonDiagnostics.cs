using UnityEngine;
using UnityEngine.UI;

public class MoonDiagnostics : MonoBehaviour
{
    public RectTransform[] crosshairPieces; // should be 4 elements
    public MoonDiagnostics Singleton;
    public bool enabled = false; 
    
    public Transform moonPosition;

    private void Awake() {
        Singleton = this;    
    }

    void Update(){

        if(enabled){
            for(int i = 0; i < crosshairPieces.Length; i++){
                crosshairPieces[i].gameObject.SetActive(true);
            }


            Vector3 screenPos = Camera.main.WorldToScreenPoint(moonPosition.position);
            
            Vector3 targetPosition =
                new Vector3(screenPos.x, screenPos.y, 0);

            float scaleOffset = 1.0f;




        }
        else{
            for(int i = 0; i < crosshairPieces.Length; i++){
                crosshairPieces[i].gameObject.SetActive(false);
            }
        }
    }
}
