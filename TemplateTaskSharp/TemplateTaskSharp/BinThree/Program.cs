using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinThree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinTree<int> tree = new BinTree<int>(8);
            tree.Push(4);
            tree.Push(2);
            tree.Push(3);
            tree.Push(10);
            tree.Push(6);
            tree.Push(7);
            tree.Print();
            tree.PrintLeaves();

            
        }
    }
}
