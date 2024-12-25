using Microsoft.EntityFrameworkCore;

namespace APIDemoStudent.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await _appDbContext.Students.AddAsync(student);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(int studentId)
        {
            var result = await _appDbContext.Students
                .FirstOrDefaultAsync(e => e.StudentId == studentId);

            if (result != null) // Fixed the null check logic
            {
                _appDbContext.Students.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await _appDbContext.Students
                .FirstOrDefaultAsync(e => e.StudentId == studentId);
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            return await _appDbContext.Students
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _appDbContext.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> Search(string name, Gender? gender)
        {
            IQueryable<Student> query = _appDbContext.Students;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                    || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await _appDbContext.Students
                .FirstOrDefaultAsync(e => e.StudentId == student.StudentId);

            if (result != null)
            {
                result.FirstName = student.FirstName;
                result.LastName = student.LastName;
                result.Email = student.Email;
                result.DateOfBirth = student.DateOfBirth;
                result.Gender = student.Gender;

                if (student.DepartmentId != 0)
                {
                    result.DepartmentId = student.DepartmentId;
                }

                result.Photopath = student.Photopath;

                await _appDbContext.SaveChangesAsync(); // Save changes after updating the entity
                return result; // Return the updated entity
            }

            return null; // Return null if the student was not found
        }
    }
}
