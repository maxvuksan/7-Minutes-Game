using UnityEngine;

public class WalkieTalkie : MonoBehaviour
{
    


    public Animator extendArmAnimator;
    public GameObject armToHide;




    public void Respond(){

        armToHide.SetActive(false);

        extendArmAnimator.SetTrigger("Extend");
        FindObjectOfType<InteractionManager>().EndInteraction();
        FindAnyObjectByType<HeadMovement>().SetFollowMoon(true);
    }

}
