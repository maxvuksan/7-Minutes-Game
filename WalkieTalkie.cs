using UnityEngine;

public class WalkieTalkie : MonoBehaviour
{
    
    public GameObject walkieUI;

    void Update()
    {
        
        if(GetComponent<Inspectable>().isInspecting){
            walkieUI.SetActive(true);
        }
        else{
            walkieUI.SetActive(false);
        }
    }
}
