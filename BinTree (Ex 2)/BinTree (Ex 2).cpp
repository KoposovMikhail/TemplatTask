#include <iostream>
#include "BinTree_Class.h"
using namespace std;

int main()
{
	BinTree<int> th(3);
	th.Push(9);
	th.Push(8);
	th.Push(7);
	th.Push(5);
	th.Push(1);
	th.Push(3);
	th.PrintTree();
   
}


