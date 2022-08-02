using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    public IPlayerState DoState(StateController playerStateController);

    public void InitializedState(StateController playerStateController);
}