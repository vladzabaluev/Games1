using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteract :MonoBehaviour, Interaction
{
    [SerializeField] private Animator _anim;
    [SerializeField] private UnityEvent _events;
    //[SerializeField] private UnityEvent<float> _eventsFloat;
    public bool isWorking = false;
    public void Interact()
    {
        _anim.SetTrigger("Active");
        _events.Invoke();
        if (isWorking)
        this.GetComponent<AudioSource>().Stop();
        else
            this.GetComponent<AudioSource>().Play();
        isWorking = !isWorking;
        //_eventsFloat.Invoke();
    }
}
