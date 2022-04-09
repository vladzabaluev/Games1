using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPS_State
{
    INPS_State ChangeState(NPS_StateController nps);
}