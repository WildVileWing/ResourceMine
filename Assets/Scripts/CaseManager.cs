using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
    public GameObject CaseMenu;
    public bool OpeningCase = false;
    public float ScrollingSpeed = -20;
    private float velocity;
    public void OpenCaseMenu()
    {
        CaseMenu.SetActive(true);
    }
    public void OpenCase()
    {
        velocity = Random.Range(2.5f, 3.5f);
        ScrollingSpeed = Mathf.MoveTowards(ScrollingSpeed, 0, velocity * Time.deltaTime);
        
    }
    private void Update()
    {
        gameObject.transform.Translate(new Vector2(ScrollingSpeed, 0) * Time.deltaTime);
    }
}
