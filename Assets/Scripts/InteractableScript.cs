using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public GameObject interactText;
    // Start is called before the first frame update

    private void Awake()
    {
        interactText = this.transform.GetChild(0).gameObject;
    }
    void Start()
    {
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
