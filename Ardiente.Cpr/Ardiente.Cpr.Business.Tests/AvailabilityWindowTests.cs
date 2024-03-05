namespace Ardiente.Cpr.Business.Tests;

public class AvailabilityWindowTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("John Doe", true)]
    [TestCase("", false)]
    [TestCase(null, false)]
    public void AvailabilityWindow_MustHaveMedProviderSpecified(string medProviderName, bool expectValidationToPass)
    {
        // Arrange
        Exception failedException = null;
        MedProvider medProvider = null;
        
        // Act
        try
        {
            medProvider = new MedProvider(medProviderName);
        }
        catch
        {
        }
        
        try
        {
            var result = new AvailabilityWindow(medProvider, new ScheduleDay(2024, 2, 29), 1, 0, 1, 15);
        }
        catch (Exception e)
        {
            failedException = e;
        }
        
        // Assert
        Assert.That(failedException == null, Is.EqualTo(expectValidationToPass));
    }

    [Test]
    [TestCase(2023, 2, 29, false)]
    [TestCase(2024, 2, 29, true)]
    public void AvailabilityWindow_MustHaveValidScheduleDaySpecified(int year, int month, int day, bool expectValidationToPass)
    {
        // Arrange
        var medProvider = new MedProvider("John Doe");
        Exception failedException = null;
        ScheduleDay scheduleDay = null;

        try
        {
            scheduleDay = new ScheduleDay(year, month, day);
        }
        catch
        {
            // Ignored - to allow for a null ScheduleDay
        }
        
        // Act
        try
        {
            var result = new AvailabilityWindow(medProvider, scheduleDay, 1, 0, 1, 15);
        }
        catch (Exception e)
        {
            failedException = e;
        }
        
        // Assert
        Assert.That(failedException == null, Is.EqualTo(expectValidationToPass));
    }
    
    [Test]
    [TestCase(8, 0, 15, 0, true)]
    [TestCase(8, 2, 15, 0, false)]
    [TestCase(8, 0, 15, 3, false)]
    [TestCase(8, 2, 15, 3, false)]
    public void AvailabilityWindows_CanOnlyBeFifteenMinuteIncrements(int availabilityStartHour, int availabilityStartMinute,
        int availabilityEndHour, int availabilityEndMinute, bool expectValidationToPass)
    {
        // Arrange
        var medProvider = new MedProvider("John Doe");
        var scheduleDay = new ScheduleDay(2024,02, 29);
        Exception failedException = null;
        
        // Act
        try
        {
            var availabilityWindow = new AvailabilityWindow(medProvider, scheduleDay, availabilityStartHour, availabilityStartMinute,
                availabilityEndHour, availabilityEndMinute);
        }
        catch (Exception e)
        {
            failedException = e;
        }
        
        // Assert
        Assert.That(failedException == null, Is.EqualTo(expectValidationToPass));
    }
    
    [Test]
    [TestCase(8, 0, 15, 0, 8, 0, true)]
    [TestCase(8, 0, 8, 15, 8, 0, true)]
    [TestCase(8, 0, 8, 15, 8, 15, false)]
    [TestCase(8, 0, 8, 15, 7, 45, false)]
    public void AvailabilityWindow_Contains_ReturnsTrueIfScheduleDayAndTimeIsWithinAvailabilityWindow(
        int availabilityStartHour, int availabilityStartMinute, int availabilityEndHour, int availabilityEndMinute,
        int hourToTest, int minuteToTest, bool windowContainsTime)
    {
        // Arrange
        var medProvider = new MedProvider("John Doe");
        var scheduleDay = new ScheduleDay(2024, 2, 29);
        var availabilityWindow = new AvailabilityWindow(medProvider, scheduleDay, availabilityStartHour, availabilityStartMinute,
            availabilityEndHour, availabilityEndMinute);
        var time = new TimeOnly(hourToTest, minuteToTest);
        
        // Act
        var result = availabilityWindow.Contains(time);
        
        // Assert
        Assert.That(result, Is.EqualTo(windowContainsTime));
    }
}