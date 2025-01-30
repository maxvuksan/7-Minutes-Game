using System;
using UnityEngine;



[CreateAssetMenu]

public class DialogueSequence : ScriptableObject{
    public DialogueLine[] lines;
}






[System.Serializable]
public class DialogueLine
{
    public DialogueBurst[] bursts;
};

// a part of a sentence
[System.Serializable]
public class DialogueBurst
{
    public String content;
    [Range(0,5)]
    public int timeDelayUntilActive; // pauses dialogue for x amount of time, allows for breathing breaks in lines
    public Color32 dialogueColor;
}