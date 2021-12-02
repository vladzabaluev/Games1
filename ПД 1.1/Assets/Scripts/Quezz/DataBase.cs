using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [System.Serializable]
    public struct Answers{
        public string question;
        public string[] answerers; 
        public int right_answer;
    }

    public static string Cur_question;
    public static string[] Cur_answers = new string[3];
    public static int Right;
    public static int i = -1;

    public Answers[] answer = new Answers[3];


    public GameObject _canvas;
    void Update(){
        //if (i!=-1 && !Create_question.created)
        //{
        //    Cur_question = answer[i].question;
        //    for(int j=0; j<=2;j++)
        //        Cur_answers[j] = answer[i].answerers[j];
        //    Right = answer[i].right_answer;
        //    Debug.Log(i);
        //    Create_question.i = i;
        //}
        if (i != -1 && !_canvas.gameObject.activeSelf)
        {
            Cur_question = answer[i].question;
            for (int j = 0; j <= 2; j++)
                Cur_answers[j] = answer[i].answerers[j];
            Right = answer[i].right_answer;
            _canvas.SetActive(true);
        }
    }
}
