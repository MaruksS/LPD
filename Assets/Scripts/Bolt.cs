using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {
    //merkis
    private Transform target;
    //atrums
    public float speed = 70f;
    //specefekts, kas dod spelei reitingu 18+
    public GameObject bloodEffect;

    //tiek izsaukta no turret cs klases, lai bulta zinatu merki
    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update () {
        //ja bultai zud merkis, ta pashiznicinas
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        //bultas parvietoshanas virziens
        Vector3 direction = target.position - transform.position;
        //attalums, ko bulta iziet 1 kadra
        float distabceThisFrame = speed * Time.deltaTime;

        //ja attalums starp merki ir mazaks neka attalums, kas tiek iziets viena kadra
        //tiek ieskaitits trapijums
        if(direction.magnitude <= distabceThisFrame)
        {
            HitTarget();
            return;
        }
        //bultas parvietoshana
        transform.Translate(direction.normalized * distabceThisFrame, Space.World);
	}

    void HitTarget()
    {
        //uz trapijumu paradas asins effekts un tiek iznicinata bulta
        GameObject effect = (GameObject)Instantiate(bloodEffect, transform.position, transform.rotation);
        Destroy(target.gameObject);
        Destroy(effect, 1f);
        Destroy(gameObject);

        //kad tiek nogalinati 10 pretinieki, lietotajs sanem 1 seklu
        if (Resources.kills >= 10)
        {
            Resources.seeds++;
            Resources.kills = 0;
        }
        Resources.kills++;
    }

}
