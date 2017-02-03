using CartManagerApplication.src.level1;
using CartManagerApplication.src.level2;
using CartManagerApplication.src.level3;
using System;

namespace CartManagerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Solution1 sol1 = new Solution1();
                sol1.run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Level 1 ERROR: {0}", ex.Message));
            }
            finally
            {
                Console.WriteLine("Level 1 solved successfully");
            }

            try
            {
                Solution2 sol2 = new Solution2();
                sol2.run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Level 2 ERROR: {0}", ex.Message));
            }
            finally
            {
                Console.WriteLine("Level 2 solved successfully");
            }

            try
            {
                Solution3 sol3 = new Solution3();
                sol3.run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Level 3 ERROR: {0}", ex.Message));
            }
            finally
            {
                Console.WriteLine("Level 3 solved successfully");
            }




        }
    }
}
