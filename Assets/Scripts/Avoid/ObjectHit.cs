using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
        }
    }
}