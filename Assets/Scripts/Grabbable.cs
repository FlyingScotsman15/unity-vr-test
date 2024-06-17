using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Grabbable : MonoBehaviour
{
    Rigidbody rigidBody;
    Collider grabbableCollider;
    HandController currentHoldingHand;
    bool isHeld;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        grabbableCollider = GetComponent<Collider>();
    }

    public bool IsHeld() => isHeld;

    public void SetGrabbableEnabled(bool isEnabled)
    {
        grabbableCollider.enabled = isEnabled;
    }

    public void SetHoldingHand(HandController holdingHand)
    {
        if (currentHoldingHand && currentHoldingHand != holdingHand)
        {
            currentHoldingHand.EnableHandRenderer();
        }
        currentHoldingHand = holdingHand;
    }

    public void Grab(HandController holdingHand)
    {
        currentHoldingHand = holdingHand;
        rigidBody.isKinematic = true;
        transform.SetParent(currentHoldingHand.transform);
        isHeld = true;
    }

    public void Release(HandController releasingHand)
    {
        if (releasingHand != currentHoldingHand) return;
        rigidBody.isKinematic = false; 
        transform.SetParent(null);
        isHeld = false;
    }
}
