using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootForce = 20f;
    public GameObject MuzzleFlash;
    public AudioSource audio;
     void Start()
    {
        MuzzleFlash.SetActive(false);
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MuzzleFlash.SetActive(true);
            audio.Play();
            Shoot();
        }
        else
        {
            MuzzleFlash.SetActive(false);
        }
    }

    void Shoot()
    {
       
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        }
        
       
    }
}
