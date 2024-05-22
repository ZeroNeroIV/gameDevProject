using UnityEngine;

namespace Level_2
{
    public class TowerMove : MonoBehaviour
    {
        //Start is called before the first frame update
        public bool go=false;
        public float moveSpeed = 1.0f;
        public float y_pos_up=131.3f;
        public float y_pos_down=67.8f;
        void Start()
        {
        
        }
        // Update is called once per frame
        void Update()
        {
            float yPos = transform.position.y;
            if(go){
                if(yPos>y_pos_down)
                    TowerDown();
            }
            else{
                if(yPos<y_pos_up)
                    TowerUp();
            }
        }
        public void TowerDown()
        {
            // Calculate the downward movement for this frame
            float moveAmount = moveSpeed * Time.deltaTime;
            // Apply the downward movement to the tower
            transform.Translate(0, -moveAmount, 0);
        }
        public void TowerUp()
        {

            // Calculate the downward movement for this frame
            float moveAmount = moveSpeed * Time.deltaTime;
            // Apply the downward movement to the tower
            transform.Translate(0, moveAmount, 0);
        }
    }
}
