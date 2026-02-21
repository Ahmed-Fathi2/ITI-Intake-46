// 01-Create an interface for a Student with:
// - id (number)
// - name (string)
// - email (string, optional)
// - isActive (boolean)
// - grades (array of numbers)
var students = [];
function addStudent(student) {
    students.push(student);
}
function CalculateAvge(grades) {
    if (grades.length === 0) {
        return 0;
    }
    var result = 0;
    for (var i = 0; i < grades.length; i++) {
        result += grades[i];
    }
    return result / grades.length;
}
function getStatus(avgGrade) {
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
addStudent({ id: 1, name: "fathi", email: "fathi@test.com", isActive: true, grades: [20, 30, 40, 150] });
addStudent({ id: 1, name: "heba", email: "bebo@test.com", isActive: true, grades: [30, 50, 60, 90] });
// console.log(students[0])
var avg = CalculateAvge(students[0].grades);
console.log(getStatus(avg));
