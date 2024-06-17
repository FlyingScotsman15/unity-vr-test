using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionText;
    [SerializeField] Image instructionImage;

    void OnEnable() => AttachInteraction.onUpdateInstructionData += SetInstructions;

    void OnDisable() => AttachInteraction.onUpdateInstructionData -= SetInstructions;

    void SetInstructions(InstructionData instructionData)
    {
        instructionImage.sprite = instructionData.instructionImage;
        instructionText.text = instructionData.instructionText;
    }
}