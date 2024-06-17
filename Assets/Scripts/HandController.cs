using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    [SerializeField] private XRNode xrNode;
    InputDevice handInputDevice;
    float gripTriggerValue;
    bool gripTriggerIsHeld;

    void Start() => handInputDevice = InputDevices.GetDeviceAtXRNode(xrNode);

    void Update() => CheckGripInput();

    private void CheckGripInput()
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

    void OnGrab()
    {
        Debug.Log("Grabbed");
    }

    void OnRelease()
    {
        Debug.Log("Released");
    }
}
