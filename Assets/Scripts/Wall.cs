using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public Material eastMaterial;
    public Material wastMaterial;
    public Material southMaterial;
    public Material northMaterial;

    // Use this for initialization
    void Start()
    {
        initComponents();
    }

    void initComponents()
    {
        float angle = transform.rotation.eulerAngles.y;
        if (angle == 0) // north
        {
            ApplyMaterial(northMaterial);
        }
        else if (angle == 90) // east
        {
            ApplyMaterial(eastMaterial);
        }
        else if (angle == 180) // south
        {
            ApplyMaterial(southMaterial);
        }
        else if (angle == 270) // west
        {
            ApplyMaterial(wastMaterial);
        }
        else
        {
            Debug.LogError(" Unexpect wall rotation : " + angle);
        }
    }

    void ApplyMaterial(Material material)
    {
        GetComponent<Renderer>().material = material;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
