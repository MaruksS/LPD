using UnityEngine;

public class Creep_movement : MonoBehaviour {
    public float speed = 10f;

    private Transform target;
    private int wpointID = 0;

    private void Start()
    {
        //tiek atrasts pirmais waypoints un uzstadits ka merkis
        target = W_points.wpoints[0];

    }

    private void Update()
    {
        //ka virzienu tiek izvelets taisns celsh uz nakamo waypointu
        Vector3 direction = target.position - transform.position;
        //creep tiek parvietots uz nakama waypoint pusi ar atrumu speed
        transform.Translate(direction.normalized*speed*Time.deltaTime,Space.World);

        //kad creeps sasniedz waypointu, tiek iezvelets nekoshais waypoints
        if (Vector3.Distance(transform.position,target.position)<=0.4f)
        {
            GetNextWaypoint();
        }
    }
    //funkcija, kas atrod nakosho waypointu no klases W_points
    void GetNextWaypoint() {
        //kad creep sasniedz galamerki, vinjsh tiek iznicinats
        if (wpointID >= W_points.wpoints.Length - 1)
        {
            Resources.lives--;
            Destroy(gameObject);
            return;
        }
        //tiek izvelets nakoshais waypoints
        wpointID++;
        target = W_points.wpoints[wpointID];
    }
}
