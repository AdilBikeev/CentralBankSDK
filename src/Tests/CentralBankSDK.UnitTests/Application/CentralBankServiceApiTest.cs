namespace CentralBankSDK.UnitTests.Application
{
    /// <summary>
    /// Тесты для методов сервиса.
    /// </summary>
    public class CentralBankServiceApiTest
    {
        /// <summary>
        /// Объект для работы с сервисом.
        /// </summary>
        private readonly ICentralBankService _centralBankService;

        ///TODO: В дальнейшем сделать внедрение через Inject.
        public CentralBankServiceApiTest()
        {
            _centralBankService = new CentralBankService();
        }

        /// <summary>
        /// Проверяет успешное получение курсов заданных валют.
        /// </summary>
        /// <param name="vchCode">ISO Цифровой код валюты.</param>
        [Theory]
        [InlineData("USD")]
        [InlineData("RUB")]
        [InlineData("EUR")]
        public async Task Get_curs_on_date_by_vchCode_success(string vchCode)
        {
            var valuteCurs = await _centralBankService.GetCursOnDateByVchCode(DateTime.Now, vchCode);

            Assert.NotNull(valuteCurs);
            Assert.Equal(vchCode, valuteCurs.VchCode);
        }
    }
}
