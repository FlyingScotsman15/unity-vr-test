using System;
using UnityEngine;

[RequireComponent(typeof(Grabbable))]
public class Attachable : MonoBehaviour
{
    public bool IsAttached;
    
    [Tooltip("This is the object you are attaching this object to")]
    [SerializeField] Transform attachTargetTransform;
    [Tooltip("This is the point on this object you are using as the connection to the intended attach target")]
    [SerializeField] Transform connectionPointTransform;
    bool isCurrentlyHeld;
    Grabbable grabbable;

    private void Start() => grabbable = GetComponent<Grabbable>();

    void Update()
    {
        if (IsAbleToAttach())
        {
            transform.SetParent(attachTargetTransform);
            grabbable.SetHoldingHand(null);
            IsAttached = true;
        }
    }

    private bool IsAbleToAttach()
    {
        return grabbable.IsHeld() && Vector3.Distance(attachTargetTransform.position, connectionPointTransform.position) < 0.01f;
    }
}
