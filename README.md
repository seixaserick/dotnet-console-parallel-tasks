# Context
Sometimes we can call independent parallel tasks to process many things at same time.
The program is finished when the last tasks are completed.
You just need to wait for all tasks completition before return final results.

Multi-threading applications with many parallel tasks sometimes can quickly reach a memory stack overflow.

# What does this application do?
- Ask how many parallel taks do you want to run (from 2 up to 10.000 heavy tasks)
- Run these tasks where each thread do a heavy work with high memory use (big string concatenations)
- Shows the execution time, bytes created in memory on HeavyWork procedure and let you see memory usage (windows task manager) before memory cleaning.
- Order Garbage Collector to free up the used memory by these HeavyWork tasks 
- Ask if you want to run or quit the program


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
- You can reach Erick by email <seixaserick77@gmail.com> or Linkedin <https://www.linkedin.com/in/seixaserick/>
- More Github projects: <https://github.com/seixaserick/>





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