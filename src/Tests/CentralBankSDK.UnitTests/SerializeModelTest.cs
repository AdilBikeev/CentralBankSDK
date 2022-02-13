namespace CentralBankSDK.UnitTests
{
    /// <summary>
    /// ����� ���������� ������ ������������/�������������� ������� �� �� ��.
    /// </summary>
    public class SerializeModelTest
    {
        /// <summary>
        /// ������ �������� � �������.
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
    }
}