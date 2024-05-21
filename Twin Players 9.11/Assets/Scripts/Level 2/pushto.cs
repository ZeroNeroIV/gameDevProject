using UnityEngine;

// Mohammad work:
// this code is for making the pirmed routat when the bullet hit the button

namespace Level_2
{
    public class PushTo : MonoBehaviour
    {
        public PushTo1 one;
        public PushTo2 two;
        public PushTo3 three;
        public bool good=false;
        //faisal will 
        // Start is called before the first frame update
        void Start()
        {
            one=GameObject.Find($"{gameObject.name}/Arch1/Cone1").GetComponent<PushTo1>();
            two=GameObject.Find($"{gameObject.name}/Arch2/Cone2").GetComponent<PushTo2>();
            three=GameObject.Find($"{gameObject.name}/Arch3/Cone3").GetComponent<PushTo3>();
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
}
