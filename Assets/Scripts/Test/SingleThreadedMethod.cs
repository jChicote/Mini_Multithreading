using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace TestThreading
{
    public class SingleThreadedMethod : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Method1();
            Method2();
        }

        public void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                print("Method one is: " + i);

                if (i == 5)
                {
                    Thread.Sleep(6000);
                }
            }
        }

        public void Method2()
        {

            // It prints numbers from 0 to 10
            for (int J = 0; J <= 10; J++)
            {
                print("Method two is: " + J);
            }
        }
    }
}
