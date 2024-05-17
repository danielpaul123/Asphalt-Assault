/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    public float maxSpeed = 5f;
    public float acceleration = 1f; // Rate of acceleration
    public float turnSpeed = 5f;
    public float minDistanceToWaypoint = 0.1f;
    private int currentWaypointIndex = 0;
    private float currentSpeed = 0f;
    public Transform RaycastPos;
    public Transform shootPoint;
    public int shootForce;
    public GameObject projectilePrefab;
    public AudioSource audio;
    public GameObject MuzzleFlash;
    public Text countdownText; // Reference to the UI text element for countdown

    // Wheel variables
    public Transform[] wheelTransforms;
    public WheelCollider[] wheelColliders;

    private void Start()
    {
        StartCoroutine(CountdownAndStartMovement());
        audio = GetComponent<AudioSource>();
        // Initialize wheel colliders and transforms
        InitializeWheels();
        MuzzleFlash.SetActive(false);
    }

    private void InitializeWheels()
    {
        // Assign wheel colliders and transforms
        for (int i = 0; i < wheelTransforms.Length; i++)
        {
            wheelColliders[i] = wheelTransforms[i].GetComponentInChildren<WheelCollider>();
        }
    }

    private IEnumerator CountdownAndStartMovement()
    {
        // Disable AI movement during countdown
        enabled = false;

        // Countdown before AI car starts moving
        int countdownValue = 1;
        while (countdownValue >= 0)
        {
            countdownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(0.5f);
            countdownValue--;
        }
        countdownText.text = "GO!";

        // Enable AI movement after countdown
        enabled = true;
    }

    private void Update()
    {
        if (enabled)
        {
            MoveToWaypoint();
            UpdateWheelPoses();
            PerformRaycast();
        }
    }

    private void MoveToWaypoint()
    {
        if (currentWaypointIndex >= waypoints.Length)
            return;

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Smooth rotation towards the target direction
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // Accelerate until reaching max speed
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed = maxSpeed;
        }

        // Move the car forward at the current speed
        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < minDistanceToWaypoint)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            enabled = false;
        }
    }
    private void PerformRaycast()
    {

        RaycastHit hit;
        if (Physics.Raycast(RaycastPos.position, transform.forward, out hit, 60f))
        {

            
            if (hit.collider.CompareTag("Player"))
            {
                StartCoroutine(Shoot());
                
                MuzzleFlash.SetActive(true);
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
            }
            else
            {
                MuzzleFlash.SetActive(false);
            }
        }
    }

            
        
        
    
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        audio.Play();
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        // Draw the raycast in the Scene view
        Gizmos.color = Color.green;
        Gizmos.DrawRay(RaycastPos.position, transform.forward * 60f);
    }
    private void UpdateWheelPoses()
    {
        // Update visual wheel transforms based on wheel colliders
        for (int i = 0; i < wheelTransforms.Length; i++)
        {
            Quaternion rot;
            Vector3 pos;
            wheelColliders[i].GetWorldPose(out pos, out rot);
            wheelTransforms[i].position = pos;
            wheelTransforms[i].rotation = rot * Quaternion.Euler(0, 0, 90); // Adjust rotation as needed
        }
    }
}
*/













































using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    public float maxSpeed = 5f;
    public float acceleration = 1f; // Rate of acceleration
    public float turnSpeed = 5f;
    public float minDistanceToWaypoint = 0.1f;
    private int currentWaypointIndex = 0;
    private float currentSpeed = 0f;
    public Transform[] RaycastPositions; // Array of raycast positions
    public Transform shootPoint;
    public int shootForce;
    public GameObject projectilePrefab;
    public AudioSource audio;
    public GameObject MuzzleFlash;
    public Text countdownText; // Reference to the UI text element for countdown

    // Wheel variables
    public Transform[] wheelTransforms;
    public WheelCollider[] wheelColliders;

    // Laps variables
    public int totalLaps = 3;
    private int currentLap = 0;

    private void Start()
    {
        StartCoroutine(CountdownAndStartMovement());
        audio = GetComponent<AudioSource>();
        // Initialize wheel colliders and transforms
        InitializeWheels();
        MuzzleFlash.SetActive(false);
    }

    private void InitializeWheels()
    {
        // Assign wheel colliders and transforms
        for (int i = 0; i < wheelTransforms.Length; i++)
        {
            wheelColliders[i] = wheelTransforms[i].GetComponentInChildren<WheelCollider>();
        }
    }

    private IEnumerator CountdownAndStartMovement()
    {
        // Disable AI movement during countdown
        enabled = false;

        // Countdown before AI car starts moving
        int countdownValue = 1;
        while (countdownValue >= 0)
        {
            countdownText.text = countdownValue.ToString();
            yield return new WaitForSeconds(0.5f);
            countdownValue--;
        }
        countdownText.text = "GO!";

        // Enable AI movement after countdown
        enabled = true;
    }

    private void Update()
    {
        if (enabled)
        {
            MoveToWaypoint();
            UpdateWheelPoses();
            PerformRaycasts(); // Updated method name
        }
    }

    private void MoveToWaypoint()
    {
        if (currentLap >= totalLaps)
        {
            // Stop movement when the required number of laps are completed
            enabled = false;
            return;
        }

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Smooth rotation towards the target direction
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // Accelerate until reaching max speed
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed = maxSpeed;
        }

        // Move the car forward at the current speed
        transform.position += transform.forward * currentSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < minDistanceToWaypoint)
        {
            SetNextWaypoint();
        }
    }

    private void SetNextWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0; // Reset to the first waypoint
            currentLap++; // Increment the lap count

            if (currentLap >= totalLaps)
            {
                // Stop the AI when the laps are completed
                enabled = false;
            }
        }
    }

    private void PerformRaycasts() // Updated method name
    {
        foreach (var raycastPos in RaycastPositions)
        {
            RaycastHit hit;
            if (Physics.Raycast(raycastPos.position, transform.forward, out hit, 60f))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    StartCoroutine(Shoot());
                    MuzzleFlash.SetActive(true);
                    Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
                }
                else
                {
                    MuzzleFlash.SetActive(false);
                }
            }
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1f);
        audio.Play();
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        // Draw the raycasts in the Scene view
        Gizmos.color = Color.green;
        foreach (var raycastPos in RaycastPositions)
        {
            Gizmos.DrawRay(raycastPos.position, transform.forward * 60f);
        }
    }

    private void UpdateWheelPoses()
    {
        // Update visual wheel transforms based on wheel colliders
        for (int i = 0; i < wheelTransforms.Length; i++)
        {
            Quaternion rot;
            Vector3 pos;
            wheelColliders[i].GetWorldPose(out pos, out rot);
            wheelTransforms[i].position = pos;
            wheelTransforms[i].rotation = rot * Quaternion.Euler(0, 0, 90); // Adjust rotation as needed
        }
    }
}
