using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.y < -dead)
        {
            player.transform.position = vectorPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = player.transform.position;
        //Destroy(other.gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("CP hit");
            player.GetComponent<PlayerController1>().lastCP = this;
            ScoreManager1.scoreCount = 0; 
        }
    }
}
