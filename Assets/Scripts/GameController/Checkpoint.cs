﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [HideInInspector] public int checkPointNum;
    public float brakeFactor = 1f;

    void OnTriggerEnter(Collider other)
    {
        Car car = other.gameObject.GetComponent<Car>();
        if (car)
        {
            car.AdjustSpeedByPosition();
            if (checkPointNum == car.nextCheckpoint)
            {
                car.CheckpointPassed();
            }
            else if (checkPointNum != car.currentCheckpoint)
            {
                car.Respawn(Vector3.zero);
            }
            CarAI carAI = other.gameObject.GetComponent<CarAI>();
            if (carAI)
            {
                float brakeProb = car.brakeProbability;
                if (Random.value < brakeProb)
                {
                    car.Brake(brakeFactor);
                }
            }
        }
    }
}
