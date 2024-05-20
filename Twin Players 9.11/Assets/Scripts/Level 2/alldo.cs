using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alldo : MonoBehaviour
{
    public stepover st;
    public towermove T;
    public pushto pt;
    // Start is called before the first frame update
    void Start()
    {
        st=GameObject.Find($"{gameObject.name}/AllOfThem/Pressure_Plate").GetComponent<stepover>();
        T=GameObject.Find($"{gameObject.name}/AllOfThem/Solution_Pillar").GetComponent<towermove>();
        pt=GameObject.Find($"{gameObject.name}/AllOfThem/Arches").GetComponent<pushto>();
    }

    // Update is called once per frame
    void Update()
    {
        if(st.isubove && pt.good){
            T.go=true;
        }
        else{
            T.go=false;
        }
    }
}
