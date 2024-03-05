namespace Ardiente.Cpr.Business.Tests;

public class ScheduleDayTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(2024, 02, 29, true)]
    [TestCase(2023, 02, 29, false)]
    [TestCase(2024, 09, 31, false)]
    [TestCase(2024, 09, 0, false)]
    public void ScheduleDays_CanOnlyBeActualDates(int year, int month, int day, bool validationPasses)
    {
        // Arrange
        Exception failedException = null;
        
        // Act
        try
        {
            var result = new ScheduleDay(year, month, day);
        }
        catch (Exception e)
        {
            failedException = e;
        }
        
        // Assert
        Assert.That(failedException == null, Is.EqualTo(validationPasses));
    }
}