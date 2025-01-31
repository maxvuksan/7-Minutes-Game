using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float time = 38;
    private float timePassed;
    public TextMeshProUGUI text;


    private void Update() {
        timePassed += Time.deltaTime;
        if (timePassed >= 60) {
            UpdateText();
            timePassed = 0;
        }
    }

    private void UpdateText() {
        time++;
        text.text = "09:" + time;
    }


}
