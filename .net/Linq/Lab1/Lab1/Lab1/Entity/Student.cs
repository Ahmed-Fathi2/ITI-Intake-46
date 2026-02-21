namespace Lab1.Entity;
public class Student
{
    public int Id { get; set; }
    public string FName { get; set; }=string.Empty;
    public string LName { get; set; } = string.Empty;

    public int Age { get; set; }
    public decimal Salary { get; set; }

    public int trackId { get; set; }
    public Track track { get; set; } = default!;

    public override string ToString()
    {
        return $"ID={Id} : FNAme={FName}   :LName={LName}   :Age={Age}  :Salary={Salary}  :TrackId={trackId} ";
    }
}
