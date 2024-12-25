﻿using System.Reflection;

namespace APIDemoStudent
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId {  get; set; }
        public string Photopath {  get; set; }
    }
}
