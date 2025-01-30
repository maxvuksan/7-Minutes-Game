using System;
using TMPro;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    
    public DialogueSequence activeSequence;
    int lineIndex = 0;
    int burstIndex = 0;
    int charIndex = 0;

    public float characterDelay; 
    public float lineDelay;
    public float disapearDelay;
    public float initialDelay;
    float characterDelayTracked = 0;

    bool isActive = false;
    bool playingSequence = false;

    String currentLine;
    public TextMeshProUGUI outputLine;

    public RectTransform background;



    void Start(){
        HideText();
    }

    void Update(){

        if(!playingSequence){

            lineIndex = 0;
            burstIndex = 0;
            charIndex = 0;
            currentLine = "";
            playingSequence = true;
            characterDelayTracked = -initialDelay;
            
        }
        else{
            characterDelayTracked += Time.deltaTime;

            


            if(characterDelayTracked > characterDelay){
                isActive = true;
                ShowText();

                characterDelayTracked = 0;

                AudioManager.Singleton.Play("WalkieDialogue");

                Step();
            } else if (characterDelayTracked > -lineDelay + disapearDelay && !isActive) {
                HideText();
            }
        }
    }

    void Step(){
        
        if(burstIndex == 0 && charIndex == 0){
            currentLine = "";
        }

        currentLine += activeSequence.lines[lineIndex].bursts[burstIndex].content[charIndex];

        

        charIndex++;

        // finished burst
        if(charIndex >= activeSequence.lines[lineIndex].bursts[burstIndex].content.Length){
            burstIndex++;
            charIndex = 0;
        

            if(burstIndex >= activeSequence.lines[lineIndex].bursts.Length){
                burstIndex = 0;
                lineIndex++;
                characterDelayTracked -= lineDelay;
                isActive = false;

                if(lineIndex >= activeSequence.lines.Length){
                    playingSequence = false;
                }

            }
            else{
                characterDelayTracked -= activeSequence.lines[lineIndex].bursts[burstIndex].timeDelayUntilActive; // add burst delay
            }
        }

        outputLine.text = currentLine;

        Vector2 textSize = outputLine.GetRenderedValues(true);
        background.sizeDelta = new Vector2(textSize.x + 50f, textSize.y + 30f);
    }

    private void HideText() {
        background.gameObject.SetActive(false);
        outputLine.gameObject.SetActive(false);
    }

    private void ShowText() {
        background.gameObject.SetActive(true);
        outputLine.gameObject.SetActive(true);
    }


}
