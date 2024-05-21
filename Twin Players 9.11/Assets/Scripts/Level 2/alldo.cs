using UnityEngine;

namespace Level_2
{
    public class AllDo : MonoBehaviour
    {
        public StepOver st;
        public TowerMove T;
        public PushTo pt;
        // Start is called before the first frame update
        void Start()
        {
            st=GameObject.Find($"{gameObject.name}/AllOfThem/Pressure_Plate").GetComponent<StepOver>();
            T=GameObject.Find($"{gameObject.name}/AllOfThem/Solution_Pillar").GetComponent<TowerMove>();
            pt=GameObject.Find($"{gameObject.name}/AllOfThem/Arches").GetComponent<PushTo>();
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
}
