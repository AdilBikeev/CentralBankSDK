namespace CentralBankSDK.DTO
{
    /// <summary>
    /// Информация о курсе валюты в заданную дату.
    /// </summary>
    public record ValuteCursOnDateReadDTO
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        /// <example>Австралийский доллар.</example>
        public string Vname { get; init; } = default!;

        /// <summary>
        /// Курс.
        /// </summary>
        /// <example>53.5105</example>
        public decimal Vcurs { get; init; } = default!;

        /// <summary>
        /// ISO Цифровой код валюты.
        /// </summary>
        /// <example>AUD</example>
        public string VchCode { get; init; } = default!;
    }
}
