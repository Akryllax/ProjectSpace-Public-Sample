using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractuable : MonoBehaviour
{
    public virtual void Interact(BaseInteractor interactor) { }
}
