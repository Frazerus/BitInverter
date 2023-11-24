using BitInverter;

namespace BitInverterTests;

public class BitInverterBaseTests
{
  private static object[] cases =
    {
      new ulong []{0b10000000_00000000_00000000_00000000_00000000_00000000_00000000_00000000, 0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000001},
      new ulong []{0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000001, 0b10000000_00000000_00000000_00000000_00000000_00000000_00000000_00000000},
      new ulong []{0b00000000_00000000_00000000_00000000_00000000_00000000_00000000_10000000, 0b00000001_00000000_00000000_00000000_00000000_00000000_00000000_00000000},
      new ulong []{0b00000000_00000000_00000000_00000000_00000000_00000000_10000000_00000000, 0b00000000_00000001_00000000_00000000_00000000_00000000_00000000_00000000},
      new ulong []{0b00000001_00000000_00000000_00000000_10000000_00000000_00000000_00000000, 0b00000000_00000000_00000000_00000001_00000000_00000000_00000000_10000000},
      new ulong []{0b00000000_00000001_00000000_00000000_00000000_00000000_00000000_00000000, 0b00000000_00000000_00000000_00000000_00000000_00000000_10000000_00000000},
      new ulong []{0b00000000_00000000_00000000_00000001_00000000_00000000_00000000_00000000, 0b00000000_00000000_00000000_00000000_10000000_00000000_00000000_00000000},
      new ulong []{0b00000000_00000000_00100000_00000000_00000000_00000000_00000000_00000000, 0b00000000_00000000_00000000_00000000_00000000_00000100_00000000_00000000},
      new ulong []{0b00000000_00000000_00000000_00000000_00000000_00100000_00000000_00000000, 0b00000000_00000000_00000100_00000000_00000000_00000000_00000000_00000000},
    };

  private BitInverterBase _bitInverter;
  [SetUp]
  public void Setup ()
  {
    _bitInverter = new BitInverterBase();
  }

  [Test]
  [TestCaseSource(nameof(cases))]
  public void Test (ulong input, ulong expected)
  {

    var output = _bitInverter.Invert(input);

    Assert.That(output.ToString("b64"), Is.EqualTo(expected.ToString("b64")));


    // 11111111 = 255 => 00000000 = 0
    // 00001000 = 8 => 00010000 = 16


  }
}