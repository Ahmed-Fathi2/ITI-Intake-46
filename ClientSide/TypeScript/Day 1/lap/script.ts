// 01-Create an interface for a Student with:
// - id (number)
// - name (string)
// - email (string, optional)
// - isActive (boolean)
// - grades (array of numbers)

interface Student {
    id: number,
    name: string,
    email?: string,
    isActive: boolean,
    grades: Array<number>
}


let students: Student[] = [];

function addStudent(student: Student): void {
    students.push(student);
}

function CalculateAvge(grades: number[]): number {

    if (grades.length === 0) {
        return 0;
    }

    let result: number = 0;
    for (let i = 0; i < grades.length; i++) {
        result += grades[i];

    }

    return result / grades.length;
}



function getStatus(avgGrade: number): string {
    if (avgGrade >= 90) {
        return "Excellent";
    } 
    else if (avgGrade >= 70 && avgGrade < 90) {
        return "Good";
    } 
    else if (avgGrade >= 50 && avgGrade < 70) {
        return "Average";
    } 
    else {
        return "Needs improvement";
    }
}


addStudent({ id: 1, name: "fathi", email: "fathi@test.com", isActive: true, grades: [20, 30, 40, 200] });
addStudent({ id: 1, name: "heba", email: "bebo@test.com", isActive: true, grades: [30, 50, 60, 90] });

// console.log(students[0])
let avg: number = CalculateAvge(students[0].grades);

console.log(getStatus(avg));

