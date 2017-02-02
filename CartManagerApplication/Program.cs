﻿using CartManagerApplication.src.level1;
using CartManagerApplication.src.level2;
using CartManagerApplication.src.level3;

namespace CartManagerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution1 sol1 = new Solution1();
            sol1.run();
            
            Solution2 sol2 = new Solution2();
            sol2.run();

            Solution3 sol3 = new Solution3();
            sol3.run();
        }
    }
}
