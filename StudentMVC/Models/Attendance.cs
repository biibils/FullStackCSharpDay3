namespace StudentMVC.Models;

public class Attendance
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public AttendanceStatus Status { get; set; }
    public string? Note { get; set; }
}

public enum AttendanceStatus
{
    Hadir,
    Telat,
    Absen,
    Izin,
    Sakit,
}
