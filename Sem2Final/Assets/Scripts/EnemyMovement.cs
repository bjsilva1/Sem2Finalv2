using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public Vector3 position;
    public bool isGrappled;
    public Vector3 grapplePos;

    public EnemyState(Vector3 pos, bool grappled, Vector3 gPos)
    {
        position = pos;
        isGrappled = grappled;
        grapplePos = gPos;
    }
}

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public LineRenderer grapple;
    List<EnemyState> positions = new List<EnemyState>();

    public float delay;
    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        positions.Add(new EnemyState(player.position, playerScript.grappled, playerScript.lastGrapplePos));
        grapple.SetPosition(0, transform.position);

        if (positions.Count > delay / Time.deltaTime)
        {
            transform.position = positions[0].position;
            grapple.gameObject.SetActive(positions[0].isGrappled);
            grapple.SetPosition(1, positions[0].grapplePos);
            positions.RemoveAt(0);
        }
    }
}
