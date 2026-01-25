#include <iostream>
#include <stack>
#include <queue>
#include <map>
using namespace std;


int main()
{
	int My_Array[4] = { 10,20,30,40 };
	for (int i = 0; i < size(My_Array); i++)
	{		
		cout<<My_Array[i]<<endl;
    }
	cout << "******************************************************\n";
	stack<int> My_Stack;
	My_Stack.push(1);
	My_Stack.push(2);
	My_Stack.push(3);
	My_Stack.push(4);
	int _size = size(My_Stack);
	for (int i = 0; i < _size; i++)
	{
		cout << My_Stack.top()<<endl;
		My_Stack.pop();
	}
	cout << "******************************************************\n";
	queue<int> My_Queue;
	My_Queue.push(1);
	My_Queue.push(2);
	My_Queue.push(3);
	My_Queue.push(4);
	int _Qsize = size(My_Queue);
	for (int i = 0; i < _Qsize; i++)
	{
		cout << My_Queue.front() << endl;
		My_Queue.pop();
	}
	cout << "******************************************************\n";
	union MyUnion
	{
		int   intNumber;
		float FloatNumber;
		char  CharType;
	};
	cout << sizeof(MyUnion) << endl;

	MyUnion _union;

	_union.intNumber = 50000;
	_union.CharType = 'c';
	_union.FloatNumber = 4.44;

	cout << _union.intNumber<<endl;
	cout << _union.FloatNumber << endl;
	cout << _union.CharType << endl;

	cout << "******************************************************\n";

	map<string, int>Students_Grade;

	Students_Grade["ahmed"] = 10;
	Students_Grade["salah"] = 20;
	Students_Grade["Mustapha"] = 30;

	
	for (pair<string,int> student : Students_Grade)
	{
		cout << student.first << " " << student.second << endl;
	}
	cout << "****************** LInked List ********************\n";
	 
	class Node
	{
  	    public: int Value;
		Node* Next=nullptr;
		Node(int value)
		{
			this->Value = value;	
		}
	};
	Node Node1 = Node(10);
	Node Node2 = Node(20);
	Node Node3 = Node(30);

	Node* Head = &Node1;
	Node1.Next = &Node2;
	Node2.Next = &Node3;
	
	while (Head!= nullptr)
	{
		cout << "Node " << Head->Value << endl;
		Head = Head->Next;
	}


	cout << "****************** Doubly LInked List ********************\n";



	class DoublyNode
	{
	public: 
		  int Value;
		  DoublyNode* Next = nullptr;
		  DoublyNode* Previous = nullptr;
		  DoublyNode(int value)
		  {
			  this->Value = value;
		  }
	};
	DoublyNode _Node1 = DoublyNode(10);
	DoublyNode _Node2 = DoublyNode(20);
	DoublyNode _Node3 = DoublyNode(30);

	DoublyNode* _Head = &_Node1;
	_Node1.Previous = _Head;
	_Node2.Previous = &_Node1;
	_Node1.Next     = &_Node2;
	_Node3.Previous = &_Node2;
	_Node3.Next = nullptr;

	while (_Head != nullptr)
	{
		cout << "prev :" << _Head->Previous << " current " << _Head->Value << " Next " << _Head->Next << endl;
		DoublyNode* Current = _Head;
		_Head = Current->Next;
		_Head->Previous = Current;
		
	}

}
