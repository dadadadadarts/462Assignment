using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float speedIncrease = 0.1f;
    [SerializeField] private float speedChangeWCollectible = 3f;
    [SerializeField] private float turnSpeedVal = 50f;
    public static CarScript instance;

    private float horizontalInput;

    // Update is called once per frame
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update()
    {
        speed += speedIncrease * Time.deltaTime;
        transform.Rotate(0f, horizontalInput * turnSpeedVal * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Turn(int value)
    {
        horizontalInput = value;
    }

    public void SpeedUp()
    {
        speed += speedChangeWCollectible;
    }

    public void SlowDown()
    {
        speed -= speedChangeWCollectible;
    }
}
