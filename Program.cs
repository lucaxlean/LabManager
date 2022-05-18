using Microsoft.Data.Sqlite;
using LabManager.Database;  
using LabManager.Repositories;

var databaseSetup = new DatabaseSetup(); 
var ComputerRepository = new ComputerRepository;
databaseSetup.CreateComputerTable(); 


//Routing 

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        var computers = ComputerRepository,GetAll();
        foreach (var computer in computers)
        {
             Console.WriteLine($ "{0}, {1}, {2}, computer, Id, computer.Ram, computer.Processor");
        }
        var message = $"{computer.id}, {computer.Ram}, {computer.Processor}";
    
       
    }

    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

      var     connection = new SqliteConnection("Data Source=database.db"); 
        connection.Open();

      var  command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);

        command.ExecuteNonQuery();
        connection.Close();
    }
}