#include "graphics.h"
#include <conio.h>
#include <iostream>
using namespace std;

using namespace std;

class Point
{
private:
    int x;
    int y;
public:
    void SetX(int _x){x=_x;}
    int GetX(){return x;}
    void SetY(int _y){y=_y;}
    int GetY(){return y;}


    Point()
    {
        x = y = 0;
        cout << "point def ctor\n";
    }
    Point(int _x, int _y)
    {
        x = _x; y = _y;
        cout << "point 2p ctor\n";
    }


    Point(const Point& old)
    {
        x = old.x;
        y = old.y;
        cout << "point cctor\n";
    }


    ~Point()
    {
        cout << "point dest\n";
    }
};

class Shape
{
protected:
    int myColor;
public:
    void SetMyColor(int _mycolor){myColor = _mycolor;}
    int GetMyColor(){return myColor;}

    Shape()
    {
        myColor = 0;
        cout << "shape def ctor\n";
    }

    Shape(int _color)
    {
        myColor = _color;
        cout << "shape 1p ctor\n";
    }

    Shape(const Shape& old)
    {
        myColor = old.myColor;
        cout << "shape cctor\n";
    }

    virtual ~Shape()
    {
        cout << "shape dest\n";
    }

    virtual void Draw() = 0; // pure virtual
};


class MyLine : public Shape
{
private:
    Point start;
    Point end;
public:
    void SetStart(Point _start){start = _start;}
    Point GetStart(){return start;}
    void SetEnd(Point _end){end = _end;}
    Point GetEnd(){return end;}

    MyLine()
    {
        cout << "line def ctor\n";
    }

    MyLine(int x1, int y1, int x2, int y2, int _color)
        : start(x1, y1), end(x2, y2), Shape(_color)
    {
        cout << "line 5p ctor\n";
    }

    MyLine(const MyLine& old)
        : Shape(old)
    {
        start = old.start;
        end = old.end;
        cout << "line cctor\n";
    }

    ~MyLine()
    {
        cout << "line dest\n";
    }

    void Draw()
    {
        setcolor(myColor);
        line(start.GetX(), start.GetY(), end.GetX(), end.GetY());
    }
};


class Rect : public Shape
{
private:
    Point ul; // upper-left
    Point lr; // lower-right
public:
    Rect()
    {
        cout << "rect def ctor\n";
    }

    Rect(int x1, int y1, int x2, int y2, int _color)
        : ul(x1, y1), lr(x2, y2), Shape(_color)
    {
        cout << "rect 5p ctor\n";
    }

    Rect(const Rect& old)
        : Shape(old)
    {
        ul = old.ul;
        lr = old.lr;
        cout << "rect cctor\n";
    }

    ~Rect()
    {
        cout << "rect dest\n";
    }

    void Draw()
    {
        setcolor(myColor);
        rectangle(ul.GetX(), ul.GetY(), lr.GetX(), lr.GetY());
    }
};


class MyCircle : public Shape
{
private:
    int radius;
    Point center;
public:
    MyCircle()
    {
        radius = 0;
        cout << "circle def ctor\n";
    }

    MyCircle(int x, int y, int _radius, int _color)
        : center(x, y), Shape(_color)
    {
        radius = _radius;
        cout << "circle 4p ctor\n";
    }

    MyCircle(const MyCircle& old)
        : Shape(old)
    {
        radius = old.radius;
        center = old.center;
        cout << "circle cctor\n";
    }

    ~MyCircle()
    {
        cout << "circle dest\n";
    }

    void Draw()
    {
        setcolor(myColor);
        circle(center.GetX(), center.GetY(), radius);
    }
};


class MyTri : public Shape
{
private:
    Point p1;
    Point p2;
    Point p3;
public:
    MyTri()
    {
        cout << "tri def ctor\n";
    }

    MyTri(int x1, int y1, int x2, int y2, int x3, int y3, int _color)
        : p1(x1, y1), p2(x2, y2), p3(x3, y3), Shape(_color)
    {
        cout << "tri 7p ctor\n";
    }

    MyTri(const MyTri& old)
        : Shape(old)
    {
        p1 = old.p1;
        p2 = old.p2;
        p3 = old.p3;
        cout << "tri cctor\n";
    }

    ~MyTri()
    {
        cout << "tri dest\n";
    }

    void Draw()
    {
        setcolor(myColor);
        line(p1.GetX(), p1.GetY(), p2.GetX(), p2.GetY());
        line(p2.GetX(), p2.GetY(), p3.GetX(), p3.GetY());
        line(p3.GetX(), p3.GetY(), p1.GetX(), p1.GetY());
    }
};

class Picture
{
private:
    MyLine* lPtr; int lSize;
    Rect* rPtr; int rSize;
    MyCircle* cPtr; int cSize;
    MyTri* tPtr; int tSize;

public:
    Picture()
    {
        lPtr = NULL; lSize = 0;
        rPtr = NULL; rSize = 0;
        cPtr = NULL; cSize = 0;
        tPtr = NULL; tSize = 0;
        cout << "picture def ctor\n";
    }

    void SetLines(MyLine* _lPtr, int _lSize)
    {
        lPtr = _lPtr;
        lSize = _lSize;
    }

    void SetRects(Rect* _rPtr, int _rSize)
    {
        rPtr = _rPtr;
        rSize = _rSize;
    }

    void SetCircles(MyCircle* _cPtr, int _cSize)
    {
        cPtr = _cPtr;
        cSize = _cSize;
    }

    void SetTris(MyTri* _tPtr, int _tSize)
    {
        tPtr = _tPtr;
        tSize = _tSize;
    }

    void Execute()
    {
        for (int i = 0; i < lSize; i++)
            lPtr[i].Draw();

        for (int i = 0; i < rSize; i++)
            rPtr[i].Draw();

        for (int i = 0; i < cSize; i++)
            cPtr[i].Draw();

        for (int i = 0; i < tSize; i++)
            tPtr[i].Draw();
    }
};


int main()
{
    initgraph();



    MyLine larr[2] = { MyLine(658,362,618,100,2), MyLine(489,362,530,100,2) };
    Rect rarr[1] = { Rect(314,444,835,573,4) };
    MyCircle carr[2] = { MyCircle(574,362,168,2),MyCircle(574,100,88,2)};
    MyTri tarr[1] = { MyTri(775,474,813,540,737,540,2) };

    Picture p1;


    p1.SetLines(larr, 2);
    p1.SetRects(rarr, 1);
    p1.SetCircles(carr, 2);
    p1.SetTris(tarr, 1);


    p1.Execute();

    getch();



    return 0;
}
