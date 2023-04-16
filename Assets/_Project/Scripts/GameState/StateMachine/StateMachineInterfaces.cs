using System.Collections;
using System.Collections.Generic;
using StateController;
using UnityEngine;

public interface ICurrentStateHolder
{
    public IState CurrentState { get; set; }
}
