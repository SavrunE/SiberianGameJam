using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverFlyLocation : MonoBehaviour
{
    BoxCollider box;
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Menu");
    }
}
