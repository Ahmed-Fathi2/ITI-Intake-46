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
        real=_real;
    }
    int GetReal() const
    {
        return real;
    }
    void SetImg(int _img)
    {
        img=_img;
    }
    int GetImg() const
    {
        return img;
    }
    void Print()
    {
         if (real == 0 && img == 0)
            cout << 0 << endl;

        else if (real == 0 && img == 1)
            cout << "i" << endl;

        else if (real == 0 && img == -1)
            cout << "-i" << endl;

        else if (real == 0)
            cout << img << "i" << endl;

        else if (img == 0)
            cout << real << endl;

        else if (img == 1)
            cout << real << "+i" << endl;

        else if (img == -1)
            cout << real << "-i" << endl;

        else if (img < 0)
            cout << real << img << "i" << endl;

        else
            cout << real << "+" << img << "i" << endl;


    }

    Complex Add(const Complex& right) const
    {
        Complex result;
        result.real= (*this).real +right.real;
        result.img=img+right.img;
        return result;
    }

};

Complex AddComplex(const Complex& left,const Complex& right)
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
    Complex c1,c2,c3;

    c1.SetReal(3);
    c1.SetImg(4);

    int tmp;
    cout<<"Enter real\n";
    cin>>tmp;
    c2.SetReal(tmp);
    cout<<"Enter img\n";
    cin>>tmp;
    c2.SetImg(tmp);


    //c3=c1.Add(c2);

    c3=AddComplex(c1,c2);

    c1.Print();
    c2.Print();
    c3.Print();
    return 0;
}
