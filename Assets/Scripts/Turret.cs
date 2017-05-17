using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]
    //attalums cik talu redz tornis
    public float range = 15f;
    //shaushanas atrums
    public float fireRate = 1f;
    //parladeshana
    private float fireCD = 0f;

    [Header("Unity fields")]
    //merkis uz ko temet
    public string creepTag = "Creep";
    //kustiga tornja dalja
    public Transform partToRotate;
    //pagrieshanas atrums
    public float turnSpeed = 10f;

    //bulta un bultas spawn vieta
    public GameObject arrowPrefab;
    public Transform firePoint;

    // Use this for initialization
    void Start () {
        //izsauc 1 reizi 2 sekundes funkciju updatetarget
        InvokeRepeating("UpdateTarget",0f,0.5f);
	}

    void UpdateTarget() {
        //masivs, kas satur visus pretiniekus
        GameObject[] creeps = GameObject.FindGameObjectsWithTag(creepTag);
        //nav merkja
        float closestDistance = Mathf.Infinity;
        GameObject closestCreep = null;
        foreach (GameObject creep in creeps)
        {
            //tiek meklets tuvakais creeps
            //tuvaka creepa mekleshana notiek katras 2 sekundes
           float distanceToCreep = Vector3.Distance(transform.position, creep.transform.position);
            if (distanceToCreep < closestDistance)
            {
                closestDistance = distanceToCreep;
                closestCreep = creep;
            }
        }
        //ja tuvakais creeps ir tornja radiusa, vinjsh klust merkis
        if (closestCreep !=null && closestDistance <= range)
        {
            target = closestCreep.transform;
        }
        //ja neviens creeps nav tornja radiusa, tad merka nav
        else
        {
            target = null;
        }

    }
	// Update is called once per frame
	void Update () {
        //ja merka nav, funkcija nav nepiecishama
		if (target == null) return;
        //pagriezh augshejo tornja dalju creepa virzienaa
        Vector3 direction = target.position - transform.position;
        //tiek atrasts virziens, uz kuru tornim javirzas.
        //ka tieshi darbojas quaternioni, nesapratu, nejautajiet sho
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        //lerp lauj tornim gludi pagriezties, kad tas atrod merki
        //atrumu nosakam pashi ar turnspeed parametru
        Vector3 rotation = Quaternion.Lerp(
            partToRotate.rotation,
            lookRotation,
            Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        //ja tornis neparladejas, tad tas var shaut
        if (fireCD <= 0f)
        {
            Shoot();
            fireCD = 1f / fireRate;
        }
        //pec shaviena aktivizejas parladeshanas taimeris
        fireCD -= Time.deltaTime;
	}

    void Shoot()
    {
        //uz shavienu tiek izsaukta bulta, kas ir versta uz to pashu pusi ka tornis
        GameObject boltGO = (GameObject)Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Bolt bolt = boltGO.GetComponent<Bolt>();
        //ja bulta ir izshauta, ta seko merkim
        if (bolt != null)
        {
            bolt.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        //uzzime sferu apkart tornim, kas norada radiusu
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
