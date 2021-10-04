using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamOfMaterial : MonoBehaviour
{
    Material nuclearMaterial;
    Shader nuclearShader;
    public NuclearController reactor;

    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        nuclearMaterial = GetComponent<MeshRenderer>().material;
        nuclearShader = nuclearMaterial.shader;
    }

    // Update is called once per frame
    void Update()
    {
        if (reactor.health > 0)
        {
            currentHealth = 1 - reactor.health / reactor.maxHealth;
            nuclearMaterial.SetFloat("_CurrentColor", currentHealth);
            nuclearMaterial.SetFloat("_RipleSpeed", 5 + (15 - 5) * currentHealth);
        }

        //nuclearMaterial.SetFloat("_NumberOfCells", 15);
    }

}
