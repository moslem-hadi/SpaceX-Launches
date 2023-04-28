# 🚀 SpaceX Launches 🚀
   
 <p align="center"><img width=70% src="https://user-images.githubusercontent.com/9815699/234944855-791fde8a-07cc-4876-9c9b-1fe06e59f6de.png"></p>

What is used:
- .Net 6
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
