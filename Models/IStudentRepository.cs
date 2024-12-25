namespace APIDemoStudent.Models
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Search(String name, Gender? gender);
        Task<Student> GetStudent(int StudentId);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student>GetStudentByEmail(string email);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int StudentId);
    }
}
