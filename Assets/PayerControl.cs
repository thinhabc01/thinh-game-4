using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayerControl : MonoBehaviour
{
	public enum PlayStatus{Idle, Active}
    [SerializeField] private PlayStatus playstatus;

    void Start()
    {
        StartCoroutine(runIdle());
    }

    IEnumerator runIdle()
    {
        playstatus = PlayStatus.Idle;
        GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(runActive());

    }
    IEnumerator runActive()
    {
    	playstatus = PlayStatus.Active;
        GetComponent<Renderer>().material.color = Color.white;

        yield return new WaitForSeconds(1.5f);
        
        StartCoroutine(runIdle());
    }
}
