using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public bool switchSceneAfterTime = false;
    public float timeUntilSwitch = 10.0f;   
    public string sceneName;

    void Start(){
        if(switchSceneAfterTime){
            Invoke("SwitchScene", timeUntilSwitch);
        }
    }

    public void SwitchScene(){
        SceneManager.LoadScene(sceneName);
    }
}
