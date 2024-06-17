using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionText;
    [SerializeField] Image instructionImage;

    public void SetInstructions(InstructionData instructionData)
    {
        instructionImage.sprite = instructionData.instructionImage;
        instructionText.text = instructionData.instructionText;
    }
}