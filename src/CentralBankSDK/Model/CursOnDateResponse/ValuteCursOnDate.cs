namespace CetralBankSDK.Model.CursOnDateResponse
{
    /// <summary>
    /// Информация о курсе валюты в заданную дату.
    /// </summary>
    [Serializable]
    public sealed record ValuteCursOnDate
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        public string Vname { get; init; } = default!;

        /// <summary>
        /// Номинал.
        /// </summary>
        public string Vnom { get; init; } = default!;

        /// <summary>
        /// Курс.
        /// </summary>
        public decimal Vcurs { get; init; } = default!;

        /// <summary>
        /// ISO Цифровой код валюты.
        /// </summary>
        public string Vcode { get; init; } = default!;

        /// <summary>
        /// ISO Символьный код валюты.
        /// </summary>
        public string VchCode { get; init; } = default!;
    }
}
