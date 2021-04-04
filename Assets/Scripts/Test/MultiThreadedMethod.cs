using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MultiThreadedMethod : MonoBehaviour
{
    private void Start()
    {
        Thread thr1 = new Thread(Method1);
        Thread thr2 = new Thread(Method2);
        thr1.Start();
        thr2.Start();
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
