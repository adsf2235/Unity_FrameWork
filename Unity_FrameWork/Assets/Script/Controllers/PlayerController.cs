using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    int _speed = 10;

    Vector3 _destPos;
    float wait_run_ratio;

    public enum PlayerState
    {
        Idle,
        Moving,
        Die,

    }

    PlayerState State = PlayerState.Idle;
    void Start()
    {
        //Managers.Input.KeyAction -= OnKeyboard;
        //Managers.Input.KeyAction += OnKeyboard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        Managers.UI.ShowPopupUI<UI_Button>();
        
    }

    void Update()
    {
        switch (State)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
       
        }
    }

    public void UpdateIdle()
    {
        Animator anim = GetComponent<Animator>();
        anim.Play("WAIT_RUN");
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10 * Time.deltaTime);
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
       

    }
    public void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;
        float _moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
        transform.position += dir.normalized * _moveDist;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);

        Animator anim = GetComponent<Animator>();
        anim.Play("WAIT_RUN");
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10 * Time.deltaTime);
        anim.SetFloat("wait_run_ratio", wait_run_ratio);

        if (dir.magnitude < 0.0001f)
        {
            State = PlayerState.Idle;
        }

    }
    public void UpdateDie()
    {

    }

    //public void OnKeyboard()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
    //        transform.position += Vector3.forward * Time.deltaTime * _speed;
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
    //        transform.position += Vector3.left * Time.deltaTime * _speed;
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
    //        transform.position += Vector3.back * Time.deltaTime * _speed;
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
    //        transform.position += Vector3.right * Time.deltaTime * _speed;
    //    }
    //    _moveDest = false;
    //}

    void OnMouseClicked(Define.MouseEvent evt)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1f);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 100f,LayerMask.GetMask("Floor")))
        {
            _destPos = hit.point;
            State = PlayerState.Moving;
        }
    }
}
