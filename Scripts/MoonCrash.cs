using System;
using UnityEngine;

public class MoonCrash : MonoBehaviour
{
    public ConversationManager text;
    public HeadMovement cameraScript;

    public GameObject canvas;
    public GameObject particleSystem;
    public GameObject textObject;

    private void Awake() {
        canvas.SetActive(false);
    }

    public void PlayText() {
        canvas.SetActive(true);
        cameraScript.MoonCrashEnding();
        text.Play();
    }

    public void PlayEnding() {
        AudioManager.Singleton.Play("Explosion");
        particleSystem.SetActive(true);
        canvas.SetActive(false);
        
    }

    public void EndGame() {
        textObject.SetActive(false);
        canvas.SetActive(true);
    }
}
