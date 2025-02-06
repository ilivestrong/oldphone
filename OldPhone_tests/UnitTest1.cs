
using Xunit;


namespace OldPhone_tests;

public class OldPhoneTests
{
    [Fact]
    public void OldPhonePad_ReturnsEmpty_WhenInputIsEmpty()
    {
        Xunit.Assert.Equal("", OldPhone.OldPhonePad(""));
    }

    [Fact]
    public void OldPhonePad_ReturnsEmpty_WhenInputDoesNotEndWithHash()
    {
        Xunit.Assert.Equal("", OldPhone.OldPhonePad("23"));
    }

    [Fact]
    public void OldPhonePad_CorrectlyProcessesSingleKeyPress()
    {
        Xunit.Assert.Equal("A", OldPhone.OldPhonePad("2#"));
        Xunit.Assert.Equal("D", OldPhone.OldPhonePad("3#"));
    }

    [Fact]
    public void OldPhonePad_CorrectlyProcessesMultipleKeyPresses()
    {
        Xunit.Assert.Equal("E", OldPhone.OldPhonePad("33#"));
        Xunit.Assert.Equal("B", OldPhone.OldPhonePad("22#"));
    }

    [Fact]
    public void OldPhonePad_CorrectlyHandlesBackspace()
    {
        Xunit.Assert.Equal("B", OldPhone.OldPhonePad("227*#"));
    }

    [Fact]
    public void OldPhonePad_CorrectlyHandlesSpaces()
    {
        Xunit.Assert.Equal("HELLO", OldPhone.OldPhonePad("4433555 555666#"));
    }

    [Fact]
    public void OldPhonePad_CorrectlyProcessesComplexSequence()
    {
        Xunit.Assert.Equal("TURING", OldPhone.OldPhonePad("8 88777444666*664#"));
    }
    
    [Fact]
    public void OldPhonePad_ReturnsEmpty_WhenInvalidInputKeyIsPresent()
    {
        Xunit.Assert.Equal("", OldPhone.OldPhonePad("227 $$"));
    }
    
    [Fact]
    public void OldPhonePad_ReturnsFirstCharacterWhenKeyPressedFourTimes()
    {
        Xunit.Assert.Equal("A", OldPhone.OldPhonePad("2222 #"));
    }
    
     [Fact]
    public void OldPhonePad_ReturnsEmpty_WhenKeyPressedFourTimes_With_Backspace()
    {
        Xunit.Assert.Equal("", OldPhone.OldPhonePad("2222 *"));
    }
}