using UnityEngine;

public abstract class GameItem : MonoBehaviour
{
    public string ItemName { get; protected set; }

    protected GameItem(string itemName)
    {
        ItemName = itemName;
    }

    public abstract void Use();

    public void Pickup()
    {
        Debug.Log($"{ItemName} has been picked up!");
        gameObject.SetActive(false); // Hide from world
    }

    public virtual void Equip(Transform parent)
    {
        gameObject.SetActive(true);           // Make visible
        transform.SetParent(parent);          // Attach to player
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
