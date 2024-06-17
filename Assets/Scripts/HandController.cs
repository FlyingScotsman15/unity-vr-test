using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    [SerializeField] XRNode xrNode;
    InputDevice handInputDevice;
    float gripTriggerValue;
    bool gripTriggerIsHeld;
    Grabbable currentlyTouchingObject, currentlyHeldObject;

    void Start() => handInputDevice = InputDevices.GetDeviceAtXRNode(xrNode);

    void Update() => CheckGripInput();

    void CheckGripInput()
    {
        var wasHeldPreviously = gripTriggerIsHeld;

        if (handInputDevice.TryGetFeatureValue(CommonUsages.grip, out gripTriggerValue) && gripTriggerValue > 0.8f)
        {
            gripTriggerIsHeld = true;
        }
        else
        {
            gripTriggerIsHeld = false;
        }

        if (!wasHeldPreviously && gripTriggerIsHeld)
        {
            OnGrab();
        }

        if (wasHeldPreviously && !gripTriggerIsHeld)
        {
            OnRelease();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Grabbable>(out var grabbable)) return;
        currentlyTouchingObject = grabbable;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Grabbable>(out var grabbable) && grabbable == currentlyTouchingObject)
            currentlyTouchingObject = null;
    }
    
    void OnGrab()
    {
        if (!currentlyTouchingObject) return;
        currentlyHeldObject = currentlyTouchingObject;
        currentlyHeldObject.Grab(this);
    }

    void OnRelease()
    {
        if (!currentlyHeldObject) return;
        currentlyHeldObject.Release();
        currentlyHeldObject = null;
    }
}
