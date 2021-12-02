using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer_script : MonoBehaviour
{
    public int number;
    public GameObject cunv;
    public float wait_for_destroy;
    public Material choosen;
    Vector4 Color_green = new Vector4(0f,255f,0f,1f);
    Vector4 Color_red = new Vector4(255f,0f,0f,1f);
    int id;
    GameObject obj;

    public void OnClick(){

            if (number == DataBase.Right){
                id = Clicked.id_st;
                Right(wait_for_destroy);
            } else{
                gameObject.GetComponent<Image>().color = Color_red;
            }
    }

    void Right(float time){
                gameObject.GetComponent<Image>().color = Color_green;
                obj = GameObject.FindGameObjectWithTag((id).ToString());
                var nameRenderer = obj.GetComponent<MeshRenderer>();
                var mats = nameRenderer .sharedMaterials;
                mats [0] = choosen;
                nameRenderer.sharedMaterials = mats;

                obj.GetComponent<Clicked>().id = 0;
                
                DataBase.i = -1;
                Create_question.i = -1;
                Create_question.created = false;
   
        cunv.SetActive(false);


    }
    private void OnDisable()
    {
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
