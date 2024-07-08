using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool pressed;
    Vector3 inventorySlotPosition;
    public bool pickable;
    public bool unlockable;
    public GameObject unlockableObject;
    public int inventoryCount;
    public GameObject[] inventory;
    public GameObject inventorySlot;
    public GameObject pickupObject;
    public GameObject interactText;

    private void Awake()
    {
    }
    void Start()
    {
        pressed = false;
        inventory = new GameObject[6];
        inventoryCount = 0;
    }

    void Update()
    {
        if (pickable && Input.GetKey("e"))
        {
            pickup(pickupObject);
            pickable = false;
        }
        if (unlockable && Input.GetKey("e"))
        {
            Unlock(unlockableObject);
        }
    }
    public void ShowText(GameObject obiect)
    {
        pickupObject = obiect.gameObject;
        interactText = obiect.transform.GetChild(0).gameObject;
        interactText.SetActive(true);
    }
    public void HideText(GameObject obiect)
    {
        interactText = obiect.transform.GetChild(0).gameObject;
        interactText.SetActive(false);
    }
    public void CanPick(GameObject obiect)
    {
        pickable = true;
        pickupObject = obiect.gameObject;
    }
    public void UnPickable(GameObject obiect)
    {
        pickable = false;
        pickupObject = obiect.gameObject;
    }
    void pickup(GameObject obiect)
    {
        inventory[inventoryCount] = obiect.gameObject;
        inventoryCount++;
        inventorySlotPosition = new Vector3(-8f, (float)(3 - 1 * inventoryCount), 3f);
        Instantiate(inventorySlot, inventorySlotPosition, Quaternion.identity);
        obiect.gameObject.GetComponent<Transform>().position = new Vector3(-8f, (float)(3 - 1 * inventoryCount), 2f);
    }
    public void UnLockable(GameObject obiect)
    {
        unlockable = true;
        unlockableObject = obiect.gameObject;
    }
    public void CantUnlock(GameObject obiect)
    {
        unlockable = false;
    }
    public void Unlock(GameObject obiect)
    {
        for (int i = 0; i<inventoryCount; i++)
        {
            if (obiect.gameObject.name[0] == inventory[i].name[0])
            {
                Debug.Log("you win");
                unlockable = false;
            }
        }
    }
}
