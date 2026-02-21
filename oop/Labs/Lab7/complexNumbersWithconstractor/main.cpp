#include <iostream>

using namespace std;

class Complex
{
    private:
    int real;
    int img;

    public:

    Complex()
    {
        real=3;
        img=4;
        cout<<"New Object Is Created \n" ;

    }
    Complex(int _real , int _img)
    {
        real= _real;
        img= _img;

        cout<<"New Object Is Created \n" ;
    }
    Complex(int _num)
    {
        real=img=_num;
        cout<<"New Object Is Created \n" ;
    }
    void SetReal(int _real)
    {
        real=_real;
    }
    int GetReal()
    {
        return real;
    }
    void SetImg(int _img)
    {
        img=_img;
    }
    int GetImg()
    {
        return img;
    }
    void Print()
    {
         if (real == 0 && img == 0)
            cout <<0 << endl;

        else if (real == 0 && img == 1)
            cout <<"i" << endl;

        else if (real == 0 && img == -1)
            cout <<"-i" << endl;

        else if (real == 0)
            cout <<img << "i" << endl;

        else if (img == 0)
            cout <<real << endl;

        else if (img == 1)
            cout <<real << "+i" << endl;

        else if (img == -1)
            cout <<real << "-i" << endl;

        else if (img < 0)
            cout <<real << img << "i" << endl;

        else
            cout <<real << "+" << img << "i" << endl;


    }

    Complex Add( Complex right)
    {
        Complex result;
        result.real= (*this).real +right.real;
        result.img=img+right.img;
        return result;
    }

    ~Complex()
    {
        cout<<"Object Is Finished \n";
    }
};

Complex AddComplex( Complex left, Complex right)
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
    Complex c1,c2(6,8),c3;

    c3=AddComplex(c1,c2);

    c1.Print();
    c2.Print();
    c3.Print();

    return 0;
}
