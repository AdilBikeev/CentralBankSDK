namespace CentralBankSDK.UnitTests
{
    /// <summary>
    /// Тесты корректной работы сериализации/десериализации ответов от ЦБ РФ.
    /// </summary>
    public class SerializeModelTest
    {
        /// <summary>
        /// Корень каталога с тестами.
        /// </summary>
        private const string SetupPath = "Setup";

        [Theory]
        [InlineData("ValuteData-Valid-Response.xml")]
        public void Can_deserialize_xml_response(string testCaseFileName)
        {
            var xmlStr = File.ReadAllText(Path.Combine(SetupPath, testCaseFileName));
            var exception = Record.Exception(() =>
                SerializerHelper.DeserializeObj<ValuteData>(xmlStr)
            );

            Assert.Null(exception);
        }

        [Theory]
        [InlineData("ValuteData-InValid-Response.xml")]
        public void Cannot_deserialize_xml_response(string testCaseFileName)
        {
            var xmlStr = File.ReadAllText(Path.Combine(SetupPath, testCaseFileName));
            Assert.Throws<InvalidOperationException>(() =>
                SerializerHelper.DeserializeObj<ValuteData>(xmlStr)
            );
        }

        [Theory]
        [InlineData("ValuteData-Valid-Response.xml")]
        public void Valid_deserialize_xml_response(string testCaseFileName)
        {
            var xmlStr = File.ReadAllText(Path.Combine(SetupPath, testCaseFileName));
            var valuteData = SerializerHelper.DeserializeObj<ValuteData>(xmlStr);

            Assert.NotNull(valuteData);
            Assert.NotNull(valuteData.EnumValutes);
            Assert.NotEmpty(valuteData.EnumValutes);
        }
    }
}