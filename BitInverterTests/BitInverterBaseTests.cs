using BitInverter;

namespace BitInverterTests;

[TestFixture]
public class BitInverterBaseTests
{
  private static object[] cases =
    {
      new ulong [] { 0b_10000000_00000000_00000000_00000000_00000000_00000000_00000000_00000000, 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000001 },
      new ulong [] { 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_00000001, 0b_10000000_00000000_00000000_00000000_00000000_00000000_00000000_00000000 },
      new ulong [] { 0b_00000000_00000000_00000000_00000000_00000000_00000000_00000000_10000000, 0b_00000001_00000000_00000000_00000000_00000000_00000000_00000000_00000000 },
      new ulong [] { 0b_00000000_00000000_00000000_00000000_00000000_00000000_10000000_00000000, 0b_00000000_00000001_00000000_00000000_00000000_00000000_00000000_00000000 },
      new ulong [] { 0b_00000001_00000000_00000000_00000000_10000000_00000000_00000000_00000000, 0b_00000000_00000000_00000000_00000001_00000000_00000000_00000000_10000000 },
      new ulong [] { 0b_00000000_00000001_00000000_00000000_00000000_00000000_00000000_00000000, 0b_00000000_00000000_00000000_00000000_00000000_00000000_10000000_00000000 },
      new ulong [] { 0b_00000000_00000000_00000000_00000001_00000000_00000000_00000000_00000000, 0b_00000000_00000000_00000000_00000000_10000000_00000000_00000000_00000000 },
      new ulong [] { 0b_00000000_00000000_00100000_00000000_00000000_00000000_00000000_00000000, 0b_00000000_00000000_00000000_00000000_00000000_00000100_00000000_00000000 },
      new ulong [] { 0b_00000000_00000000_00000000_00000000_00000000_00100000_00000000_00000000, 0b_00000000_00000000_00000100_00000000_00000000_00000000_00000000_00000000 },
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

  [Test]
  [TestCaseSource(nameof(cases))]
  public void Invert_v02_No_Branch (ulong input, ulong expected)
  {

    var output = _bitInverter.Invert_v02_No_Branch(input);

    Assert.That(output.ToString("b64"), Is.EqualTo(expected.ToString("b64")));


    // 11111111 = 255 => 00000000 = 0
    // 00001000 = 8 => 00010000 = 16


  }

  [Test]
  [TestCaseSource(nameof(cases))]
  public void Invert_v03_Log2 (ulong input, ulong expected)
  {
    var output = _bitInverter.Invert_v03_Log2(input);

    Assert.That(output.ToString("b64"), Is.EqualTo(expected.ToString("b64")));
  }

  [Test]
  [TestCaseSource(nameof(cases))]
  public void Invert_v03a_Log2_XOR (ulong input, ulong expected)
  {
    var output = _bitInverter.Invert_v03a_Log2_XOR(input);

    Assert.That(output.ToString("b64"), Is.EqualTo(expected.ToString("b64")));
  }

  [Test]
  [TestCaseSource(nameof(cases))]
  public void Invert_v03b_Log2_Compact (ulong input, ulong expected)
  {
    var output = _bitInverter.Invert_v03b_Log2_Compact(input);

    Assert.That(output.ToString("b64"), Is.EqualTo(expected.ToString("b64")));
  }

  [Test]
  [TestCaseSource(nameof(cases))]
  public void Invert_v04_Log2_ReverseEndianness (ulong input, ulong expected)
  {
    var output = _bitInverter.Invert_v04_Log2_ReverseEndianness(input);

    Assert.That(output.ToString("b64"), Is.EqualTo(expected.ToString("b64")));
  }

  [Test]
  [TestCaseSource(nameof(cases))]
  public void Invert_v05 (ulong input, ulong expected)
  {
    var output = _bitInverter.Invert_v05(input);

    Assert.That(output.ToString("b64"), Is.EqualTo(expected.ToString("b64")));
  }
}