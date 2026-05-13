using System;

namespace Lab3.Task6_Flyweight
{
    public class MemoryCounter
    {
        public static long GetMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            return GC.GetTotalMemory(true);
        }
    }
}