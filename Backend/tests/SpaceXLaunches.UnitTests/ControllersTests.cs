using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpaceXLaunches.Application.Common.Models;
using SpaceXLaunches.Application.Dtos;
using SpaceXLaunches.Application.Queries;
using SpaceXLaunches.WebApi.Controllers;

namespace SpaceXLaunches.UnitTests
{
    public class ControllersTests
    {
        private CancellationToken cancelationTokenMock;
        private LaunchesController launchesController;
        private RocketsController rocketsController;
        private Mock<ISender> mockMediator;

        [SetUp]
        public void Setup()
        {
            cancelationTokenMock = CancellationToken.None;
            mockMediator = new Mock<ISender>();
            launchesController = new LaunchesController(mockMediator.Object);
            rocketsController = new RocketsController(mockMediator.Object);


            mockMediator
                .Setup(m => m.Send(It.IsAny<GetNextLaunchQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new LaunchDto());

            mockMediator
                .Setup(m => m.Send(It.IsAny<GetOneLaunchQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new LaunchDto());

            mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllLaunchesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PaginatedList<LaunchDto>());

            mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllRocketsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PaginatedList<RocketDto>());
        }


        [Test]
        public async Task GetAll_CallsMediatr_Once()
        {
            await launchesController.GetAll(new GetAllLaunchesQuery(), cancelationTokenMock);
            mockMediator
                .Verify(x => x.Send(It.IsAny<GetAllLaunchesQuery>(), It.IsAny<CancellationToken>()),
                Times.Once());

        }

        [Test]
        public async Task GetOne_CallsMediatr_Once()
        {
            await launchesController.GetByFlightNumber(1, cancelationTokenMock);
            mockMediator
                .Verify(x => x.Send(It.IsAny<GetOneLaunchQuery>(), It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Test]
        public async Task GetNextLaunch_CallsMediatr_Once()
        {
            await launchesController.GetNextLaunch(cancelationTokenMock);
            mockMediator
                .Verify(x => x.Send(It.IsAny<GetNextLaunchQuery>(), It.IsAny<CancellationToken>()),
                Times.Once());
        }
        [Test]
        public async Task GetRockets_CallsMediatr_Once()
        {
            await rocketsController.GetAll(new GetAllRocketsQuery(),cancelationTokenMock);
            mockMediator
                .Verify(x => x.Send(It.IsAny<GetAllRocketsQuery>(), It.IsAny<CancellationToken>()),
                Times.Once());
        }


        [Test]
        public async Task GetAll_Returns_PaginatedList()
        {
            var result = await launchesController.GetAll(new GetAllLaunchesQuery(), cancelationTokenMock);
            result.Should().BeOfType<PaginatedList<LaunchDto>>();
        }

        [Test]
        public async Task GetByFlightNumber_Returns_ActionResult()
        {
            var result = await launchesController.GetByFlightNumber(1, cancelationTokenMock);
            result.Should().BeOfType<ActionResult<LaunchDto>>();
        }
        [Test]
        public async Task GetRockets_Returns_PaginatedList()
        {
            var result = await rocketsController.GetAll(new GetAllRocketsQuery(), cancelationTokenMock);
            result.Should().BeOfType<PaginatedList<RocketDto>>();
        }
    }
}