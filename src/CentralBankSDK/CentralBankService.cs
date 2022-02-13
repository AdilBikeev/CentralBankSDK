namespace CetralBankSDK
{
    /// <summary>
    /// Интерфейс описывающий SDK CentralBankService.
    /// </summary>
    public interface ICentralBankService
    {
        /// <summary>
        /// Возвращает список валют.
        /// </summary>
        /// <param name="seld">
        /// True - перечень ежемесячных валют
        /// False — перечень ежедневных валют
        /// </param>
        Task<IEnumerable<EnumValutes>> GetEnumValutesAsync(bool seld = false);

        /// <summary>
        /// Возвращает список с курсом по каждой валюте в заданую дату.
        /// </summary>
        /// <param name="date">Дата запроса для курсов.</param>
        Task<IEnumerable<ValuteCursOnDate>> GetCursOnDateXMLAsync(DateTime date);

        /// <summary>
        /// Возвращает информацию о курсе валюты в заданную дату по VchCode.
        /// </summary>
        /// <param name="date">Дата запроса для курса.</param>
        /// <param name="vchCode">Код валюты.</param>
        Task<ValuteCursOnDateReadDTO> GetCursOnDateByVchCode(DateTime date, string vchCode);
    }

    /// <summary>
    /// Сервис для работы с WCF сервисом Центрального Банка.
    /// </summary>
    public class CentralBankService : ICentralBankService
    {
        /// <summary>
        /// Сервис ЦБ РФ для работы с валютой.
        /// </summary>
        private readonly CentralBankDailyInfoService.DailyInfoSoap _cbService;

        /// <summary>
        /// Инициалиализация сервиса.
        /// </summary>
        /// <param name="endpointConfiguration">
        /// Версия SOAP протокола для 
        /// производства запрососв к сервису 
        /// (по умолчанию используется 2 версия).
        /// </param>
        public CentralBankService(DailyInfoSoapClient.EndpointConfiguration endpointConfiguration
            = DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap12)
        {
            _cbService = new DailyInfoSoapClient(endpointConfiguration);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<EnumValutes>> GetEnumValutesAsync(bool seld = false)
        {
            var resp = await _cbService.EnumValutesXMLAsync(new EnumValutesXMLRequest(seld));

            if (resp is null)
                throw new Exception($"Неполадки при работе с сервисом {nameof(GetEnumValutesAsync)}: сервис ничего не ответил");

            var respStr = resp.EnumValutesXMLResult.OuterXml;
            var valuteData = SerializerHelper.DeserializeObj<ValuteData>(respStr);

            return valuteData.EnumValutes;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ValuteCursOnDate>> GetCursOnDateXMLAsync(DateTime date)
        {
            var resp = await _cbService.GetCursOnDateXMLAsync(new GetCursOnDateXMLRequest(date));

            if (resp is null)
                throw new Exception($"Неполадки при работе с сервисом {nameof(GetCursOnDateXMLAsync)}: сервис ничего не ответил");

            var respStr = resp.GetCursOnDateXMLResult.OuterXml;
            var valuteData = SerializerHelper.DeserializeObj<ValuteDataCursOnDate>(respStr);

            return valuteData.ValuteCursOnDate;
        }

        /// <inheritdoc/>
        public async Task<ValuteCursOnDateReadDTO> GetCursOnDateByVchCode(DateTime date, string vchCode)
        {
            var valutes = await GetCursOnDateXMLAsync(date);
            var valute = valutes.First(v => v.VchCode.Equals(vchCode));

            return (new ValuteCursOnDateReadDTO()) with
            {
                Vcode = valute.Vcode,
                Vcurs = valute.Vcurs,
                Vname = valute.Vname,
            };
        }
    }
}