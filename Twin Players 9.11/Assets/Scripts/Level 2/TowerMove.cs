using UnityEngine;
using UnityEngine.Serialization;

namespace Level_2
{
    public class TowerMove : MonoBehaviour
    {
        public bool go;
        private const float MoveSpeed = 10.0f;
        private const float YPosUp = 125.3f;
        private const float YPosDown = 67.8f;
        private void Update()
        {
            var yPos = transform.position.y;
            if (go)
            {
                if(yPos > YPosDown)
                    TowerDown();
            }
            else{
                if(yPos < YPosUp)
                    TowerUp();
            }
        }
        // Apply the upward movement to the tower
        private void TowerUp() => transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
        // Apply the downward movement to the tower
        private void TowerDown() => transform.Translate(0, -MoveSpeed * Time.deltaTime, 0);
    }
}
