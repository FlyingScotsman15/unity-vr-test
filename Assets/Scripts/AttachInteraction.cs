using System.Collections;
using UnityEngine;

public class AttachInteraction : MonoBehaviour
{
    [SerializeField] Attachable targetAttachable;
    [SerializeField] AudioClip successClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] InstructionData initialInstruction, completedInstruction;
    
    public delegate void OnUpdateInstructions(InstructionData data);
    public static event OnUpdateInstructions onUpdateInstructionData;
    
    void Start()
    {
        StartCoroutine(WaitForAttach());
        onUpdateInstructionData?.Invoke(initialInstruction);
    }

    IEnumerator WaitForAttach()
    {
        while (!targetAttachable.IsAttached)
        {
            yield return null;
        }
        
        onUpdateInstructionData?.Invoke(completedInstruction);
        PlaySuccessAudio();
    }

    void PlaySuccessAudio()
    {
        audioSource.PlayOneShot(successClip);
    }
}
