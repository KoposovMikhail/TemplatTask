using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            StackG<int> stack1 = new StackG<int>(5); 
            stack1.Push(3);
            stack1.Push(5);
            stack1.print();
            StackG<int> stack2 = new StackG<int>(5);
            stack2.Push(6);
            stack2.Push(10);
            stack2.PopOut();
            stack2.print();
            StackG<int> stack3 = new StackG<int>(stack1,stack2); // Объединение стеков
            stack3.print();
            StackG<int>stack4 = new StackG<int>(stack3); // Инициализация другим стеком
            stack4.print();
        }
    }
}
