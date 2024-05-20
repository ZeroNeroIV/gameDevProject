using UnityEngine;
// Mohammad work:
// this code is for making the pirmed routat when the bullet hit the button

public class pushto : MonoBehaviour
{
    public pushto1 one;
    public pushto2 two;
    public pushto3 three;
    public bool good=false;
    //faisal will 
    // Start is called before the first frame update
    void Start()
    {
        one=GameObject.Find($"{gameObject.name}/Arch1/Cone1").GetComponent<pushto1>();
        two=GameObject.Find($"{gameObject.name}/Arch2/Cone2").GetComponent<pushto2>();
        three=GameObject.Find($"{gameObject.name}/Arch3/Cone3").GetComponent<pushto3>();
    }
    // Update is called once per frame
    void Update()
    {
        if(one.done && two.done && three.done){
            good=true;
        }
        else{
            good=false;
        }
    }

}
