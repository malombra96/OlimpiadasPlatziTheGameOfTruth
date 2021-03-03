
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // velocidad del enemygo
    public float enemySpeed = 1.0f;
    //para obtener el rigybody del enemygo
    private Rigidbody2D enemyRigidbody2D;
    //para saber si esta en movimiento
    private bool isMoving;
    //para saber cuando tiempo entre pasos 
    public float timeBetweenSteps;
    //para saber cuando tiempo lleva haciendo el paso
    private float timeBetweenStepsCounter;
    //para saber cuanto tiempo entre pasos
    public float timeToMakeStep;
    //para saber cuando tiempo lleva antes del ultimo paso 
    private float timeToMakesStepCounter;
    //direccion del movimiento 
    public Vector2 directionToMakeStep;
    //para obtener el grafo de animaciones 
    private Animator enemyAnimator;
    //para guardar los nombre de los parametros del grafo de animaciones 
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        
        timeBetweenStepsCounter = timeBetweenSteps * Random.Range(0.5f,1.5f);
        timeToMakesStepCounter = timeToMakeStep * Random.Range(0.5f,1.5f);
    }
    
    void Update()
    {
        if (isMoving)
        {
            timeToMakesStepCounter -= Time.deltaTime;
            enemyRigidbody2D.velocity = directionToMakeStep;
            if (timeToMakesStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRigidbody2D.velocity = Vector2.zero;
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if (timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakesStepCounter = timeToMakeStep;
                directionToMakeStep = new Vector2(Random.Range(-1,2), Random.Range(-1,2)*enemySpeed);
            }
        }
        enemyAnimator.SetFloat(HORIZONTAL,directionToMakeStep.x);
        enemyAnimator.SetFloat(VERTICAL,directionToMakeStep.y);
    }
}
