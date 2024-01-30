using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform asteroid1Template, asteroid2Template, asteroid3Template;

    int number_of_asteroids = 100;
    void Start()
    {
        for (int i = 0; i < number_of_asteroids; i++)
        {
            Transform newAsteroid = null;
            switch (Random.Range(0,3))
            {
                case 0:
                    newAsteroid =  Instantiate(asteroid1Template,randomPosition(),Quaternion.identity);
                    break;

                    case 1:
                    newAsteroid = Instantiate(asteroid2Template, randomPosition(), Quaternion.identity);
                    break;

                    case 2:
                    newAsteroid = Instantiate(asteroid3Template, randomPosition(), Quaternion.identity);
                    break;

            }
         
            newAsteroid.localScale = Random.Range(10f, 50f) *Vector3.one;
        }
    }

    private Vector3 randomPosition()
    {
        return new Vector3(Random.RandomRange(-500f, 500f), Random.RandomRange(-500f, 500f), Random.RandomRange(-500f, 500f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
