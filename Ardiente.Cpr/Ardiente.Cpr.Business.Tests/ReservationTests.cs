namespace Ardiente.Cpr.Business.Tests;

public class ReservationTests
{
    [Test]
    [TestCase(2024, 3, 1, 2024, 2, 29, true)]
    [TestCase(2024, 2, 29, 2024, 2, 29, false)]
    [TestCase(2024, 2, 29, 2024, 3, 1, false)]
    public void Reservation_MustBeMadeAtLeast24HoursInAdvance(int availabilityYear, int availabilityMonth, int availabilityDay,
        int reservationYear, int reservationMonth, int reservationDay, bool expectValidationToPass)
    {
        // Arrange
        var medProvider = new MedProvider("John Doe");
        var availabilityScheduleDay = new ScheduleDay(availabilityYear, availabilityMonth, availabilityDay);
        var availabilityWindow = new AvailabilityWindow(medProvider, availabilityScheduleDay, 1, 0, 1, 15);
        var appointmentSlot = new AppointmentSlot(availabilityScheduleDay, availabilityWindow, new TimeOnly(1, 0));
        var reservationDate = new DateTime(reservationYear, reservationMonth, reservationDay).AddHours(1);
        Exception failedException = null;
        
        // Assert
        try
        {
            var reservation = new Reservation(appointmentSlot, reservationDate);
        }
        catch (Exception e)
        {
            failedException = e;
        }
        
        // Act
        Assert.That(failedException == null, Is.EqualTo(expectValidationToPass));
    }
    
    [Test]
    [TestCase(2024, 3, 1, 2024, 2, 29, true)]
    [TestCase(2024, 2, 29, 2024, 2, 29, false)]
    [TestCase(2024, 2, 29, 2024, 3, 1, false)]
    public void Reservation_ExpiresIfNotConfirmedAfter30Minutes(int availabilityYear, int availabilityMonth, int availabilityDay,
        int reservationYear, int reservationMonth, int reservationDay, bool expectValidationToPass)
    {
        // Arrange
        var medProvider = new MedProvider("John Doe");
        var availabilityScheduleDay = new ScheduleDay(availabilityYear, availabilityMonth, availabilityDay);
        var availabilityWindow = new AvailabilityWindow(medProvider, availabilityScheduleDay, 1, 0, 1, 15);
        var appointmentSlot = new AppointmentSlot(availabilityScheduleDay, availabilityWindow, new TimeOnly(1, 0));
        var reservationDate = new DateTime(reservationYear, reservationMonth, reservationDay).AddHours(1);
        Exception failedException = null;
        
        // Assert
        try
        {
            var reservation = new Reservation(appointmentSlot, reservationDate);
        }
        catch (Exception e)
        {
            failedException = e;
        }
        
        // Act
        Assert.That(failedException == null, Is.EqualTo(expectValidationToPass));
    }
}