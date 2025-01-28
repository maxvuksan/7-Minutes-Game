using UnityEngine;
using UnityEngine.Events;

public class InspectionControl : MonoBehaviour
{
    public string label;
    [SerializeField]
    private UnityEvent onInspect;


    
    public void TriggerControl(){

        onInspect.Invoke();
    }
}
