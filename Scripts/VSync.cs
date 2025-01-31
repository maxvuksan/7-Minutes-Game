using UnityEngine;
using UnityEngine.UI;

public class VSync : MonoBehaviour
{
    private bool isEnabled = true;
    public Image sprite;

    public Sprite ticked;
    public Sprite unticked;

    public void Awake() {
        QualitySettings.vSyncCount = 1;
        sprite.sprite = ticked;    
    }

    public void Toggle() {
        isEnabled = !isEnabled;
        
        if (isEnabled) {
            QualitySettings.vSyncCount = 1;
            sprite.sprite = ticked;    
        } else {
            QualitySettings.vSyncCount = 0;
            sprite.sprite = unticked;
        }
    }
}
