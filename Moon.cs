using UnityEngine;

public class Moon : MonoBehaviour
{
    

    public float xRotSpeed;
    public float yRotSpeed;
    public float zRotSpeed; 


    public float globalRotationSpeed;
    public float globalRotationScaler = 0.995f; // scales each frame
    public AudioSource impactAudio;
    public AnimationCurve cameraShakeCurve;
    
    public void FixedUpdate() {
        

        globalRotationSpeed *= globalRotationScaler;
    }

    public void Update(){
        transform.Rotate(new Vector3(xRotSpeed * globalRotationSpeed, yRotSpeed * globalRotationSpeed, zRotSpeed * globalRotationSpeed));
    }

    public void TriggerImpactAudio(){
        impactAudio.Play();
    }

    public void BeginCameraShake(){
        
    }


}
