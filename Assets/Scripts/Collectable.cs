using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int pointsValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GameManager.instance.AddScore(pointsValue);
            Destroy(gameObject);
        }
    }
}