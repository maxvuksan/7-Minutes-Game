using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioClip[] soundLoops;
    public AudioSource source;
    int currentIndex = 0;
    bool isOn = false;


    private float timePassed = 0;

    private void Update() {
        timePassed += Time.deltaTime;
    }

    public void NextSong() {
        isOn = true;

        currentIndex++;

        if (currentIndex >= soundLoops.Length) {
            currentIndex = 0;
        }

        source.clip = soundLoops[currentIndex];
        source.time = timePassed % source.clip.length;
        source.Play();
    }

    public void PowerButton() {
        if (isOn) {
            source.Stop();
            isOn = false;
        } else {
            source.time = timePassed % source.clip.length;
            source.Play();
            isOn = true;
        }
    }



}
