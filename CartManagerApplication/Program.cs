namespace CartManagerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Solutions.level1.Solution1 sol1 = new Solutions.level1.Solution1();
            sol1.run();
            sol1.save();
            

            Solutions.level2.Solution2 sol2 = new Solutions.level2.Solution2();
            sol2.run();
            sol2.save();

            Solutions.level3.Solution3 sol3 = new Solutions.level3.Solution3();
            sol3.run();
            sol3.save();
        }
    }
}
