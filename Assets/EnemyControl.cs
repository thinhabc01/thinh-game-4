using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public enum EnemyStatus{Idle, Danger}
    [SerializeField] private EnemyStatus enemystatus;
    [SerializeField] private Vector3 pos1;
    [SerializeField] private Vector3 pos2;
    [SerializeField] private float speed;
    float pos_status = -1;

    void Start()
    {
        StartCoroutine(runIdle());
    }

    IEnumerator runIdle()
    {
        enemystatus = EnemyStatus.Idle;
        GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(2f);
        StartCoroutine(runDanger());

    }
    IEnumerator runDanger()
    {
    	enemystatus = EnemyStatus.Danger;
        GetComponent<Renderer>().material.color = Color.red;

        if (pos_status == -1)
        {
        	pos_status = 1;
	        while (transform.position != pos1)
	        {
			    transform.position =Vector3.MoveTowards(transform.position,pos1,speed*Time.deltaTime);
			    yield return null;
			}
		}
		else
		{
			pos_status = -1;
	        while (transform.position != pos2)
	        {
			    transform.position =Vector3.MoveTowards(transform.position,pos2,speed*Time.deltaTime);
			    yield return null;
			}
		}
        
        
        StartCoroutine(runIdle());
    }
}
