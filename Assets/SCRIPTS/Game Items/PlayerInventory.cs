using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<GameItem> inventory = new List<GameItem>();
    private GameItem equippedItem;

    public Transform weaponHolder;

    void Update()
    {
        HandleItemUse();
        HandleItemSwitch();
    }

    private void HandleItemUse()
    {
        if (Input.GetKey(KeyCode.Mouse0) && equippedItem != null)
        {
            equippedItem.Use();
        }
    }

    private void HandleItemSwitch()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                if (inventory[i] != null)
                {
                    EquipItem(inventory[i]);
                }
                else
                {
                    Debug.LogWarning($"Item {i + 1} in inventory is missing or was consumed.");
                }
            }
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        GameItem item = other.GetComponent<GameItem>();
        if (item != null && !inventory.Contains(item))
        {
            AddItem(item);
        }
    }

    public void AddItem(GameItem item)
    {
        item.Pickup();               // Hide from world (optional)
        inventory.Add(item);
        EquipItem(item);             // Auto-equip on pickup
    }
    public void RemoveItem(GameItem item)
    {
        if (equippedItem == item)
        {
            equippedItem = null;
        }

        inventory.Remove(item);
    }

    private void EquipItem(GameItem item)
    {
        foreach (var invItem in inventory)
        {
            invItem.gameObject.SetActive(false); // Disable all first
        }

        equippedItem = item;
        equippedItem.Equip(weaponHolder);       // Activate and attach
        Debug.Log($"Equipped {item.ItemName}!");
    }
}
