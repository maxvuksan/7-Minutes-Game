using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkieTalkie : MonoBehaviour
{
    


    public Animator extendArmAnimator;
    public GameObject[] objectsToHide;
    public Animator fadeOutAnim;




    public void Respond(){

        for(int i = 0; i < objectsToHide.Length; i++){
            objectsToHide[i].SetActive(false);
        }

        extendArmAnimator.SetTrigger("Extend");
        FindObjectOfType<InteractionManager>().EndInteraction();
        FindAnyObjectByType<HeadMovement>().SetFollowMoon(true);

        Invoke("Shoot", 7.0f);
    }


    public void Shoot(){

        extendArmAnimator.SetTrigger("Shoot");
        FindObjectOfType<MoonDestruction>().Detonate(); 
        AudioManager.Singleton.Play("MoonShoot");

        Invoke("FadeOut", 5.0f);
    }

    public void FadeOut(){
        fadeOutAnim.SetTrigger("FadeOut");
        Invoke("SceneChange", 1.1f);
    }

    public void SceneChange(){
        SceneManager.LoadScene("MainMenu");
    }

}
