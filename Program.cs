﻿using Microsoft.Data.Sqlite;
using LabManager.Database;
using LabManager.Repositories;
using LabManager.Models;

var DatabaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(DatabaseConfig);

var computerRepository = new ComputerRepository(DatabaseConfig);


//Routing
var modelName = args[0];
var modelAction = args[1];

if (modelName == "Computer")
{
    
    if (modelAction == "List")
    {   
        Console.WriteLine("Lista de computadores:");
        
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }

    else if (modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        
        var computer = new Computer(id, ram, processor);

        computerRepository.Save(computer);
    } 

    if(modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);
        var computer = computerRepository.GetById(id);
        Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
    }
    if(modelAction == "Update")
    {
        var id  = Convert.ToInt32(args[2]); 
        string ram = args[3];
        string processor = args[4]; 
    } 

    if(modelAction == "Delete")
    {
        var id = Covert.ToInt32(args[2]); 
        computerRepository.Update[4]; 
    }
}
else if (modelName == "Lab")
{
    switch (modelAction)
    {
        case "New":
            {
                var id = Convert.ToInt32(args[2]);
                var number = args[3];
                var name = args[4];
                var block = args[5];
                var connection = new SqliteConnection("Data Source=database.db");
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO Labs VALUES($id, $number, $name, $block)";

                command.Parameters.AddWithValue("$id", id);
                command.Parameters.AddWithValue("$number", number);
                command.Parameters.AddWithValue("$name", name);
                command.Parameters.AddWithValue("$block", block);

                command.ExecuteNonQuery();

                connection.Close();

                break;
            }
        case "List":
            {
                var connection = new SqliteConnection("Data Source=database.db");
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = $"SELECT * FROM Labs;";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}");
                }

                connection.Close();
                break;
            }
        default:
            Console.WriteLine("Comando inválido");
            break;
    }
}