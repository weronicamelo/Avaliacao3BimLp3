using Microsoft.Data.Sqlite;
using Avaliacao3BimLp3.Database;
using Avaliacao3BimLp3.Models;
using Avaliacao3BimLp3.Repositories;

var databaseConfig = new DatabaseConfig();

var DatabaseSetup = new DatabaseSetup(databaseConfig);

var studentRepository = new StudentRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Student")
{
    if(modelAction == "List")
    {
        if(studentRepository.GetAll().Count() > 0)
        {
            Console.WriteLine("Student List");
            foreach(var student in studentRepository.GetAll())
            {
                if(student.Former)
                {
                    Console.WriteLine($"{student.Registration}, {student.Name}, {student.City}, formado");
                }
                else
                {
                    Console.WriteLine($"{student.Registration}, {student.Name}, {student.City}, não formado");
                }
            }
        }
        else
        {
            Console.WriteLine("Nenhum estudante cadastrado!");
        }
    }

    if(modelAction == "New")
    {
        Console.WriteLine("Student New");
        var registration = args[2];
        var name = args[3];
        var city = args[4];
        var former = Convert.ToBoolean(args[5]);

        var student = new Student(registration, name, city, former);

        if(studentRepository.ExistsById(args[2]))
        {
            Console.WriteLine($"Estudante com registro {args[2]} já existe");
        }
        else
        {
            studentRepository.Save(student);
            Console.WriteLine($"Estudante {name} cadastrado com sucesso");
        }
    }

    if(modelAction == "Delete")
    {
        if(studentRepository.ExistsById(args[2]))
        {
            studentRepository.Delete(args[2]);
            Console.WriteLine($"Estudante com registro {args[2]} removido com sucesso");
        }
        else
        {
            Console.WriteLine($"Estudante com registro {args[2]} não encontrado!");
        }
    }

    if(modelAction == "MarkAsFormed")
    {
        if(studentRepository.ExistsById(args[2]))
        {
            studentRepository.MarkAsFormed(args[2]);
            Console.WriteLine($"Estudante com registro {args[2]} definido como formado");
        }
        else
        {
            Console.WriteLine($"Estudante com registro {args[2]} não encontrado!");
        }
    }

    if(modelAction == "ListFormed")
    {
        if(studentRepository.GetAllFormed().Count() > 0)
        {
            foreach(var student in studentRepository.GetAllFormed())
            {
                Console.WriteLine($"{student.Registration}, {student.Name}, {student.City}, formado");
            }
        }
        else
        {
            Console.WriteLine("Nenhum estudante cadastrado!");
        }
    }

    if(modelAction == "ListByCity")
    {
        if(studentRepository.GetAllStudentByCity(args[2]).Count() > 0)
        {
            foreach(var student in studentRepository.GetAllStudentByCity(args[2]))
            {
                if(student.Former)
                {
                    Console.WriteLine($"{student.Registration}, {student.Name}, {student.City}, formado");
                }
                else
                {
                    Console.WriteLine($"{student.Registration}, {student.Name}, {student.City}, não formado");
                }
            }
        }
        else
        {
            Console.WriteLine("Nenhum estudante cadastrado!");
        }
    }

    if(modelAction == "ListByCities")
    {
        var cities = new string[args.Length - 2];
        for(int i = 2; i < args.Length; i++)
        {
            cities[i - 2] = args[i];
        }
        if(studentRepository.GetAllByCities(cities).Count() > 0)
        {
            foreach(var student in studentRepository.GetAllByCities(cities))
            {
                if(student.Former)
                {
                    Console.WriteLine($"{student.Registration}, {student.Name}, {student.City}, formado");
                }
                else
                {
                    Console.WriteLine($"{student.Registration}, {student.Name}, {student.City}, não formado");
                }
            }
        }
        else
        {
            Console.WriteLine("Nenhum estudante cadastrado!");
        }
    }

    if(modelAction == "Report")
    {
        if(args[2] == "CountByCities")
        {
            if(studentRepository.CountByCities().Count() > 0)
            {
                foreach(var student in studentRepository.CountByCities())
                {
                    Console.WriteLine($"{student.AttributeName}, {student.StudentNumber}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum estudante cadastrado!");
            }
        }
    
        if(args[2] == "CountByFormed")
        {
            if(studentRepository.CountByFormed().Count() > 0)
            {
                foreach(var student in studentRepository.CountByFormed())
                {
                    if(student.AttributeName == "1")
                    {
                         Console.WriteLine($"Formado, {student.StudentNumber}");
                    }
                    else
                    {
                        Console.WriteLine($"Não formado, {student.StudentNumber}");
                    }
                }
            }
            else
            {
               Console.WriteLine("Nenhum estudante cadastrado!");
            }
        }
    }

}



    
