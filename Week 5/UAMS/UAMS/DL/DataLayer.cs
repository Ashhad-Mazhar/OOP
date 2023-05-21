using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    public class DataLayer
    {
        public static List<Student> studentList;
        public static List<DegreeProgram> programList;
        public DataLayer()
        {
            studentList = new List<Student>();
            programList = new List<DegreeProgram>();
        }
        public static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }
        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }
    }
}
