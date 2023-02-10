public class ApiIntegrationTests
    {
        private readonly HttpClient _client;

        public ApiIntegrationTests()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5000");
        }

        [Fact]
        public async void Deve_Receber_Dados_Da_Api_1_E_Enviar_Para_Api_2()
        {
            // Arrange
            var api1Uri = "/api/dados";
            var api2Uri = "/api/processar";
            var expectedResult = "Dados processados com sucesso.";

            // Act
            var response = await _client.GetAsync(api1Uri);
            var api1Data = await response.Content.ReadAsStringAsync();
            var content = new StringContent(api1Data, Encoding.UTF8, "application/json");
            var api2Response = await _client.PostAsync(api2Uri, content);
            var api2Result = await api2Response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResult, api2Result);
        }
    }