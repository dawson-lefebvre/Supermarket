using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameProgressionManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI objectiveText;

    private void Start()
    {
        objectiveText.text = "Objective:\nGo inside.";
        Application.targetFrameRate = 60;
    }

    [SerializeField] GameObject WindowInteract;

    public void FinishDoorSequence()
    {
        objectiveText.text = "Objective:\nFind another way in.";
        WindowInteract.SetActive(true);
    }

    public void EnterWindow()
    {
        objectiveText.text = "Objective:\nCheck the cameras.";
    }

    [SerializeField] GameObject finalScareObject;
    public void ActivateFinalScare()
    {
        finalScareObject.SetActive(true);
        objectiveText.text = "Objective:\nDon't look back.";
    }
}
