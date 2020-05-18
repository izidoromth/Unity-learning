using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        Offset.x = -player.position.x;
        this.transform.position = player.position + Offset;        
    }
}
