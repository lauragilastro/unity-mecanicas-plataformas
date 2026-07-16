using UnityEngine;

public class CheckpointSystem : MonoBehaviour 
{
    private Vector3 movimiento = Vector3.zero;
    private CharacterController move;
    public float pasadoTiempoSalto;

    void Start()
    {
        move = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Guardar checkpoint con espacio cada 10 segundos
        if (Input.GetKey("space") && pasadoTiempoSalto > 10f)
        {
            movimiento = move.transform.position;
            pasadoTiempoSalto = 0.0f;
        }
        pasadoTiempoSalto += Time.deltaTime;
    }

    void OnTriggerEnter(Collider Col)
    {
        // Si toca el agua, vuelve al último checkpoint
        if (Col.CompareTag("agua"))
        {
            move.transform.position = movimiento;
            pasadoTiempoSalto = 0.0f;
        }
    }
}