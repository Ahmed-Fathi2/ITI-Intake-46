using Lab1.Entity;


namespace Lab1;
public class Helper
{

    public static IEnumerable<Student> SortStudent(
      int sortByChoice,
      int sortTypeChoice,
      IEnumerable<Student> students)
    {
        IEnumerable<Student> sorted = students;

        switch (sortByChoice)
        {
            case 1:
                sorted = sortTypeChoice == 1
                    ? students.OrderBy(s => s.Id)
                    : students.OrderByDescending(s => s.Id);
                break;

            case 2:
                sorted = sortTypeChoice == 1
                    ? students.OrderBy(s => s.FName)
                    : students.OrderByDescending(s => s.FName);
                break;

            case 3:
                sorted = sortTypeChoice == 1
                    ? students.OrderBy(s => s.Salary)
                    : students.OrderByDescending(s => s.Salary);
                break;

            case 4:
                sorted = sortTypeChoice == 1
                    ? students.OrderBy(s => s.Age)
                    : students.OrderByDescending(s => s.Age);
                break;

            default:
                //Console.WriteLine("Invalid choice");
                return students;
        }

        return sorted;
    }

}
