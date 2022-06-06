using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPC_State
{
    public INPC_State ChangeState(NPC_Controller npc);
}