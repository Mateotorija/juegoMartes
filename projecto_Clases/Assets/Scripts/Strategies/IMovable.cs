using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    #region PROPERTIES
    float MovementSpeed { get; }
    #endregion

    #region KEY_BINDING
    KeyCode MoveForward { get; }
    KeyCode MoveBackward { get; }
    KeyCode MoveRight { get; }
    KeyCode MoveLeft { get; }
    #endregion

    #region METHODS
    void Move(Vector3 direction);
    #endregion
}
