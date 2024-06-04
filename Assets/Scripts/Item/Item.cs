using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            UseItem(other);
            gameObject.SetActive(false);
        }
    }

    protected abstract void UseItem(Collider other);

    protected abstract void EndEffect();

}
