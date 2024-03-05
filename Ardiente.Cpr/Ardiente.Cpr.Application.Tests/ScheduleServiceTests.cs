using Ardiente.Cpr.Application.Interfaces.Providers;
using Ardiente.Cpr.Business;
using NSubstitute;
using NSubstitute.ClearExtensions;

namespace Ardiente.Cpr.Application.Tests;

public class ScheduleServiceTests
{
    private IAvailabilityWindowProvider _availabilityWindowProvider;
    
    [SetUp]
    public void Setup()
    {
        _availabilityWindowProvider = Substitute.For<IAvailabilityWindowProvider>();
        _availabilityWindowProvider.ClearSubstitute();
    }

    [Test]
    public async Task ScheduleService_GetAvailableAppointmentSlots_DoesNotReturnAvailableAppointmentSlotsWhenNoProviderAvailability()
    {
        // Arrange
        var scheduleDay = new ScheduleDay(2024, 2, 29);
        var availabilityWindows = new List<AvailabilityWindow>()
        {
            new AvailabilityWindow(new MedProvider("John Doe"), scheduleDay, 1, 0, 1, 15),
            new AvailabilityWindow(new MedProvider("Jane Doe"), scheduleDay, 1, 0, 1, 15)
        };
        
        _availabilityWindowProvider.GetAvailabilityWindowsAsync(scheduleDay).Returns(availabilityWindows);
        var scheduleService = new ScheduleService(_availabilityWindowProvider);
        var tomorrow = new ScheduleDay(2024, 3, 1);
        _availabilityWindowProvider.GetAvailabilityWindowsAsync(tomorrow).Returns(new List<AvailabilityWindow>());
        
        // Act
        var results = await scheduleService.GetAvailableAppointmentSlots(tomorrow);
        
        // Assert
        Assert.That(results.Count, Is.EqualTo(0));        
    }

    
    [Test]
    public async Task ScheduleService_GetAvailableAppointmentSlots_ReturnsAvailableAppointmentSlotsAccordingToProviderAvailability()
    {
        // Arrange
        var scheduleDay = new ScheduleDay(2024, 2, 29);
        var availabilityWindows = new List<AvailabilityWindow>
        {
            new AvailabilityWindow(new MedProvider("John Doe"), scheduleDay, 1, 0, 1, 15),
            new AvailabilityWindow(new MedProvider("Jane Doe"), scheduleDay, 1, 0, 1, 15)
        };
        
        _availabilityWindowProvider.GetAvailabilityWindowsAsync(Arg.Any<ScheduleDay>()).Returns(availabilityWindows);
        var scheduleService = new ScheduleService(_availabilityWindowProvider);
        
        // Act
        var results = await scheduleService.GetAvailableAppointmentSlots(scheduleDay);
        
        // Assert
        Assert.That(results.Count, Is.EqualTo(availabilityWindows.Count));
    }
}

