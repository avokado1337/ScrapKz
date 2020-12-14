using System;

namespace ScrapKz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GPU.shopkzGPU();
            CPU.shopkzCPU();
            Motherboards.shopkzMotherboard();
            Console.ReadLine();
        }

    }
}
