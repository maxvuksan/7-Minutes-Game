using System;
using UnityEngine;

public class MoonCrash : MonoBehaviour
{
    public ConversationManager text;
    public HeadMovement cameraScript;

    public GameObject canvas;

    private void Awake() {
        canvas.SetActive(false);
    }

    public void PlayText() {
        canvas.SetActive(true);
        cameraScript.MoonCrashEnding();
        text.Play();
    }

    public void PlayEnding() {
        canvas.SetActive(false);
        
    }
}
