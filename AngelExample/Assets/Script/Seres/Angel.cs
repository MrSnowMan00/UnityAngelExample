using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Angel : MonoBehaviour
{
    // variables a usar

    private bool crearNino;
    private LivingScript life;
    public NavMeshAgent agent;
    private ChangeMaterial callMaterial;

    private float distance = 0;

    private float randomX;
    private float randomZ;

    // Valores para guardar el RigidBody
    public Rigidbody rb;
    public Rigidbody neighboordTr;

    // Valores para calcular la distancia entre el destino final y la posicion del objeto
    private Vector3 dirrecion;
    public Vector3 pathGo;

    // Valores para calcular la distancia entre el destino y la posicion del objeto
    private Vector3 dirrecionPath;
    private float distPath;
    private bool cerca;

    GameObject gamemo;
    public int timeForWait;

    // Se llama al inicio, justo antes de que cada Update sea llamado
    private void Start()
    {
        SetRandomPath();
    }

    // Es llamado cada Frame
    private void Update()
    {
        CreatePath();
    }

    // Esta funcion creara un camino y lo asignara al agent
    private void CreatePath()
    {
        MakeDistance();
        //pathGo = Vector3.MoveTowards(rb.position, neighboordTr.position, maxDistance);

        // Si la distancia es mayor a 20, crea un camino aleatorio
        if (distance <= 20)
        {

            pathGo = neighboordTr.position;
            agent.SetDestination(pathGo);
            TargetINview();

        } else if (!cerca)
        {

            agent.SetDestination(pathGo);

        } else
        {
            SetRandomPath();
            agent.SetDestination(pathGo);
        }
    }

    // Esta funcion calculara la distancia entre el target y el objeto
    private void MakeDistance()
    {
        dirrecion = rb.position - neighboordTr.position;
        distance = (int)dirrecion.magnitude;

        dirrecionPath = rb.position - pathGo;
        distPath = (int)dirrecionPath.magnitude;

        // Si la distancia es menor a 5 entonces un nuevo camino se creara
        if (distPath < 2)
        {
            Debug.Log("LLegamos");
            cerca = true;
        }

        // Si no, se esperara hasta llegar
        else
        {
            cerca = false;
        }
    }

    // Esta funcion se encargara de crear un camino aleatorio
    private void SetRandomPath()
    {

        randomZ = Random.Range(-50f , 50f);
        randomX = Random.Range(-50f , 50f);

        // Asignara un nuevo camino con las coordenadas dadas
        pathGo = new Vector3(randomX, rb.position.y, randomZ);
    }

    private void TargetINview()
    {
        callMaterial = FindObjectOfType<ChangeMaterial>();
        callMaterial.ChangeMat();
    }
}
