using System.Collections;
using UnityEngine;

public interface IEnemy
{
    void Spawn(Vector3 position);
    void Despawn();
}

public class Enemy : MonoBehaviour, IEnemy
{
    public void Spawn(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
    }
}
