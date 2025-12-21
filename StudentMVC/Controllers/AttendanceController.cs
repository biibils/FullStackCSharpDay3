using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;
using StudentMVC.Services;

namespace StudentMVC.Controllers;

public class AttendanceController : Controller
{
    private readonly IStudentService _studentService;
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(
        IStudentService studentService,
        IAttendanceService attendanceService
    )
    {
        _studentService = studentService;
        _attendanceService = attendanceService;
    }

    public IActionResult Index()
    {
        var attendances = _attendanceService.GetAll();
        return View(attendances);
    }

    // GET: Attendance/Create/{studentId}
    [HttpGet]
    public IActionResult Create(int studentId)
    {
        var student = _studentService.GetStudentById(studentId);
        if (student == null)
            return NotFound();

        var attendance = new Attendance
        {
            StudentId = studentId,
            Student = student,
            Date = DateTime.Now,
            Time = DateTime.Now,
        };
        return View(attendance);
    }

    // POST: Attendance/Create/{studentId}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Attendance attendance)
    {
        var student = _studentService.GetStudentById(attendance.StudentId);
        if (student == null)
            return NotFound();

        attendance.Student = student;

        if (ModelState.IsValid)
        {
            _attendanceService.CreateAttendance(attendance);
            return RedirectToAction(nameof(Index));
        }
        return View(attendance);
    }
}
