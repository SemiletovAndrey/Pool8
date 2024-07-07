using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float impactForce;

    private Rigidbody rigidbodyBall;
    private CueController controller;
    private BallControl ballControl;

    private void Start()
    {
        transform.position = ball.position;
        rigidbodyBall = ball.GetComponent<Rigidbody>();
        controller = FindObjectOfType<CueController>();
        ballControl = FindObjectOfType<BallControl>();
    }

    private void Update()
    {
        KickBall();
        RotateCue();
    }

    private void OnEnable()
    {
        transform.position = ball.position;
    }

    private void KickBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbodyBall.AddForce(transform.right * impactForce, ForceMode.Impulse);
            controller.CueOff();
        }
    }

    private void RotateCue()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
        // Определяем вектор направления от кия к позиции мыши
        Vector3 lookDirection = worldMousePosition - ball.position;
        // Определяем угол вращения только по оси Y
        float angleY = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
        // Создаем кватернион вращения только по оси Y
        Quaternion rotationY = Quaternion.Euler(0, angleY + 90, 0);
        
        // Применяем вращение только по оси Y к объекту кия
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationY, Time.deltaTime * rotationSpeed); ;
    }
}

