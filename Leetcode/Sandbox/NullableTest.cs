using FluentAssertions;
using NUnit.Framework;

namespace Leetcode.Sandbox;

public static class NullableSandbox
{
    public static int? Add(int? number)
    {
        number++;
        return number;
    }
}

public class NullableSandboxTest
{
    /// <summary>
    /// Сначала проверила и охренела, почему не боксится, а потом поняла, что
    /// Nullable<T> - это struct
    /// </summary>
    [Test]
    public void NullableValueType_DoNotBox()
    {
        int? number = 1;

        var changed = NullableSandbox.Add(number);

        changed.Should().Be(2);
        changed.Equals(number).Should().BeFalse();
    }
}
