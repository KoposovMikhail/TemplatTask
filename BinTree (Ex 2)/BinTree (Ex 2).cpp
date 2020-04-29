#include <iostream>
#include "BinTree_Class.h"
using namespace std;

int main()
{
	BinTree<int> th(8);
	th.Push(4);
	th.Push(2);
	th.Push(3);
	th.Push(10);
	th.Push(6);
	th.Push(7);
	th.PrintTree();
	th.PrintTree2(0);
   
}


