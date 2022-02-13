namespace CentralBankSDK.Model.CursOnDateResponse
{
    /// <summary>
    /// Информация со списком курса валют в текущую дату.
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "ValuteData")]
    public sealed record ValuteDataCursOnDate
    {
        /// <summary>
        /// Список существующих валют.
        /// </summary>
        [XmlElement(ElementName = "ValuteCursOnDate")]
        public List<ValuteCursOnDate> ValuteCursOnDate { get; init; } = default!;
    }
}
