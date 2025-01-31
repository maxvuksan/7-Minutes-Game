using System;
using UnityEngine;

public class MoonCrash : MonoBehaviour
{
    public ConversationManager text;
    public HeadMovement cameraScript;

    public GameObject canvas;
    public GameObject particleSystem;
    public GameObject textObject;

    bool disabled = false;


    public void DisableEnding() {
        disabled = true;
    }

    private void Awake() {
        canvas.SetActive(false);
    }

    public void PlayText() {
        if (disabled) return;

        canvas.SetActive(true);
        cameraScript.MoonCrashEnding();
        text.Play();
    }

    public void PlayEnding() {
        if (disabled) return;

        AudioManager.Singleton.Play("Explosion");
        particleSystem.SetActive(true);
        canvas.SetActive(false);
        
    }

    public void EndGame() {
        if (disabled) return;

        textObject.SetActive(false);
        canvas.SetActive(true);
    }
}
