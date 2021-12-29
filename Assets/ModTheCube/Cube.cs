using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Color[] colors = new Color[2];

    private int currentNumber = 3;

    public float translationSpeed;
    public float rotationSpeed;

    private int positionBoundX = 4;
    private bool goingRight = true;

    void Start()
    {
    }

    void Update()
    {

        Material material = Renderer.material;

        if (goingRight && transform.position.x > positionBoundX)
        {
            goingRight = false;
            material.color = colors[getRandomNumber()];
        }
        if (!goingRight && transform.position.x < -positionBoundX)
        {
            goingRight = true;
            material.color = colors[getRandomNumber()];
        }

        if (goingRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * translationSpeed);
            transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * -translationSpeed);
            transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
        }
    }

    int getRandomNumber()
    {
        int newNumber = 3;

        while (newNumber == currentNumber)
        {
            newNumber = Random.Range(0, colors.Length);
        }

        currentNumber = newNumber;
        return newNumber;
    }
}
