#include <iostream>

using namespace std;
class Complex
{
    private:
    int real;
    int img;
    public:
    void SetReal(int _real)
    {
        this->real=_real;
    }
    int GetReal() const
    {
        return this->real;
    }
    void SetImg(int _img)
    {
        img=_img;
    }
    int GetImg() const
    {
        return (*this).img;
    }
    void Print()
    {
        cout<<real<<"+"<<this->img<<"i"<<endl;
    }
    Complex Add(Complex right)
    {
        Complex result;
        result.real=this->real+right.real;
        result.img=img+right.img;
        return result;
    }
    Complex()
    {
        cout<<"complec default ctor\n";
        this->real=0;
        (*this).img=0;
    }
    Complex(int _real,int _img)
    {
        cout<<"complec 2p ctor\n";
        this->real=_real;
        img=_img;
    }
    Complex(int _num)
    {
        cout<<"complec 1p ctor\n";
        this->real=img=_num;
    }

    ~Complex()
    {
        cout<<"complex destructor\n";
    }



    Complex(const Complex& old)
    {
        real=old.real;
        img=old.img;
    }


       //c1+c2
    Complex operator+(const Complex& right)
    {
        Complex result;
        result.real=real+right.real;
        result.img=img+right.img;
        return result;

        return Complex(real+right.real,img+right.img);
    }

    //c1+10
    Complex operator+(int _num)
    {
        Complex result(this->real+_num,this->img);
        return result;
    }


    //++c1
    Complex operator++()
    {
        this->real++;
        img++;
        return *this;
    }

    //c3=c1++
    Complex operator++(int)
    {
        Complex result(real,img);
        this->real++;
        this->img++;
        return result;
    }


    //c1+=c2
    Complex operator+=(const Complex& right)
    {
        real+=right.real;
        img+=right.img;
        return *this;
    }

    //c1>c2
    int operator>(const Complex& right)
    {
        return real>right.real&& img>right.img;
    }
    //

    //c1=c2
    Complex& operator=(const Complex& right)
    {
        real=right.real;
        img=right.img;
        return *this;
    }
};

//10+c1
Complex operator+(int _num,Complex right)
{
    return right+ _num;

}
Complex AddComplex(Complex left,Complex right)
{
    Complex result;
    int r=left.GetReal()+right.GetReal();
    int i=left.GetImg()+right.GetImg();
    result.SetReal(r);
    result.SetImg(i);
    return result;
}
int main()
{
    Complex c1(3,4),c2(5,6),c3;
    c3=AddComplex(c1,c2);
    c3.Print();




    c3=c1+c2;
    c3.Print();

    c3=c1+10;
    c1.Print();
    c3.Print();


    c3=++c1;
    c3.Print();
    c1.Print();



    c3=c1++;
    c3.Print();
    c1.Print();

    c3=10+c1;
    c3.Print();


    c1+=c2;
    c1.Print();
    c2+=500;
    c2.Print();


    if(c1>c2)
    {
        cout<<"OK : C1>C2\n";
    }
    else
    {
        cout<<" C1>!C2\n";
    }

    return 0;
}
