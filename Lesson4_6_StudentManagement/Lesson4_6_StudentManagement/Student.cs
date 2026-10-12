using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_6_StudentManagement
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string AvatarPath { get; set; }

        public Student()
        {
        }

        public Student(string studentId, string fullName, int age, string gender, string avatarPath = "")
        {
            StudentId = studentId;
            FullName = fullName;
            Age = age;
            Gender = gender;
            AvatarPath = avatarPath;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
