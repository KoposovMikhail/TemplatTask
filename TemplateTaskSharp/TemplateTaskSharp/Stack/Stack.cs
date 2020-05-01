using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class StackG<T> 
    {
        int size;
        Stack<T> StackEx;
        public StackG(int size) // Конструктор по размерности стека
        {
            if (size > 0)
            {
                this.size = size;
                StackEx = new Stack<T>(size);
            }
            else
                throw new ArgumentException();
        }
        public StackG(StackG<T> otherStack) // Инициализация другим стеком
        {
            StackEx = otherStack.StackEx;
            size = otherStack.size;
        }
        public void Push(T a) // Добавление элемента в стек
        {
            if (StackEx.Count() + 1 <= size) // Если стек не заполнен, добавить элемент
                StackEx.Push(a);
            else
                throw new ArgumentException("Stack is full");
        }
        public void PopOut()
        {
            if (StackEx.Count>0) StackEx.Pop(); // Убрать элемент из стека от головы, если стек не пуст.
            else throw new IndexOutOfRangeException("No elements to pop out in stack");
        }
        public void print() // Вывод стека
        {
            T[] stack1 = StackEx.ToArray();
            for (int i = stack1.Length - 1; i >= 0; i--)
                Console.Write(stack1[i] + " ");
            Console.WriteLine();
        }
        public StackG(StackG<T> first, StackG<T> second) // Объединение стеков
        {
            T[] stack1 = first.StackEx.ToArray();
            T[] stack2 = second.StackEx.ToArray();
            this.size = first.StackEx.Count() + second.StackEx.Count();
            StackEx = new Stack<T>(size);

            for (int i = stack1.Length - 1; i >= 0; i--) // Заполнение первой части стека
                Push(stack1[i]);

            for (int i = stack2.Length - 1; i >= 0; i--)  // Заполнение второй части стека
                Push(stack2[i]);
        }
    }
}
