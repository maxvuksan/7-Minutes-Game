using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControlPointTracker : MonoBehaviour
{
    private List<RectTransform> controlPoints;
    private Transform previousInspectableModel;

    public static ControlPointTracker Singleton;

    // Boolean to track if the mouse is hovering over any control point
    private bool isMouseHoveringControlPoint = false;

    public Sprite normalSprite;
    public Sprite hoveredSprite;

    void Awake()
    {
        Singleton = this;

        controlPoints = new List<RectTransform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            controlPoints.Add(transform.GetChild(i).GetComponent<RectTransform>());
        }
    }

    private void DisableControlPoints()
    {
        isMouseHoveringControlPoint = false;
        for (int i = 0; i < controlPoints.Count; i++)
        {
            controlPoints[i].GetChild(0).gameObject.SetActive(false);
            controlPoints[i].gameObject.SetActive(false);
        }
    }

    public void UpdateControlPoints(Interactable inspectableModel)
    {
        if (inspectableModel == null)
        {
            DisableControlPoints();
            return;
        }

        if (inspectableModel.transform != previousInspectableModel)
        {
            DisableControlPoints();
        }
        previousInspectableModel = inspectableModel.transform;

        InspectionControl[] controls = inspectableModel.controls;

        isMouseHoveringControlPoint = false;

        for (int i = 0; i < controls.Length; i++)
        {
            controlPoints[i].gameObject.SetActive(true);

            Vector3 screenPos = Camera.main.WorldToScreenPoint(controls[i].transform.position);
            controlPoints[i].localPosition =
                new Vector3(screenPos.x, screenPos.y, 0);



            if (IsMouseOverControlPoint(controlPoints[i]))
            {
                controlPoints[i].GetChild(0).gameObject.SetActive(true);
                controlPoints[i].GetComponentInChildren<TextMeshProUGUI>(true).text = controls[i].label;
                controlPoints[i].GetComponent<UnityEngine.UI.Image>().sprite = hoveredSprite;
                isMouseHoveringControlPoint = true;

                if(Input.GetMouseButtonDown((int)MouseButton.Left)){
                    AudioManager.Singleton.Play("ControlBeep");
                    controls[i].TriggerControl();
                }


            }
            else
            {
                controlPoints[i].GetChild(0).gameObject.SetActive(false);
                controlPoints[i].GetComponent<UnityEngine.UI.Image>().sprite = normalSprite;
            }
        }
    }


    private bool IsMouseOverControlPoint(RectTransform rectTransform)
    {
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);
        return rectTransform.rect.Contains(localMousePosition);
    }

    public bool IsMouseHoveringControlPoint()
    {
        return isMouseHoveringControlPoint;
    }
}
