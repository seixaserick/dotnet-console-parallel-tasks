# Context
Sometimes we can call independent parallel tasks to process many things at same time.
The program finishes when all tasks are completed.
You just need to wait for all tasks completition before return final results.

**Important:** Multi-threading applications with many parallel tasks sometimes can quickly reach a memory stack overflow. In this app you can see and monitor how many memory the app is allocating, a sample memory cleaning but it do not prevent stack overflow error. Try it!

# What does this application do?
- The app asks how many parallel tasks the user you want to run (from 2 up to 10.000 heavy tasks)
- Then, it runs these tasks where each thread do a heavy work with high memory use (big string concatenations)
- Shows the execution time, bytes created in memory and let you see memory usage (windows task manager or htop on Linux) before memory cleaning.
- Order Garbage Collector to free up the used memory by these HeavyWork tasks 
- Ask if you want to run again the app or if you want to quit the program


# Stack and main topics in the project
- .NET 6.0 console application
    - C#
    - Multi-threading (parallel async / await tasks)
    - ThreadPool resizing (System.Threading.ThreadPool.SetMaxThreads)
    - Taks monitoring -> await Task.WhenAll(myTasks)
    - Duration calculation and format to milliseconds
    - String interpolation and Verbatim strings
    - Console input, output and cleaning
    - Garbage Collector usage

- Docker
    - docker build
    - docker run
    - docker container bash interaction (from docker's host shell)


##About the Author and licence
- Erick S. is a Senior Backend Developer and Architect. 
- You can reach **Erick S.** by email <seixaserick77@gmail.com> or Linkedin <https://www.linkedin.com/in/seixaserick/>
- Other Github Repositories: <https://github.com/seixaserick/>
- MIT License (please check LICENSE.txt for more details)





# To run this project on Docker

## Creating a docker image
To create a Docker image, run command line below in the command prompt of project directory:
```
docker build -t dotnet-console-parallel-tasks -f Dockerfile .
```


## Running the app in a docker container

To run the image in Docker container and interact with it, run command line below: 
```
docker run -it --name=dotnet-console-parallel-tasks --restart=unless-stopped dotnet-console-parallel-tasks
```

To stop the container, run command line below: 
```
docker stop dotnet-console-parallel-tasks
```

To remove the container (even if it is running), run command line below: 
```
docker rm --force dotnet-console-parallel-tasks
```