using UnityEngine;

public class PlayerCollison : MonoBehaviour {
{
    public PlayerController1 movement;

    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            GetComponent<>
        }
    }

}