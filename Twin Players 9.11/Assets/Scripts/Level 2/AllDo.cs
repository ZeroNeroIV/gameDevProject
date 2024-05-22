using UnityEngine;

namespace Level_2
{
    public class AllDo : MonoBehaviour
    {
        [SerializeField] private GameObject tower; // Reference to the tower GameObject
        private const float PillarLowerSpeed = 2f; // Speed at which the pillar goes down
        private const float PillarRaiseSpeed = 2f; // Speed at which the pillar goes up
        private const float PressurePlateActivationDelay = 0.5f; // Delay before activating the tower
        private const float HighestPoint = 125.3f; // Y-coordinate of the highest point
        private const float LowestPoint = 67.8f; // Y-coordinate of the lowest point

        private bool _isStandingOnPlate; // Flag to check if player is standing on the pressure plate
        private bool _isPillarDown; // Flag to check if the pillar is fully down

        private Vector3 _originalPosition; // Original position of the tower

        [SerializeField] private ConeMoving one;
        [SerializeField] private ConeMoving two;
        [SerializeField] private ConeMoving three;
        private bool _good;

        // Save the original position of the tower
        private void Start() => _originalPosition = tower.transform.position;
        private void Update()
        {
            if (one.done && two.done && three.done)
                _good = true;
            else
                _good=false;
            if (_isStandingOnPlate || !_isPillarDown) return;
            // If the player is not standing on the plate and the pillar is down, move pillar up.
            StartCoroutine(MovePillarUp());
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return; // Check if the collider is tagged as "Player"
            _isStandingOnPlate = true;
            if (_isPillarDown || !_good) return; // Only activate the tower if it's not already down
            StartCoroutine(MovePillarDown());
        }
        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("Player")) return; // Check if the collider is tagged as "Player"
            _isStandingOnPlate = true;
            if (_isPillarDown || !_good) return; // Only activate the tower if it's not already down
            StartCoroutine(MovePillarDown());
        }
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return; // Check if the collider is tagged as "Player"
            _isStandingOnPlate = false;
        }
        private System.Collections.IEnumerator MovePillarDown()
        {
            yield return new WaitForSeconds(PressurePlateActivationDelay);

            var targetPosition = new Vector3(_originalPosition.x, LowestPoint, _originalPosition.z);
            var distance = Vector3.Distance(tower.transform.position, targetPosition);
            var startTime = Time.time;
            while (tower.transform.position.y > LowestPoint && _isStandingOnPlate)
            {
                var journeyLength = (Time.time - startTime) * PillarLowerSpeed;
                var fractionOfJourney = journeyLength / distance;
                tower.transform.position = Vector3.Lerp(tower.transform.position,
                                                                targetPosition,
                                                                fractionOfJourney);
                yield return null;
            }
            _isPillarDown = true;
        }
        private System.Collections.IEnumerator MovePillarUp()
        {
            var targetPosition = new Vector3(_originalPosition.x, HighestPoint, _originalPosition.z);
            var distance = Vector3.Distance(tower.transform.position, targetPosition);
            var startTime = Time.time;

            while (tower.transform.position.y < HighestPoint)
            {
                var journeyLength = (Time.time - startTime) * PillarRaiseSpeed;
                var fractionOfJourney = journeyLength / distance;
                tower.transform.position = Vector3.Lerp(tower.transform.position,
                                                                targetPosition,
                                                                fractionOfJourney);
                yield return null;
            }
            _isPillarDown = false;
        }
    }
}
