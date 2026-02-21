#include"graphics.h"
#include<iostream>
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
        x=y=0;
    }
    Point(int _x,int _y)
    {
        x=_x;y=_y;
    }

    ~Point(){}

    Point(const Point& old)
    {
        x=old.x;
        y=old.y;

    }
};

class MyLine
{
    private:
    Point start;
    Point end;
    int myColor;
    public:
    void SetStart(Point _start)
    {
        start=_start;
    }
    Point GetStart()
    {
        return start;
    }
    void SetEnd(Point _end)
    {
        end=_end;
    }
    Point GetEnd()
    {
        return end;
    }
    void SetMyColor(int _mycolor){myColor=_mycolor;}
    int GetMyColor(){return myColor;}
    MyLine()
    {

        myColor=0;
    }

    MyLine(int x1,int y1,int x2,int y2,int _color):start(x1,y1),end(x2,y2)
    {

        myColor=_color;


    }
    ~MyLine(){}
    MyLine(const MyLine& old)
    {
        start=old.start;
        end=old.end;
        myColor=old.myColor;
    }
    void Draw()
    {
        setcolor(myColor);
        line(start.GetX(),start.GetY(),end.GetX(),end.GetY());
    }

};

class Rect
{
    private:
    Point ul;
    Point lr;
    int myColor;
    public:
    Rect()
    {
        myColor=0;
    }
    Rect(int x1,int y1,int x2,int y2,int _color)
    :ul(x1,y1),lr(x2,y2)
    {
        myColor=_color;
    }
    ~Rect(){}
    Rect(Rect& old){}
    void Draw()
    {
        setcolor(myColor);
        rectangle(ul.GetX(),ul.GetY(),lr.GetX(),lr.GetY());
    }
};

class MyCircle
{
    int radius;
    Point center;
    int myColor;
    public:
    MyCircle(int x1,int y1,int color,int _raduis):center(x1,y1){
    myColor = color;
    radius = _raduis;
    }
    void Draw()
    {
        setcolor(myColor);
        circle(center.GetX(),center.GetY(),myColor);
    }
    MyCircle(const MyCircle& old)
    {
        radius=old.radius;
        center=old.center;
        myColor=old.myColor;
    }

};
class MyTri
{
    Point p1;
    Point p2;
    Point p3;
    int myColor;
    public:
    MyTri(int x1,int y1,int x2,int y2,int x3,int y3,int _color):
        p1(x1,y1),p2(x2,y2),p3(x3,y3){
        myColor = _color;
    }
    void Draw()
    {
        setcolor(myColor);
        line(p1.GetX(),p1.GetY(),p2.GetX(),p2.GetY());
        line(p2.GetX(),p2.GetY(),p3.GetX(),p3.GetY());
        line(p3.GetX(),p3.GetY(),p1.GetX(),p1.GetY());
    }
    MyTri(const MyTri& old)
    {
        p1=old.p1;
        p2=old.p2;
        p3=old.p3;
        myColor=old.myColor;
    }
};


int main()
{
    initgraph();
    Rect r1(314,444,835,573,4);
    r1.Draw();

    MyCircle c1(574,362,168,2);
    c1.Draw();

    MyLine l1(658,362,618,100,2);
    l1.Draw();

    MyLine l2(489,362,530,100,2);
    l2.Draw();
    MyCircle c2(574,100,88,2);
    c2.Draw();

    MyTri t1(775,474,813,540,737,540,2);
    t1.Draw();

    return 0 ;
}
