using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerMachine : MonoBehaviour
{
    public Animator frontAnim;
    public Animator endAnim;
    ButtonInteract buttonInteract;
    // Start is called before the first frame update
    void Start()
    {
        buttonInteract = GetComponent<ButtonInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonInteract.isWorking)
        {
            frontAnim.SetBool("isWork", true);
            endAnim.SetBool("isWork", true);
        }
        else
        {
            frontAnim.SetBool("isWork", false);
            endAnim.SetBool("isWork", false);
        }
    }
}
