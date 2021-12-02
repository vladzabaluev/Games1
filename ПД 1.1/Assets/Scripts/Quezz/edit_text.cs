using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class edit_text : MonoBehaviour
{
    public Text question, answer1, answer2, answer3;
    [SerializeField] private UnityEvent<bool> _event;

    private void OnEnable()
    {
        question.text = DataBase.Cur_question;
        answer1.text = DataBase.Cur_answers[0];
        answer2.text = DataBase.Cur_answers[1];
        answer3.text = DataBase.Cur_answers[2];
    }

    private void OnDisable()
    {
        _event.Invoke(true);
    }
}
