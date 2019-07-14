using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    float LeanSpeed { get; }

    void ForceTo(Vector2 targetPosition);
}
