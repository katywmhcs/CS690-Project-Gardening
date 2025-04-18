using System;
using System.IO;
using Xunit;
using Gardening;

public class FileSaverTests
{
    private const string TestFileName = "test_log.txt";

    [Fact]
    public void AppendLine_AppendsTextToFile()
    {
        // Arrange
        if (File.Exists(TestFileName))
            File.Delete(TestFileName);

        var saver = new FileSaver(TestFileName);
        string line1 = "Test line 1";
        string line2 = "Test line 2";

        // Act
        saver.AppendLine(line1);
        saver.AppendLine(line2);

        // Assert
        var content = File.ReadAllText(TestFileName);
        Assert.Contains(line1, content);
        Assert.Contains(line2, content);
    }

    [Fact]
    public void Constructor_CreatesFileIfNotExists()
    {
        // Arrange
        if (File.Exists(TestFileName))
            File.Delete(TestFileName);

        // Act
        var saver = new FileSaver(TestFileName);

        // Assert
        Assert.True(File.Exists(TestFileName));
    }

    // Cleanup
    ~FileSaverTests()
    {
        if (File.Exists(TestFileName))
            File.Delete(TestFileName);
    }
}
