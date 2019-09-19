using UnityEngine;

public class BulletAction : MonoBehaviour {
    // Drag explosion prefab here. Should trigger itself when instantiated.
    public Transform explosionPrefab;

    public void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point; // Where to create the explosion
        Instantiate(explosionPrefab, pos, Quaternion.identity); // Creating the explosion  
        Destroy(this.gameObject); // Destroying the bullet
    }
}
