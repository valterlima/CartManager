using CartManagerApplication.Solutions.level1;

namespace CartManagerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution1 sol1 = new Solution1();
            sol1.run();
            sol1.save();
        }
    }
}
