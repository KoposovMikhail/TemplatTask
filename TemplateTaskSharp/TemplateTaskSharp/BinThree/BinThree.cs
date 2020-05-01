using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BinThree
{
    class BinTree<T> where T : IComparable<T>
    {
       BinTree<T> parentnode, leftchild, rightchild;
       T value;
        public BinTree(T value) // Инициализация дерева значением вершины
        {
            this.value = value;
        }
        public override string ToString() // Для CompareTo()
        {
            return value.ToString();
        }

        public void Push(T value) // Добавление вершины в дерево
        {
            if (value.CompareTo(this.value) < 0)
            {
                if (leftchild == null) leftchild = new BinTree<T>(value);
                else 
                if (leftchild != null) leftchild.Push(value);
            }
            else
            {
                if (rightchild == null) rightchild = new BinTree<T>(value);
                else
                if (rightchild != null) rightchild.Push(value);
            }
        }
        public bool Pop(T value) // Удаление вершины со значением value
        {
            BinTree<T> tree = Search(value);
            if (tree == null) return false; // Если вершины нет в дереве 
            BinTree<T> curTree;
            if (tree == this)
            {
                if (tree.rightchild != null) curTree = tree.rightchild;
                else curTree = tree.leftchild;
                while (curTree.leftchild != null) curTree = curTree.leftchild;
                T temp = curTree.value;
                Pop(temp);
                tree.value = temp;
                return true;
            }
            if (tree.leftchild == null && tree.rightchild == null && tree.parentnode != null)
            {
                if (tree == tree.parentnode.leftchild) tree.parentnode.leftchild = null;
                else tree.parentnode.rightchild = null;
                return true;
            }
            if (tree.leftchild != null && tree.rightchild == null)
            {
                tree.leftchild.parentnode = tree.parentnode;
                if (tree == tree.parentnode.leftchild) tree.parentnode.leftchild = tree.leftchild;
                else if (tree == tree.parentnode.rightchild) tree.parentnode.rightchild = tree.leftchild;
                return true;
            }
            if (tree.leftchild == null && tree.rightchild != null)
            {
                tree.rightchild.parentnode = tree.parentnode;
                if (tree == tree.parentnode.leftchild) tree.parentnode.leftchild = tree.rightchild;
                else if (tree == tree.parentnode.rightchild) tree.parentnode.rightchild = tree.rightchild;
                return true;
            }
            if (tree.rightchild != null && tree.leftchild != null)
            {
                curTree = tree.rightchild;
                while (curTree.leftchild != null) curTree = curTree.leftchild;
                if (curTree.parentnode == tree)
                {
                    curTree.leftchild = tree.leftchild;
                    tree.leftchild.parentnode = curTree;
                    curTree.parentnode = tree.parentnode;
                    if (tree == tree.parentnode.leftchild) tree.parentnode.leftchild = curTree;
                    else if (tree == tree.parentnode.rightchild) tree.parentnode.rightchild = curTree;
                    return true;
                }
                else
                {
                    if (curTree.rightchild != null) curTree.rightchild.parentnode = curTree.parentnode;
                    curTree.parentnode.leftchild = curTree.rightchild;
                    curTree.rightchild = tree.rightchild;
                    curTree.leftchild = tree.leftchild;
                    tree.leftchild.parentnode = curTree;
                    tree.rightchild.parentnode = curTree;
                    curTree.parentnode = tree.parentnode;
                    if (tree == tree.parentnode.leftchild) tree.parentnode.leftchild = curTree;
                    else if (tree == tree.parentnode.rightchild) tree.parentnode.rightchild = curTree;
                    return true;
                }
            }
            return false;
        }
        public BinTree<T> Search(T value)
        {
            if (RecSearch(this, value) == null) throw new KeyNotFoundException(); // Выбрасываем ошибку, если вершины  нет в дереве
            else
            return RecSearch(this, value);
        }
        BinTree<T> RecSearch(BinTree<T> tree, T value) 
        {
            if (tree == null) return null;
            switch (value.CompareTo(tree.value))
            {
                case 1: return RecSearch(tree.rightchild, value); // value > текущего узла, переходим к правому потомку
                case -1: return RecSearch(tree.leftchild, value);// value < текущего узла, переходим к левому потомку
                case 0: return tree; // вершина найдена
                default: return null; // вершины нет в дереве
            }
        }
        public void Print()
        {
            RecPrint(this); // Обход по вершинам дерева для вывода по возрастанию
            Console.Write("\n");
        }
        void RecPrint(BinTree<T> btree_current) // Рекурсивный вывод вершин по возрастанию, btree_current - текущая вершина
        {
            if (btree_current == null) return; // Если дошли до несуществующей вершины

            RecPrint(btree_current.leftchild); // Переход к левому потомку
            Console.Write(btree_current + " ");
            if (btree_current.rightchild != null)
                RecPrint(btree_current.rightchild); // Переход к правому потомку
        }
        public void PrintLeaves() // Вывод всех листьев дерева, обход аналогичен обходу в предыдущем методе
        {
            RecPrintLeaves(this);
            Console.Write("\n");
        }
        void RecPrintLeaves(BinTree<T> btree_current)
        {
            if (btree_current == null) return; // Если дошли до несуществующей вершины

            RecPrintLeaves(btree_current.leftchild); // Переход к левому потомку
            if (btree_current.leftchild==null&&btree_current.rightchild==null)
            Console.Write(btree_current + " ");
            if (btree_current.rightchild != null)
                RecPrintLeaves(btree_current.rightchild); // Переход к правому потомку
        }
    }
}