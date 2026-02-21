namespace Lab2.Entity
{
    public class Department
    {
        
        public int DeptId { get; set; }
        public string DeptName { get; set; }=string.Empty;
       
        public override string ToString()
        {
            return $"Department Id: {DeptId}, Department Name: {DeptName}";
        }
        
    }
}
