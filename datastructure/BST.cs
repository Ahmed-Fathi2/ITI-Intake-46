#include <iostream>
#include <string>
using namespace std;

// =========================
//     Employee Class
// =========================

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
        cout << "Code: " << code << ", Name: " << name << endl;
    }
};



// =========================
//     Binary Tree Class
// =========================

class BinaryTree {
private:
    Employee* pParent;

    Employee* insert(Employee* pRoot, Employee* data) {
        if (pRoot == NULL) {
            data->pLeft = NULL;
            data->pRight = NULL;
            return data;
        }
        else {
            if (data->getCode() <= pRoot->getCode())
                pRoot->pLeft = insert(pRoot->pLeft, data);
            else
                pRoot->pRight = insert(pRoot->pRight, data);

            return pRoot;
        }
    }

    Employee* findMin(Employee* node) {
        while (node && node->pLeft != NULL)
            node = node->pLeft;
        return node;
    }

    Employee* deleteRec(Employee* root, int key) {
        if (root == NULL)
            return NULL;

        if (key < root->getCode()) {
            root->pLeft = deleteRec(root->pLeft, key);
        }
        else if (key > root->getCode()) {
            root->pRight = deleteRec(root->pRight, key);
        }
        else {

            // Case 1: No children
            if (root->pLeft == NULL && root->pRight == NULL) {
                delete root;
                return NULL;
            }

            // Case 2: One child
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

            // Case 3: Two children
            Employee* successor = findMin(root->pRight);
            root->setCode(successor->getCode());
            root->pRight = deleteRec(root->pRight, successor->getCode());
        }

        return root;
    }

    Employee* searchRec(Employee* root, int code) {
        if (root == NULL)
            return NULL;

        if (code == root->getCode())
            return root;

        else if (code < root->getCode())
            return searchRec(root->pLeft, code);

        else
            return searchRec(root->pRight, code);
    }


    void inorder(Employee* root) {
        if (root == NULL)
            return;
        inorder(root->pLeft);
        root->print();
        inorder(root->pRight);
    }

public:

    BinaryTree() {
        pParent = NULL;
    }

    void insertNode(Employee* data) {
        pParent = insert(pParent, data);
    }

    void deleteNode(int key) {
        pParent = deleteRec(pParent, key);
    }

    Employee* searchTree(int code) {
        return searchRec(pParent, code);
    }

    void displayInorder() {
        inorder(pParent);
    }
};



// =========================
//           MAIN
// =========================

int main() {

    BinaryTree bt;

    // Adding Employees
    bt.insertNode(new Employee(10));
    bt.insertNode(new Employee(5));
    bt.insertNode(new Employee(15));
    bt.insertNode(new Employee(3));
    bt.insertNode(new Employee(7));

    cout << "Inorder Traversal of Employees:\n";
    bt.displayInorder();

    cout << "\nSearching for Employee with code 7:\n";
    Employee* emp = bt.searchTree(7);
    if (emp)
        emp->print();
    else
        cout << "Not Found\n";

    cout << "\nDeleting Employee with code 5\n";
    bt.deleteNode(5);

    cout << "Inorder after deletion:\n";
    bt.displayInorder();

    return 0;
}
