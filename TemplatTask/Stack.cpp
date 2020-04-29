#include <iostream>
using namespace std;
#include "Stack_Class.h"

int main()
{
    Stack<int> StackEx(5);
    StackEx.push(3);
    StackEx.push(4);
    StackEx.merge(StackEx);
    StackEx.print();

    return 0;
}