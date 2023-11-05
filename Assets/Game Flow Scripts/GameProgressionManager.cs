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
    }

    [SerializeField] GameObject WindowInteract;

    public void FinishDoorSequence()
    {
        objectiveText.text = "Objective:\nFind another way in.";
        WindowInteract.SetActive(true);
    }

    public void EnterWindow()
    {
        WindowInteract.SetActive(false);
        objectiveText.text = "Objective:\nCheck the cameras.";
    }
}
