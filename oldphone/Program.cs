
using System.Text;

Console.WriteLine(OldPhone.OldPhonePad("33#")); // Output: E
Console.WriteLine(OldPhone.OldPhonePad("227*#")); // Output: B
Console.WriteLine(OldPhone.OldPhonePad("2222 77 *#")); // Output: A
Console.WriteLine(OldPhone.OldPhonePad("2222 #")); // Output: A
Console.WriteLine(OldPhone.OldPhonePad("2222 77 #")); // Output: AQ
Console.WriteLine(OldPhone.OldPhonePad("4433555 555666#")); // Output: HELLO
Console.WriteLine(OldPhone.OldPhonePad("8 88777444666*664#")); // Output: ?????


public enum ButtonType
{
    Digit2 = 2,
    Digit3 = 3,
    Digit4 = 4,
    Digit5 = 5,
    Digit6 = 6,
    Digit7 = 7,
    Digit8 = 8,
    Digit9 = 9,
    Digit0 = 0,
}

public class Button(ButtonType type, string characters)
{
    public ButtonType Type { get; } = type;
    private string Characters { get; } = characters;

    public char GetCharacterAt(int index)
    {
        return Characters[index % Characters.Length];
    }
}

public static class OldPhone
{
    private static readonly Dictionary<ButtonType, Button> Buttons;
    static OldPhone()
    {
        Buttons = new Dictionary<ButtonType, Button>
        {
            { ButtonType.Digit2, new Button(ButtonType.Digit2, "ABC") },
            { ButtonType.Digit3, new Button(ButtonType.Digit3, "DEF") },
            { ButtonType.Digit4, new Button(ButtonType.Digit4, "GHI") },
            { ButtonType.Digit5, new Button(ButtonType.Digit5, "JKL") },
            { ButtonType.Digit6, new Button(ButtonType.Digit6, "MNO") },
            { ButtonType.Digit7, new Button(ButtonType.Digit7, "PQRS") },
            { ButtonType.Digit8, new Button(ButtonType.Digit8, "TUV") },
            { ButtonType.Digit9, new Button(ButtonType.Digit9, "WXYZ") },
            { ButtonType.Digit0, new Button(ButtonType.Digit0, " ") }
        };
    }


    public static string OldPhonePad(string input)
    {
        if (string.IsNullOrEmpty(input) || input[^1] != '#')
            return "";

        StringBuilder output = new();
        char? lastKey = null;
        var lastKeyIndex = 0;

        foreach (var key in input[..^1])
        {
            if (key != '*')
            {
                if (key == ' ')
                {
                    lastKey = null;
                    lastKeyIndex = 0;
                    continue;
                }

                if (!Enum.TryParse(key.ToString(), out ButtonType buttonType) ||
                    !Buttons.ContainsKey(buttonType)) continue;
                if (lastKey == key)
                {
                    lastKeyIndex++;
                }
                else
                {
                    lastKeyIndex = 0;
                }

                var selectedChar = Buttons[buttonType].GetCharacterAt(lastKeyIndex);
                if (output.Length > 0 && lastKey == key)
                {
                    output[^1] = selectedChar;
                }
                else
                {
                    output.Append(selectedChar);
                }

                lastKey = key;
            }
            else
            {
                if (output.Length > 0)
                    output.Remove(output.Length - 1, 1);
                lastKey = null;
                lastKeyIndex = 0;
            }
        }

        return output.ToString();
    }
}

