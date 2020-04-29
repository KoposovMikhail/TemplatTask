#pragma once
#include <iostream>
#include <vector>
using namespace std;

template <typename T>
class BinTree
{
private:
	struct point
	{
		T value;
		int parentnode = -1;
		int leftchild = -1;
		int rightchild = -1;
	};

	vector <point> NodeArr;
public:
	BinTree(T root)
	{
		point x;
		x.value = root;
		NodeArr.push_back(x);
	}
	int Search(T value)
	{
		int i = 0;
		bool notfound = true;
		int r = -1;
		while (notfound)
		{
			if (value < NodeArr[i].value)
			{
				if (NodeArr[i].value == value)
				{
					notfound = false;
					r = i;
				}
				else
					if (NodeArr[i].leftchild == -1)
						notfound = false;
					else
						i = NodeArr[i].leftchild;
			}
			else
			{
				if (NodeArr[i].value == value)
				{
					notfound = false;
					r = i;
				}
				else
					if (NodeArr[i].rightchild == -1)
						notfound = false;
					else
						i = NodeArr[i].rightchild;
			}
		}
		return r;
	}
	void Pop(T value)
	{
		int i = BinTree.Search(value);
		if (i != -1)
		{
			if (NodeArr[i].leftchild == -1 && NodeArr[i].rightchild == -1)
				NodeArr.erase(NodeArr.begin() + i);
			else
				if (NodeArr[i].leftchild == -1)
				{
					int j = NodeArr[i].rightchild;

					NodeArr[i].value = NodeArr[NodeArr[i].rightchild].value;
					NodeArr[i].value = NodeArr[NodeArr[i].rightchild].rightchild;
					NodeArr[i].value = NodeArr[NodeArr[i].rightchild].leftchild;
					NodeArr[NodeArr[i].rightchild].parentnode = i;
					NodeArr.erase(NodeArr.begin() + j);
				}
				else
					if (NodeArr[i].rightchild == -1)
					{
						int j = NodeArr[i].leftchild;
						NodeArr[i].value = NodeArr[NodeArr[i].leftchild].value;
						NodeArr[i].value = NodeArr[NodeArr[i].leftchild].rightchild;
						NodeArr[i].value = NodeArr[NodeArr[i].leftchild].leftchild;
						NodeArr[NodeArr[i].leftchild].parentnode = i;
						NodeArr.erase(NodeArr.begin() + j);
					}
					else
					{
						int j = NodeArr[i].rightchild;
						NodeArr[i].value = NodeArr[NodeArr[i].rightchild].value;
						NodeArr[i].value = NodeArr[NodeArr[i].rightchild].rightchild;
						int z = NodeArr[i].leftchild;
						int z1 = NodeArr[i].leftchild;
						NodeArr[i].value = NodeArr[NodeArr[i].rightchild].leftchild;
						NodeArr[NodeArr[i].rightchild].parentnode = i;
						NodeArr[NodeArr[i].leftchild].parentnode = i;
						NodeArr.erase(NodeArr.begin() + j);
						while (NodeArr[z].leftchild != -1)
							z = NodeArr[z].leftchild;
						NodeArr[z].leftchild = z1;
						NodeArr[NodeArr[z].leftchild].parentnode = z;
					}
		}
	}
	void Push(T value)
	{
		point x;
		x.value = value;

		bool notadded = true;
		int i = 0;
		while (notadded)
		{
			if (x.value <= NodeArr[i].value)
			{
				if (NodeArr[i].leftchild == -1)
				{
					NodeArr[i].leftchild = NodeArr.size();
					x.parentnode = i;
					NodeArr.push_back(x);
					notadded = false;
				}
				else
				{
					i = NodeArr[i].leftchild;
				}
			}
			else
			{
				if (NodeArr[i].rightchild == -1)
				{
					NodeArr[i].rightchild = NodeArr.size();
					x.parentnode = i;
					NodeArr.push_back(x);
					notadded = false;
				}
				else
				{
					i = NodeArr[i].rightchild;
				}
			}
		}
	}
	void PrintTree()
	{
		for (int i = 0; i < NodeArr.size(); i++)
			cout << NodeArr[i].value << '\t';

		cout << endl;
	}


	void PrintTree2(int i)
	{

		if (NodeArr[i].leftchild != -1)
			PrintTree2(NodeArr[i].leftchild);

			cout << NodeArr[i].value << "\t";
		if (NodeArr[i].rightchild != -1)

		PrintTree2(NodeArr[i].rightchild);

	}
	void PrintLeaves()
	{
		for (int i = 0; i < NodeArr.size(); i++)
			if (NodeArr[i].leftchild == -1 && NodeArr[i].rightchild == -1)
				cout << NodeArr[i].value << '\t';

		cout << endl;
	}
};






