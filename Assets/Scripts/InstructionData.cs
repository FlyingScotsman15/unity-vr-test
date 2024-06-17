using UnityEngine;

[CreateAssetMenu(fileName = "New Instruction Data", menuName = "ScriptableObjects/Create New Instruction Data", order = 2)]
public class InstructionData : ScriptableObject
{
    public Sprite instructionImage;
    public string instructionText;
}