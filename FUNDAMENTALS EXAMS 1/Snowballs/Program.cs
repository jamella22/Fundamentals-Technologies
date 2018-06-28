using System;
using System.Collections.Generic;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxSnowBallNow = 0;
            int maxSnowballTime = 0;
            int maxSnowBallQuality = 0;
            BigInteger maxSnowBallValue = 0;

            for (int i = 0; i < n; i++)
            {
                int snowBallSnow = int.Parse(Console.ReadLine());
                int snowBallSTime = int.Parse(Console.ReadLine());
                int snowBallSQuality = int.Parse(Console.ReadLine());

                BigInteger snowBallValue = BigInteger.Pow((snowBallSnow / snowBallSTime), snowBallSQuality);

                if (snowBallValue > maxSnowBallValue)
                {
                    maxSnowBallValue = snowBallValue;
                    maxSnowballTime = snowBallSTime;
                    maxSnowBallQuality = snowBallSQuality;
                    maxSnowBallNow = snowBallSnow;
                }
            }
            Console.WriteLine($"{maxSnowBallNow} : {maxSnowballTime} = {maxSnowBallValue} ({maxSnowBallQuality})");

        }
        
    }
}
