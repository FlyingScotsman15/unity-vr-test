using UnityEngine;

[RequireComponent(typeof(Grabbable))]
public class Attachable : MonoBehaviour
{
    public bool IsAttached;
    
    [Tooltip("This is the object you are attaching this object to")]
    [SerializeField] Transform attachTargetTransform;
    [Tooltip("This is the point on this object you are using as the connection to the intended attach target")]
    [SerializeField] Transform connectionPointTransform;
    [SerializeField] private AttachDistance attachDistance;
    bool isCurrentlyHeld;
    Grabbable grabbable;

    private void Start() => grabbable = GetComponent<Grabbable>();

    void Update()
    {
        if (!IsAbleToAttach()) return;
        AttachToTarget();
    }

    private void AttachToTarget()
    {
        transform.SetParent(attachTargetTransform);
        grabbable.SetHoldingHand(null);
        grabbable.SetGrabbableEnabled(false);
        IsAttached = true;
    }

    private bool IsAbleToAttach()
    {
        return grabbable.IsHeld() && Vector3.Distance(attachTargetTransform.position, connectionPointTransform.position) < attachDistance.attachDistance;
    }
}