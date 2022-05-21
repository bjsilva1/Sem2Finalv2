using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public Vector3 position;
    public bool isGrappled;
    public Vector3 grapplePos;
    public float timeScale;

    public EnemyState(Vector3 pos, bool grappled, Vector3 gPos, float time)
    {
        position = pos;
        isGrappled = grappled;
        grapplePos = gPos;
        timeScale = time;
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
        positions.Add(new EnemyState(player.position, playerScript.grappled, playerScript.lastGrapplePos, Time.timeScale));
        grapple.SetPosition(0, transform.position);

        if (positions.Count > delay / Time.deltaTime)
        {
            if(Time.timeScale == 1)
            {
                transform.position = positions[0].position;
                grapple.gameObject.SetActive(positions[0].isGrappled);
                grapple.SetPosition(1, positions[0].grapplePos);
                positions.RemoveAt(0);
                return;
            }
            for (float i = 0; i < 1; i+= positions[0].timeScale)
            {
                transform.position = positions[0].position;
                grapple.gameObject.SetActive(positions[0].isGrappled);
                grapple.SetPosition(1, positions[0].grapplePos);
                positions.RemoveAt(0);
            }
        }
    }
}
