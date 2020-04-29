#include <iostream>

template <typename T>
class Stack
{
private:
    T* StackArr;                     
    int size;                   
    int top;                         
public:
    Stack(int size);                 
    Stack(const Stack<T>& second);          
 //   ~Stack();                        
    void push(T value);    
    void pop();               
    void print();   
    void merge(const Stack<T>& second);
};

template <typename T>
Stack<T>::Stack(int maxSize)  
{ 
    size = maxSize;
    StackArr = new T[size];
    top = 0; 
}

template <typename T>
Stack<T>::Stack(const Stack<T>& otherStack) 
{
   top = otherStack.top;
   StackArr = new T[otherStack.size];
   StackArr = otherStack.StackArr;
}

//template <typename T>
//Stack<T>::~Stack()
//{
//    delete[] StackArr;
//}

template <typename T>
 void Stack<T>::push(T value)
{
     if (top >= size)
        throw out_of_range("Stack is full");
     StackArr[top++] = value;
}


template <typename T>
 void Stack<T>::pop()
{ 
     if (top <= 0)
         throw out_of_range("There are no elements in stack to pop out");
     top--;
}

template <typename T>
 void Stack<T>::print()
{
     for (int i = 0; i <top; i++)
         cout << StackArr[i] << " ";
     cout << endl;
}
 
 template<class T>
 void Stack<T>:: merge(const Stack<T> & SecondStack)
 {  
     T* MergedArr = new T[top + SecondStack.top];
     int i = 0;

     while (i < top)
     {
         MergedArr[i] = StackArr[i];
         i++;
     }

     while (i < top + SecondStack.top)
     {
         MergedArr[i] = SecondStack.StackArr[i - top];
         i++;
     }
     top = top + SecondStack.top;
     StackArr = MergedArr;
 }






