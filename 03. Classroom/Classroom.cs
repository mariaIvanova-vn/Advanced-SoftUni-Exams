using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public int Capacity { get; set; }

        public int Count { get { return students.Count; } }

        public Classroom(int capacity)
        {
            students = new List<Student>();
            Capacity = capacity;
        }

        public string RegisterStudent(Student student)
        {
            if (Count<Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student=students.FirstOrDefault(s=>s.FirstName == firstName && s.LastName == lastName);
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            Student student = students.FirstOrDefault(s => s.Subject == subject);
            StringBuilder sb=new StringBuilder();
            if (student==null)
            {
                return "No students enrolled for the subject";
            }
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var item in students)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }
            return sb.ToString();
        }

        public int GetStudentsCount() => Count;
       
        public Student GetStudent(string firstName, string lastName) =>
           students.FirstOrDefault(students=>students.FirstName == firstName && students.LastName == lastName);

        
    }
}
