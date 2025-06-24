# 🚀 SpaceX Launches 🚀
   
 <p align="center"><img width=70% src="https://user-images.githubusercontent.com/9815699/234944855-791fde8a-07cc-4876-9c9b-1fe06e59f6de.png"></p>

What is used:
- .Net 8
- React 18
- CQRS + MdeiatR
- Polly and Retry
- Caching
- Logging with Serilog
- Exception Handling
- MediatR Pipelines
- AutoMapper
- NUnit / FluentAssertions / AutoFixture / Moq / MockHttp


To Do:
- [x] Polly
- [x] Unit tests
- [ ] Authentication
- [ ] Rate limiting
- [ ] Api versioning
- [ ] Upgrade to SpaceX api v4

How to run:

```
git clone https://github.com/moslem-hadi/SpaceX-Launches.git
```
Then go to the folder:
```
cd SpaceX-Launches
```
And run docker compose:
```
docker-compose up -d
```

**Make sure that ports 3000 and 7034 are free**

  
---
*Another approach is to:*
- open the backend solution and run the SpaceXLaunches.WebApi project on port 7034
- open frontend project in cmd and run
```
npm i
npm start
```

## Here's what I did:  
I used .Net 8 and I have  4 projects:  
![image](https://github.com/moslem-hadi/SpaceX-Launches/assets/9815699/f74476d1-0896-48d9-b5d3-c71784b2588d)  
  
This structure is based on a clean architecture solution. the Infrastructure layer is responsible for implementing the Application layer.   
I used MediatR to make my controllers cleaner. used Polly to retry calling the SpaceX API. (e.g. in SpaceXApiService.GetLaunches)  
  
I used MemoryCache to cache some data(e.g. GetOneLaunchQuery.Handle)  
I used Serilog for logging and I have a performance logging and a global exception handler that logs errors.  
I used AuthoMapper to map Models to DTOs.  
  
For testing, I used NUnit, FluentAssertions, AutoFixture, Moq, and MockHttp  
  
For the frontend, I used React. I called the app SpaceXplorer(SpaceX + explorer) 😁  
![image](https://github.com/moslem-hadi/SpaceX-Launches/assets/9815699/794704cf-e6e5-4704-9827-54a1853de4d8)
  
And I have a few components and a service to call my API.  
I used pagination and Infinite scroll, so as you scroll down, new data will be fetched.  
For the View page, I just used my design from the first page to save some time.  
  
  ![image](https://github.com/moslem-hadi/SpaceX-Launches/assets/9815699/dc399dcb-33fc-4ba6-bce8-b743dfba6893)
![image](https://github.com/moslem-hadi/SpaceX-Launches/assets/9815699/8abb1ce9-44d9-4066-991a-ed67f32776a6)


