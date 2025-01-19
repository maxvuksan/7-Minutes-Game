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
    float characterDelayTracked = 0;

    bool playingSequence = false;

    String currentLine;
    public TextMeshProUGUI outputLine;



    void Start(){

    }

    void Update(){

        if(!playingSequence){

            lineIndex = 0;
            burstIndex = 0;
            charIndex = 0;
            currentLine = "";
            playingSequence = true;
            characterDelayTracked = 0;
            
        }
        else{
            characterDelayTracked += Time.deltaTime;

            if(characterDelayTracked > characterDelay){

                characterDelayTracked = 0;

                AudioManager.Singleton.Play("WalkieDialogue");

                Step();
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

                if(lineIndex >= activeSequence.lines.Length){
                    playingSequence = false;
                }

            }
            else{
                characterDelayTracked -= activeSequence.lines[lineIndex].bursts[burstIndex].timeDelayUntilActive; // add burst delay
            }
        }



        outputLine.text = currentLine;
    }




}
