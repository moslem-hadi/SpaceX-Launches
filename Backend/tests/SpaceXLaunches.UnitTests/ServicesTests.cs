using AutoFixture;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using RichardSzalay.MockHttp;
using SpaceXLaunches.Application.Common.Interfaces;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Dtos;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.Infrastructure.Configs;
using SpaceXLaunches.Infrastructure.Services;
using SpaceXLaunches.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXLaunches.UnitTests
{
    public class ServicesTests
    {
        private Fixture fixture;
        private Mock<ILaunchService> launchServiceMock;
        private CancellationToken cancelationTokenMock;
        private Mock<ISender> mockMediator;
        private Mock<ILogger<SpaceXApiService>> _loggerMock;
        private Mock<IOptions<UrlsConfig>> _urlsMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
            launchServiceMock = new Mock<ILaunchService>();
            cancelationTokenMock = CancellationToken.None;
            mockMediator = new Mock<ISender>();
            _loggerMock = new Mock<ILogger<SpaceXApiService>>();
            _urlsMock = new Mock<IOptions<UrlsConfig>>();
            _mapperMock = new Mock<IMapper>();
        }


        [Test] 
        public async Task GetLaunches_Returns_PaginatedList()
        {
            // ARRANGE
            var testUri = fixture.Create<Uri>();
            var expectedResult = fixture.Create<PaginatedList<LaunchDto>>();

            var handler = new MockHttpMessageHandler();
            handler.When(HttpMethod.Get, testUri.ToString())
                   .Respond(HttpStatusCode.OK, new StringContent("[{\"flight_number\": 6}]"));

            var http = handler.ToHttpClient();

            var sut = new SpaceXApiService(http, _loggerMock.Object,_urlsMock.Object,_mapperMock.Object);

            // ACT
            var result = await sut.GetLaunches(new GetAllLaunchesQuery(), cancelationTokenMock);

            // ASSERT
            Assert.That(result, Is.EqualTo(expectedResult));

        } 
    }
}