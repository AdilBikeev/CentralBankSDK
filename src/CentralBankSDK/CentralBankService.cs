﻿namespace CetralBankSDK
{
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
        public async Task<IEnumerable<EnumValutes>> GetEnumValutes(bool seld = false)
        {
            var resp = await _cbService.EnumValutesXMLAsync(new EnumValutesXMLRequest(seld));
            ValuteData valuteData;

            if (resp is null)
                throw new Exception($"Неполадки при работе с сервисом {nameof(GetEnumValutes)}: сервис ничего не ответил");

            var respStr = resp.EnumValutesXMLResult.OuterXml;
            using (var reader = new StringReader(respStr))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ValuteData));
                valuteData = (ValuteData)serializer.Deserialize(reader)!;
            }

            return valuteData!.EnumValutes;
        }
    }
}