using System.Collections;
using UnityEngine;

public class AttachInteraction : MonoBehaviour
{
    [SerializeField] Attachable targetAttachable;
    [SerializeField] AudioClip successClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] InstructionData initialInstruction, completedInstruction;
    [SerializeField] UIPanelController uiController;
    
    void Start()
    {
        StartCoroutine(WaitForAttach());
        uiController.SetInstructions(initialInstruction);
    }

    IEnumerator WaitForAttach()
    {
        while (!targetAttachable.IsAttached)
        {
            yield return null;
        }
        
        PlaySuccessAudio();
        uiController.SetInstructions(completedInstruction);
    }

    void PlaySuccessAudio()
    {
        audioSource.PlayOneShot(successClip);
    }
}
