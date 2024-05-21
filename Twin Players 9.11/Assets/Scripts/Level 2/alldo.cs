using UnityEngine;

namespace Level_2
{
    public class AllDo : MonoBehaviour
    {
        public GameObject solutionPillar; // Reference to the solution pillar GameObject
        public float pillarLowerSpeed = 2f; // Speed at which the pillar goes down
        public float pillarRaiseSpeed = 2f; // Speed at which the pillar goes up
        public float pressurePlateActivationDelay = 0.5f; // Delay before activating the solution pillar
        public float highestPoint = 131.03f; // Y-coordinate of the highest point
        public float lowestPoint = 67.8f; // Y-coordinate of the lowest point

        private bool isStandingOnPlate = false; // Flag to check if player is standing on the pressure plate
        private bool isPillarDown = false; // Flag to check if the pillar is fully down

        private Vector3 originalPosition; // Original position of the solution pillar

        public conemoving one;
        public conemoving two;
        public conemoving three;
        public bool good=false;

        private void Start()
        {
            // Save the original position of the solution pillar
            originalPosition = solutionPillar.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
            {
                isStandingOnPlate = true;
                if (!isPillarDown && good) // Only activate the solution pillar if it's not already down
                {
                    StartCoroutine(MovePillarDown());
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) // Check if the collider is tagged as "Player"
            {
                isStandingOnPlate = false;
            }
        }

        private System.Collections.IEnumerator MovePillarDown()
        {
            yield return new WaitForSeconds(pressurePlateActivationDelay);

            Vector3 targetPosition = new Vector3(originalPosition.x, lowestPoint, originalPosition.z);
            float distance = Vector3.Distance(solutionPillar.transform.position, targetPosition);
            float duration = distance / pillarLowerSpeed;
            float startTime = Time.time;
    while (solutionPillar.transform.position.y > lowestPoint && isStandingOnPlate)
            {
                float journeyLength = (Time.time - startTime) * pillarLowerSpeed;
                float fractionOfJourney = journeyLength / distance;
                solutionPillar.transform.position = Vector3.Lerp(solutionPillar.transform.position,
                                                                targetPosition,
                                                                fractionOfJourney);
                yield return null;
            }
            isPillarDown = true;
        }

        private void Update()
        {
            if(one.done && two.done && three.done){
                good=true;
                Debug.Log("Cones are good");
            }
            else{
                good=false;
            }

            if (!isStandingOnPlate && isPillarDown) // If the player is not standing on the plate and the pillar is down
            {
                StartCoroutine(MovePillarUp());
            }
        }

        private System.Collections.IEnumerator MovePillarUp()
        {
            Vector3 targetPosition = new Vector3(originalPosition.x, highestPoint, originalPosition.z);
            float distance = Vector3.Distance(solutionPillar.transform.position, targetPosition);
            float duration = distance / pillarRaiseSpeed;
            float startTime = Time.time;

            while (solutionPillar.transform.position.y < highestPoint)
            {
                float journeyLength = (Time.time - startTime) * pillarRaiseSpeed;
                float fractionOfJourney = journeyLength / distance;
                solutionPillar.transform.position = Vector3.Lerp(solutionPillar.transform.position,
                                                                targetPosition,
                                                                fractionOfJourney);
                yield return null;
            }
            isPillarDown = false;
        }
    }
}
