using System.Collections;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public GameObject blackScreen;
    public Animator animator;
    public SceneSwap sceneSwap;

    public void Play() {
        blackScreen.SetActive(true);
        animator.SetBool("play", true);
        
        StartCoroutine(SwitchScene());
    }

    IEnumerator SwitchScene() {
        yield return new WaitForSeconds(1);

        sceneSwap.SwitchScene();
    }


}
