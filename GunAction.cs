using UnityEngine;

public class GunAction : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform bulletEntry;
    public float bulletSpeed;

    //public AudioClip explosion;

    public void Update()
    {
        // Check for Fire1 input and instantiate bullet prefab at bulletPoint         
        if ((Input.GetButtonDown("Fire1")))
        {
            // Play audio
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.PlayOneShot(explosion);

            // Create bullet
            Rigidbody bulletInstance = Instantiate(bulletPrefab, bulletEntry.transform.position, bulletEntry.transform.rotation);

            // The local up direction of the entryPoint is transformed into world space.
            Vector3 gunDirection = bulletEntry.TransformDirection(Vector3.up);
            bulletInstance.AddForce(gunDirection * bulletSpeed, ForceMode.Impulse);
        }
    }
}
