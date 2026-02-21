#include <iostream>
using namespace std;

class Employee {
private:
    int code;

public:
    Employee* pLeft;
    Employee* pRight;

    Employee(int c) {
        code = c;
        pLeft = pRight = NULL;
    }

    int getCode() {
        return code;
    }

    void setCode(int c) {
        code = c;
    }


    void print() {
        cout << "Code: " << code << endl;
    }
};


class  BinaryTree{
    private:
    Employee *pParent;


    Employee* InsertHelper(Employee *pRoot , Employee *data)
    {
        if(pRoot==NULL)
        {
            data->pLeft=NULL;
            data->pRight=NULL;
            return data;
        }
        else if(data->getCode()<=pRoot->getCode())
        {
            pRoot->pLeft= InsertHelper(pRoot->pLeft,data);
        }
        else
        {
            pRoot->pRight= InsertHelper(pRoot->pRight,data);
        }

        return pRoot;

    }


      Employee* DeleteHelper(Employee* root, int key) {
        if (root == NULL)
            return NULL;

        if (key < root->getCode()) {
            root->pLeft = DeleteHelper(root->pLeft, key);
        }
        else if (key > root->getCode()) {
            root->pRight = DeleteHelper(root->pRight, key);
        }
        else {

            if (root->pLeft == NULL && root->pRight == NULL) {
                delete root;
                return NULL;
            }


            else if (root->pLeft == NULL) {
                Employee* temp = root->pRight;
                delete root;
                return temp;
            }
            else if (root->pRight == NULL) {
                Employee* temp = root->pLeft;
                delete root;
                return temp;
            }

            Employee* successor = findMin(root->pRight);
            root->setCode(successor->getCode());
            root->pRight = DeleteHelper(root->pRight, successor->getCode());
        }

        return root;
    }

    void inorder(Employee* root) {
        if (root == NULL)
            return;
        inorder(root->pLeft);
        root->print();
        inorder(root->pRight);
    }

    Employee* Search(Employee* root, int code) {
        if (root == NULL)
            return NULL;

        if (code == root->getCode())
            return root;

        else if (code < root->getCode())
            return Search(root->pLeft, code);

        else
            return Search(root->pRight, code);
    }

    int getHeightHelper(Employee* temp){
		if (temp == NULL)
			return -1;

		int Left_SubTree = getHeightHelper(temp->pLeft);
		int Right_SubTree = getHeightHelper(temp->pRight);

		return 1 + max(Left_SubTree, Right_SubTree);
	}
    public:
    BinaryTree()
    {
      pParent=NULL;
    }

    Employee* findMin(Employee* node) {
        while (node && node->pLeft != NULL)
            node = node->pLeft;
        return node;
    }

    void Insert(Employee *data)
    {
        pParent = InsertHelper(pParent, data);
    }


    void Delete(int key) {

        if (!Search(pParent, key)) {
        cout << "Element not found!\n";
        return;
    }
        pParent = DeleteHelper(pParent, key);
    }


   void displayInorder() {
        inorder(pParent);
    }

    int getHeight(){
		if (pParent == NULL)
			return -1;
		else
			return getHeightHelper(pParent);
	}


};

int main()
{
       BinaryTree bt;

    // Adding Employees
    bt.Insert(new Employee(10));
    bt.Insert(new Employee(5));
    bt.Insert(new Employee(15));
    bt.Insert(new Employee(3));
    bt.Insert(new Employee(7));

    cout << "Inorder Traversal of Employees:\n";
    bt.displayInorder();



    cout << "\nDeleting Employee with code 200\n";
    bt.Delete(5);

    cout<<"\n\n";

    cout << "Inorder after deletion:\n";
    bt.displayInorder();
    cout<<"\nHeight is :"<<bt.getHeight()<<"\n\n";

    return 0;
}
