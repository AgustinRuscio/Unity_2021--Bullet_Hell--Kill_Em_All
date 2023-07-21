//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _target;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private Vector3 _offSet;

    private void Start() => _target = FindObjectOfType<PlayerModel>().transform;
    
    private void Update() => transform.position = Vector3.Lerp(transform.position, _target.position - _offSet, _speed*Time.deltaTime);
}