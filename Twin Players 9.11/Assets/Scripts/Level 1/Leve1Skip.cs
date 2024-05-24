using UnityEngine;

namespace Level_1
{
    public class Leve1Skip : MonoBehaviour
    {
        private void Start() => Destroy(gameObject, 5f);
    }
}
