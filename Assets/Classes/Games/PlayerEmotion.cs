using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Classes.Games
{
    class PlayerEmotion
    {
        private int emotionPoints;
        /*
         * Jak sobie wymyślić te zmiany punktów?
         */
         public void enableGyro()
        {
            Input.gyro.enabled = true;
        }
        public float gAccX()
        {
            return Input.gyro.userAcceleration.x;
        }
        public float gAccY()
        {
            return Input.gyro.userAcceleration.y;
        }
        public float gAccZ()
        {
            return Input.gyro.userAcceleration.z;
        }
        public float accX()
        {
            return Input.acceleration.x;
        }
        public float accY()
        {
            return Input.acceleration.y;
        }
        public float accZ()
        {
            return Input.acceleration.z;
        }

    }
}