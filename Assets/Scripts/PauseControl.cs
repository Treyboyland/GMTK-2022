using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField]
    PlayerShip ship;

    [SerializeField]
    GameObject inventoryView;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            inventoryView.SetActive(!inventoryView.activeInHierarchy);
            ship.CanLaunch = !inventoryView.activeInHierarchy;
            Time.timeScale = inventoryView.activeInHierarchy ? 0 : 1;
        }
    }
}
