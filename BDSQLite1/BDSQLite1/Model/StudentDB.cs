using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using System.Threading.Tasks;
using SQLite;

namespace BDSQLite1.Model
{
    public class StudentDB
    {
        readonly SQLiteAsyncConnection database;

        public StudentDB(string dbpath)
        {
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<Student>().Wait();
        }

        //Retorna todos los estudiantes (list view)
        public Task<List<Student>> GetStudents()
        {
            return database.Table<Student>().ToListAsync();
        }

        //Retorno de informacion seleccionado de la lista
        public Task<Student> GetStudentById(int id)
        {
            return database.Table<Student>().Where(s => s.stdid == id).FirstOrDefaultAsync();
        }

        //Registro de estudiantes
        public Task<int> SaveStudent(Student stud)
        {
            return database.InsertAsync(stud);
        }

        //Update de estudiantes
        public Task<int> UpdateStudent(Student stud)
        {
            return database.UpdateAsync(stud);
        }

        //delete de estudiantes
        public Task<int> DeleteStudent(Student stud)
        {
            return database.DeleteAsync(stud);
        }

    }
}
