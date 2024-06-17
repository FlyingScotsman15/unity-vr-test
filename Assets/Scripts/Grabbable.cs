using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
    Rigidbody rigidBody;
    private HandController currentHoldingHand;

    void Start() => rigidBody = GetComponent<Rigidbody>();

    public void Grab(HandController holdingHand)
    {
        currentHoldingHand = holdingHand;
        rigidBody.isKinematic = true;
        transform.SetParent(currentHoldingHand.transform);
    }

    public void Release()
    {
        rigidBody.isKinematic = true; // for testing
        transform.SetParent(null);
    }
}
