using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour
{
    Vector3 startingPosition;
    Quaternion startingRotation;

    void Start()
    {
        var transform = this.transform;
        startingPosition = transform.position;
        startingRotation = transform.rotation;
    }

    public void ResetToStartPosition() => transform.SetPositionAndRotation(startingPosition, startingRotation);
}