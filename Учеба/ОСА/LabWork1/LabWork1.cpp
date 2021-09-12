// LabWork1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>


class Stack 
{
private:
	int N = 10;
	int* arr;
	int top; //переменная для вершины стэка
public:
	Stack() 
	{
		top = -1;
		arr = new int[N];
	}

	void Push(int chislo) 
	{
		if (top == N - 1) //если значение вершины равно размеру массива, то
		{
			printf("Stack Overflow \n");
		}
		else  //иначе добавляем в стек
		{
			top++;
			arr[top] = chislo;
		}
	}

	void Pop()
	{
		if (top == -1) //если элементов в стеке нет, то
		{
			printf("Stack null \n");

		}
		else
		{
			printf("%d \n", arr[top]); //иначе выводим элемент
			top--;			
		}
	}

};

class List 
{
private:
	int N = 3;
	int* arr;
	int top; //переменные головы и хвоста 
	int bot;
public:
	List() 
	{
		top = 0;
		bot = 0;
		arr = new int[N];
	}
	void Add(int chislo)
	{
		if (top == (bot + 1) % N) //если в очереди есть место, то 
		{
			printf("List overflow \n");
		}
		else 
		{
			arr[bot] = chislo; //добавляем число
			bot = (bot + 1) % N;
		}
	}
	void Remove() 
	{
		if (top != bot) //если в очереди есть элементы, то выводим их
		{
			printf("%d \n", arr[top]);
			top = (top + 1) % N;
		}
		else 
		{
			printf("List null \n");
		}
	}

};
int main()
{
	Stack stack;
	stack.Pop();
	stack.Push(15);
	stack.Push(1);
	stack.Push(5);
	stack.Pop();
	stack.Pop();
	stack.Pop();

	printf("\nNow List \n \n");
	List list;
	list.Remove();
	list.Add(63);
	list.Add(3);
	list.Add(3);
	list.Remove();
	list.Remove();

	list.Remove();

}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
