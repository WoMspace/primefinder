﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace primefinder
{
    class Program
    {
        static void Main(string[] args)
        {
            primeLoop();
        }
        static List<long> primes = new List<long> //the list of found prime numbers.
        {
            3
        };
        static void checkNumber(long numberToCheck) //checks the number against the list of existing primes.
        {
            int root = (int)Math.Ceiling(Math.Sqrt(primes.Count));
            bool isPrime = true;
            for(int i = 0; i < root; i++)
            {
                if(numberToCheck%primes[i] == 0)
                {
                    isPrime = false; //if the number is found to not be a prime, mark it as so and quit the number.
                    break;
                }
            }
            if (isPrime) //if we've got to the end of the loop and the number is still marked as prime, it is a prime. Add it to the list.
            {
                primes.Add(numberToCheck);
            }
        }
        static void primeLoop() //the loop that decides what to check as a prime number
        {
            Stopwatch millionCounter = new Stopwatch();
            millionCounter.Restart();
            Stopwatch tenThousandCounter = new Stopwatch();
            tenThousandCounter.Restart();
            bool quit = false;
            long numberToCheck = 5;
            while(!quit)
            {
                checkNumber(numberToCheck);
                numberToCheck+= 2;
                if(primes.Count%1000000==0) //every millionth prime it says how long it's been since the last million.
                {
                    Console.WriteLine("The {0} millionth prime was {1}. That took {2.0} seconds.\nPrimeN|Prime Number|Time(ms)", primes.Count / 1000000, numberToCheck, millionCounter.Elapsed.Seconds);
                    millionCounter.Restart();
                }
                if(primes.Count%10000==0)
                {
                    Console.WriteLine("{0.000000}|{1.000000000000}|{3}", primes.Count / 10000, numberToCheck, tenThousandCounter.ElapsedMilliseconds);
                }
            }
        }
        
    }
}