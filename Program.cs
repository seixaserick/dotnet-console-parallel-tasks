

// public StringBuilder object used to show memory allocation test
var myPublicStringForHeavyWorkTest = new System.Text.StringBuilder();


while (true)
{

    // Asks how many HeavyWork tasks should be created
    Console.WriteLine("How many parallel tasks do you want to run (2-10000)?");

    // Read user input
    string? inputText = Console.ReadLine();
    int.TryParse(inputText, out int taskQty);

    // Verify user input qty
    if (taskQty < 2 || taskQty > 10000)
    {
        Console.Clear();
        Console.WriteLine(@$"Your input was ""{inputText}"" and this is not allowed.");
        continue; // Ask again
    }

    // Just a sample resize of ThreadPool to reach more threads (optional)
    System.Threading.ThreadPool.SetMaxThreads(100, 100);

    // Run many parallel tasks now and await all task completition. Parallel approach!
    await RunManyParallelTasks(taskQty);
    
    // Shows how many threads (cumulative) has been completed so far (since app start)
    Console.WriteLine($"This app completed {System.Threading.ThreadPool.CompletedWorkItemCount} threads so far.");


    // Asks the user if want to run again more threads
    if (!RunAgain()) 
    {
        Console.WriteLine("Bye bye. Program finished!");
        break; //exist from loop, closing the program.
    }

    // Frees the memory of this public StringBuilder used for memory allocation test
    myPublicStringForHeavyWorkTest.Clear();
    
    // Calls the garbage collector
    GC.Collect();                          
    
    // Clear console lines and write some cool infos
    Console.Clear();
    Console.WriteLine("The variable myPublicStringForHeavyWorkTest was cleared and Garbage Collector called.");

}




async Task RunManyParallelTasks(int qty)
{
    var startTime = DateTime.Now; // For duration calc
    
    Task[] myTasks = new Task[qty]; // Creates a task array

    Console.Clear();
    Console.WriteLine($"Starting {qty} parallel tasks at {DateTime.Now}...");
    for (int i = 0; i < qty; i++)
    {
        myTasks[i] = DoAsyncOperation(i);
    }
    Console.WriteLine($"All {qty} tasks created. Waiting responses...");

    // Waits until all parallel tasks completes
    await Task.WhenAll(myTasks);

    // Calc total duration
    TimeSpan duration = DateTime.Now - startTime;
    Console.WriteLine($"Finished all {qty} parallel tasks in {(int)duration.TotalMilliseconds} milliseconds");
    Console.WriteLine($"The variable myPublicStringForHeavyWorkTest has {myPublicStringForHeavyWorkTest.Length} bytes.");
}


async Task DoAsyncOperation(int taskIndex)
{
    // High memory allocation test procedure
    HeavyWork();

    // Force a 1 sec delay (optional)
    await Task.Delay(1000); 

    // Print to console the finished task index. You can learn that finish order may be different from call order
    Console.WriteLine($"Task {taskIndex.ToString().PadLeft(4)} finished.");
}

void HeavyWork()
{
    //this procedure generates many string concats using StringBuilder.
    for (int i = 0; i < 2000; i++)
    {
        myPublicStringForHeavyWorkTest.AppendLine($"This is the line {i} from my big string concat using StringBuilder");
    }
}

bool RunAgain()
{
    // This function is called just to ask if the user wants to run again the program
    Console.WriteLine("Run again (Y/N)?");
    var inputText = Console.ReadLine();
    return inputText.ToUpper() == "Y"; //return true if user's input is Y or y
}


