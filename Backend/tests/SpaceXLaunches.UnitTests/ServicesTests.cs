namespace SpaceXLaunches.UnitTests;

public class ServicesTests
{
    private Fixture fixture;
    private CancellationToken cancelationTokenMock;
    private Mock<ILogger<SpaceXApiService>> _loggerMock;
    private Mock<IOptions<UrlsConfig>> _urlsMock;


    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public ServicesTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddProfile<MappingProfile>());
        _mapper = _configuration.CreateMapper();
    }

    [SetUp]
    public void Setup()
    {
        fixture = new Fixture();
        cancelationTokenMock = CancellationToken.None;
        _loggerMock = new Mock<ILogger<SpaceXApiService>>();
        _urlsMock = new Mock<IOptions<UrlsConfig>>();
    }


    [Test] 
    public async Task GetOneLaunch_Returns_CorrectDto()
    {
        // ARRANGE
        var flightNumber = 1; 
        var testUri = fixture.Create<Uri>() + flightNumber.ToString();

        var handler = new MockHttpMessageHandler();
        handler.When(HttpMethod.Get, testUri.ToString())
               .Respond(HttpStatusCode.OK, new StringContent("{\"flight_number\": "+ flightNumber + "}"));

        var http = handler.ToHttpClient();
        http.BaseAddress = new Uri(testUri);
        var sut = new SpaceXApiService(http, _loggerMock.Object,_urlsMock.Object, _mapper);

        // ACT
        var result = await sut.GetOneLaunch(1, cancelationTokenMock);

        // ASSERT
        result.Should().NotBeNull();
        result.FlightNumber.Should().Be(flightNumber);

    } 
}