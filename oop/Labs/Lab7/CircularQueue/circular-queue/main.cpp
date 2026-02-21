#include <iostream>
using namespace std;

class CircularQueue {
private:
    int *arr;
    int capacity;
    int front;
    int rear;
    int count;

public:

    CircularQueue(int size = 5) {
        capacity = size;
        arr = new int[capacity];
        front = -1;
        rear = -1;
        count = 0;
        cout << "Constructor called\n";
    }


    ~CircularQueue() {
        delete[] arr;
        cout << "Destructor called\n";
    }


    int IsEmpty()  {
        return (count == 0);
    }


    int IsFull()  {
        return (count == capacity);
    }


    void Enqueue(int value) {
        if (IsFull()) {
            cout << "Queue is full! Cannot enqueue " << value << "\n";
            return;
        }

        if (IsEmpty())
        {
            front = 0;
            rear = 0;
        }
        else
        {

            rear = (rear + 1) % capacity;
        }

        arr[rear] = value;
        count++;


    }


    int Dequeue() {
        if (IsEmpty()) {
            cout << "Queue is empty! Cannot dequeue.\n";
            return -1;
        }

        int value = arr[front];

        if (front == rear) {

            front = rear = -1;
        }
        else
        {
            front = (front + 1) % capacity;
        }

        count--;


        return value;
    }




    void Display()  {
        if (IsEmpty()) {
            cout << "Queue is empty!\n";
            return;
        }

        cout << "Queue : ";
        int i = front;
        for (int c = 0; c < count; c++) {
            cout << arr[i] << " ";
            i = (i + 1) % capacity;
        }
        cout << "\n";
    }
};

int main() {
    CircularQueue q(5);


    q.Enqueue(10);
    q.Enqueue(20);
    q.Enqueue(30);
    q.Display();


    q.Dequeue();
    q.Display();


    q.Enqueue(40);
    q.Enqueue(50);
    q.Enqueue(60);
    q.Display();


    q.Dequeue();
    q.Enqueue(70);
    q.Display();



    return 0;
}
