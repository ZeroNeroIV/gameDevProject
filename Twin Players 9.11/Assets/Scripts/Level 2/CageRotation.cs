using UnityEngine;

namespace Level_2
{
    public class CageRotation : MonoBehaviour
    {
        private readonly Vector3 _cageRotation = new(8f, 14f, 5f);
        private void Update() => transform.Rotate(_cageRotation * Time.deltaTime);
    }
}
