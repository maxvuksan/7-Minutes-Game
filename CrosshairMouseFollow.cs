using UnityEngine;

public class CrosshairMouseFollow : MonoBehaviour
{
    void Start(){
        
        Cursor.visible = false;
    }

    void Update(){
        transform.position = Input.mousePosition;
    }
}
