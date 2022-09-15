using System.Text;

namespace GornitsaTask;

/// <summary>
/// Реализует парсинг артикула стеклопакета.
/// </summary>
internal class Glazing
{
    private int _chamberness = 0;
    private int _glazingThickness = 0;
    private int _glassThickness = 0;

    public Glazing(string vendorCode) => Parse(vendorCode);

    /// <summary>
    /// Возвращает камерность стеклопакета.
    /// </summary>
    public int Chamberness => _chamberness;

    /// <summary>
    /// Возвращает толщину стеклопакета.
    /// </summary>
    public int GlazingThickness => _glazingThickness;

    /// <summary>
    /// Возвращает толщину стекла.
    /// </summary>
    public int GlassThickness => _glassThickness;

    private void Parse(string vendorCode)
    {
        List<int> numbers = new();
        StringBuilder sb = new();
        bool state = true;

        for (int i = 0; i < vendorCode.Length; i++)
        {
            if (char.IsDigit(vendorCode[i]) && state)
            {
                sb.Append(vendorCode[i]);

                if (i < vendorCode.Length - 1) continue;
            }

            if (sb.Length > 0)
            {
                numbers.Add(int.Parse(sb.ToString()));
                sb.Clear();
                state = false;
            }

            if (vendorCode[i] == '\\' || vendorCode[i] == '/')
            {
                state = true;
            }
        }

        foreach (int number in numbers)
        {
            if (!state)
            {
                _glassThickness += number;
                state = true;
            }
            else
            {
                _glazingThickness += number;
                state = false;
            }
        }

        _glazingThickness += GlassThickness;
        _chamberness = numbers.Count == 3 ? 1 : 2;
    }
}
